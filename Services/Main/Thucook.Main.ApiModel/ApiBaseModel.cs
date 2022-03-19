using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Thucook.Main.ApiModel
{
    public interface IApiInput { }
    public interface IApiResponse : IActionResult { }
    public interface IApiResponseData { }

    public class ApiResponseMetadata
    {
        public bool Success { get; set; }
        public IEnumerable<ApiErrorMessage> Messages { get; set; }
        public ApiResponseMetadata(bool success = true, params ApiErrorMessage[] messages)
        {
            Success = success;
            Messages = messages;
        }
    }
    public class ApiReponsePaging
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalItem { get; set; }
        public string OrderBy { get; set; }
        public int? OrderByType { get; set; }
        public IEnumerable<string> OrderableProperties { get; set; }
        public ApiReponsePaging(int pageSize, int pageNumber, int totalItems)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalItem = totalItems;
            OrderBy = null;
            OrderByType = null;
            OrderableProperties = null;
        }
        public ApiReponsePaging(int pageSize, int pageNumber, int totalItems, string orderBy, int orderByType)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalItem = totalItems;
            OrderBy = orderBy;
            OrderByType = orderByType;
            OrderableProperties = null;
        }
        public ApiReponsePaging(int pageSize, int pageNumber, int totalItems, string orderBy, int orderByType, List<string> orderableProperties)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalItem = totalItems;
            OrderBy = orderBy;
            OrderByType = orderByType;
            OrderableProperties = orderableProperties;
        }
    }

    public class ApiResponseArrayWithPaging<T>
        where T : IApiResponseData
    {
        public ApiReponsePaging Paging { get; set; }
        public IEnumerable<T> PageData { get; set; }

        public ApiResponseArrayWithPaging(IEnumerable<T> pageData, ApiReponsePaging paging)
        {
            PageData = pageData;
            Paging = paging;
        }
    }

    public class ApiResponseModel
    {
        public ApiResponseMetadata Metadata { get; set; }

        public static explicit operator ApiResponseModel(JsonActionResult v)
        {
            throw new NotImplementedException();
        }
    }

    public class ApiResponseModel<TResponse>
        where TResponse : IApiResponseData, new()
    {
        public ApiResponseMetadata Metadata { get; set; }
        public TResponse Data { get; set; }
    }
    public class ApiPagingResponseModel<TResponse>
        where TResponse : IApiResponseData, new()
    {
        public ApiResponseMetadata Metadata { get; set; }
        public ApiResponseArrayWithPaging<TResponse> Data { get; set; }

    }
    public class ApiArrayResponseModel<TResponse>
        where TResponse : IApiResponseData, new()
    {
        public ApiResponseMetadata Metadata { get; set; }
        public IEnumerable<TResponse> Data { get; set; }
    }
}
