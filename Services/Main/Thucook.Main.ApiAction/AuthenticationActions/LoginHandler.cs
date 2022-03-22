using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class LoginHandler : IRequestHandler<ApiActionAnonymousRequest<AuthLoginInputModel>, IApiResponse>
    {
        private readonly ThucookContext _dbContext;
        private readonly IJwtService _jwtService;

        public LoginHandler(ThucookContext dbContext, IJwtService jwtService)
        {
            _dbContext = dbContext;
            _jwtService = jwtService;
        }

        public async Task<IApiResponse> Handle(ApiActionAnonymousRequest<AuthLoginInputModel> request, CancellationToken cancellationToken)
        {
            var passwordHash = StringHelper.HashString(request.Input.Password);
            var user = await (from u in _dbContext.Users
                              where
                              u.UserName == request.Input.UserName &&
                              u.PasswordHashed == passwordHash &&
                              u.IsDeleted == false
                              select u).FirstOrDefaultAsync(cancellationToken);
            if (user == null)
            {
                return ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest, ApiInternalErrorMessages.InvalidUserNameOrPassword);
            }

            // Check if user is employee of location -> add claims 
            var location = await (from l in _dbContext.Locations
                                  join e in _dbContext.Employees on l.LocationId equals e.LocationId
                                  where
                                  e.UserId == user.UserId
                                  select l).FirstOrDefaultAsync(cancellationToken);

            return ApiResponse.CreateModel(new UserLoginResponseModel
            {
                AccessToken = new AccessTokenModel
                {
                    Token = _jwtService.GenerateJwt(user, location),
                    ExpireTime = DateTime.Now.AddDays(1)
                },
                User = new UserResponseModel
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    StatusId = (UserStatusEnum)user.UserStatusId
                }
            });
        }
    }
}
