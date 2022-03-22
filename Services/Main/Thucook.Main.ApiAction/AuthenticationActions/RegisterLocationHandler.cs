using MediatR;
using Microsoft.EntityFrameworkCore;
using Sodium;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Thucook.Commons.Enums;
using Thucook.Commons.Utils;
using Thucook.EntityFramework;
using Thucook.Main.ApiModel;
using Thucook.Main.ApiModel.ApiErrorMessages;
using Thucook.Main.ApiModel.ApiInputModels;
using Thucook.Main.ApiModel.ApiReponseModels;
using Thucook.Main.ApiService;

namespace Thucook.Main.ApiAction.AuthenticationActions
{
    public class RegisterLocationHandler : IRequestHandler<ApiActionAnonymousRequest<AuthRegisterLocationInputModel>, IApiResponse>
    {
        private readonly ThucookContext _dbContext;
        private readonly IJwtService _jwtService;

        public RegisterLocationHandler(ThucookContext dbContext, IJwtService jwtService)
        {
            _dbContext = dbContext;
            _jwtService = jwtService;
        }

        public async Task<IApiResponse> Handle(ApiActionAnonymousRequest<AuthRegisterLocationInputModel> request, CancellationToken cancellationToken)
        {
            #region Validate input
            var signupCode = await (from sc in _dbContext.SignupCodes
                                    where
                                    sc.SignupCodeValue == request.Input.SignUpCode &&
                                    sc.IsAvaiable == true
                                    select sc).FirstOrDefaultAsync(cancellationToken);
            if (signupCode == null)
            {
                return ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest, ApiInternalErrorMessages.InvalidSignupCode);
            }

            var user = await (from u in _dbContext.Users
                              where
                              u.UserName == request.Input.Email &&
                              u.IsDeleted == false
                              select u).FirstOrDefaultAsync(cancellationToken);

            if (user != null)
            {
                return ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest, ApiInternalErrorMessages.EmailAlreadyUsed);
            }

            var location = await (from l in _dbContext.Locations
                                  where
                                  l.LocationName == request.Input.BussinessName &&
                                  l.IsDeleted == false
                                  select l).FirstOrDefaultAsync(cancellationToken);
            if (location != null)
            {
                return ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest, ApiInternalErrorMessages.DuplicateLocationName);
            }

            location = await (from l in _dbContext.Locations
                              where
                              l.PhoneNumber == request.Input.PhoneNumber &&
                              l.IsDeleted == false
                              select l).FirstOrDefaultAsync(cancellationToken);
            if (location != null)
            {
                return ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest, ApiInternalErrorMessages.DuplicateLocationPhoneNumber);
            }
            #endregion

            var userId = Guid.NewGuid();
            var locationId = Guid.NewGuid();
            user = new User
            {
                UserId = userId,
                UserName = request.Input.Email,
                PasswordHashed = StringHelper.HashString(request.Input.Password),
                UserTypeId = (int)UserTypeEnum.Location,
                UserStatusId = (int)UserStatusEnum.Normal,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            _dbContext.Users.Add(user);

            location = new Location
            {
                LocationId = locationId,
                LocationName = request.Input.BussinessName,
                PhoneNumber = request.Input.PhoneNumber,
                Email = request.Input.Email,
                CityId = (short)request.Input.City,
                Address = request.Input.Address,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _dbContext.Locations.Add(location);

            var employee = new Employee
            {
                UserId = userId,
                LocationId = locationId,
                RoleId = (short)RoleTypeEnum.Owner,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _dbContext.Employees.Add(employee);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return ApiResponse.CreateModel(new UserLoginResponseModel
            {
                AccessToken = new AccessTokenModel
                {
                    Token = _jwtService.GenerateJwt(user, location),
                    ExpireTime = DateTime.Now.AddDays(1)
                },
                User = new UserResponseModel
                {
                    UserId = userId,
                    UserName = user.UserName,
                    StatusId = (UserStatusEnum)user.UserStatusId
                }
            });
        }
    }
}
