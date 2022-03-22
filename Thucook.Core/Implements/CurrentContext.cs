using Microsoft.AspNetCore.Http;
using System;
using Thucook.Commons.Constants;
using Thucook.Commons.Enums;

namespace Thucook.Core.Implements
{
    public class CurrentContext : ICurrentContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private Guid? _userId;
        public Guid? _locationId;
        private UserTypeEnum? _userTypeId = null;

        public Guid? UserId
        {
            get
            {
                if (_userId.HasValue)
                    return _userId;
                var userId = GetClaimValue(OAuthConstants.ClaimTypes.UserId);
                if (string.IsNullOrEmpty(userId))
                {
                    return null;
                }
                else
                {
                    _userId = Guid.Parse(userId);
                    return _userId;
                }
            }
        }

        public UserTypeEnum? UserTypeId
        {
            get
            {
                if (_userTypeId.HasValue)
                    return _userTypeId;

                var userType = GetClaimValue(OAuthConstants.ClaimTypes.UserType);
                if (string.IsNullOrEmpty(userType) || !int.TryParse(userType, out int userTypeId))
                {
                    return null;
                }

                _userTypeId = (UserTypeEnum)userTypeId;
                return _userTypeId;
            }
        }

        public Guid LocationId
        {
            get 
            {
                if (_locationId.HasValue)
                    return _locationId.Value;
                var locationId = GetClaimValue(OAuthConstants.ClaimTypes.LocationId);
                if (string.IsNullOrEmpty(locationId))
                {
                    _locationId = Guid.Empty;
                }
                else
                {
                    _locationId = Guid.Parse(locationId);
                }

                return _locationId.Value;
            }
        }

        private string GetClaimValue(params string[] claimTypes)
        {

            foreach (var claimType in claimTypes)
            {
                var claim = _httpContextAccessor.HttpContext.User.FindFirst(claimType);

                if (claim != null)
                    return claim.Value ?? string.Empty;
            }

            return string.Empty;
        }
    }
}
