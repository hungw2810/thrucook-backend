using MediatR;
using System;
using Thucook.Main.ApiModel;

namespace Thucook.Main.ApiAction
{
    public class ApiActionModel
    {
        public static ApiActionAnonymousRequest<T> CreateRequest<T>(T input)
            where T : IApiInput, new()
        {
            return new ApiActionAnonymousRequest<T>()
            {
                Input = input
            };
        }
        public static ApiActionAuthenticatedRequest<T> CreateRequest<T>(Guid userId, T input)
            where T : IApiInput, new()
        {
            return new ApiActionAuthenticatedRequest<T>()
            {
                UserId = userId,
                Input = input
            };
        }
        public static ApiActionLocationRequest<T> CreateRequest<T>(Guid userId, Guid locationId, T input)
            where T : IApiInput, new()
        {
            return new ApiActionLocationRequest<T>()
            {
                UserId = userId,
                LocationId = locationId,
                Input = input
            };
        }
    }

    public class ApiActionAnonymousRequest<T> : IRequest<IApiResponse>
    {
        internal ApiActionAnonymousRequest() { }
        public T Input { get; set; }
    }

    public class ApiActionAuthenticatedRequest<T> : IRequest<IApiResponse>
        where T : IApiInput, new()
    {
        internal ApiActionAuthenticatedRequest() { }
        public Guid UserId { get; set; }
        public T Input { get; set; }
    }

    public class ApiActionLocationRequest<T> : IRequest<IApiResponse>
        where T : IApiInput, new()
    {
        internal ApiActionLocationRequest() { }
        public Guid UserId { get; set; }
        public Guid LocationId { get; set; }
        public T Input { get; set; }
    }
}
