using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thucook.EntityFramework;
using Thucook.Main.ApiAction;
using Thucook.Main.ApiModel;
using Thucook.Main.ApiModel.ApiInputModels;

namespace DrClThucookoud.Main.ApiAction.AuthenticationActions
{
    public class LoginHandler : IRequestHandler<ApiActionAnonymousRequest<AuthLoginInputModel>, IApiResponse>
    {
        private readonly ThucookContext _dbContext;

        public LoginHandler(ThucookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IApiResponse> Handle(ApiActionAnonymousRequest<AuthLoginInputModel> request, CancellationToken cancellationToken)
        {
            //    var token = await _tokenClient.RequestPasswordTokenAsync(request.Input.UserName, request.Input.Password, "main.read_write offline_access");
            //    if (token.IsError)
            //    {
            //        if (token.ErrorDescription == OAuthConstants.ErrorMessage.CannotFindUser || token.ErrorDescription == OAuthConstants.ErrorMessage.PasswordIncorrect)
            //        {
            //            return ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest, ApiInternalErrorMessages.InvalidUsernameOrPassword);
            //        }
            //        return ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest, ApiInternalErrorMessages.LoginFailed);
            //    }
            //    if (!token.Json.TryGetProperty("userId", out var userIdValue))
            //    {
            //        return ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest, ApiInternalErrorMessages.LoginFailed);
            //    }
            //    if (string.IsNullOrEmpty(userIdValue.ToString()))
            //    {
            //        return ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest, ApiInternalErrorMessages.LoginFailed);
            //    }

            //    var user = await (from u in _dbContext.Users
            //                      where
            //                      u.UserId == Guid.Parse(userIdValue.ToString())
            //                      select u).FirstOrDefaultAsync(cancellationToken);
            //    if (user == null)
            //    {
            //        return ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest, ApiInternalErrorMessages.LoginFailed);
            //    }
            //    if (user.StatusId == (int)UserStatusEnum.WaitForVerify)
            //    {
            //        return ApiResponse.CreateErrorModel(HttpStatusCode.BadRequest, ApiInternalErrorMessages.UserNotVerified);
            //    }

            //    return ApiResponse.CreateModel(new UserLoginResponseModel()
            //    {
            //        Token = new UserTokenResponseModel
            //        {
            //            AccessToken = token.AccessToken,
            //            ExpiresIn = token.ExpiresIn,
            //            RefreshToken = token.RefreshToken,
            //            TokenType = token.TokenType
            //        },
            //        User = new UserResponseModel
            //        {
            //            UserId = user.UserId,
            //            UserName = user.UserName,
            //            StatusId = user.StatusId,
            //            CreatedAtUnix = user.CreatedAtUtc.ToUnixTime(),
            //            UpdatedAtUnix = user.UpdatedAtUtc.ToUnixTime()
            //        }
            //    });
      
            Console.WriteLine("yei");
            throw new NotImplementedException();
        }
    }
}
