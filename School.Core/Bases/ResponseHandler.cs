using Microsoft.Extensions.Localization;
using School.Core.SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Bases
{

    public class ResponseHandler
    {
        private IStringLocalizer<Resource> _localizer;
        public ResponseHandler(IStringLocalizer<Resource> localizer)
        {
            _localizer = localizer;
        }
        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer[ResourceKeys.Deleted]
            };
        }
        public Response<T> Success<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer[ResourceKeys.Created],
                Meta = Meta
            };
        }
        public Response<T> EditSuccess<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer[ResourceKeys.Updated],
                Meta = Meta
            };
        }
        public Response<T> Success<T>(T entity,string message, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message,
                Meta = Meta
            };
        }
        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = _localizer[ResourceKeys.UnAuthorized],
            };
        }
        public Response<T> BadRequest<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? _localizer[ResourceKeys.BadRequest] : Message
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? _localizer[ResourceKeys.BadRequest] : message
            };
        }

        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = _localizer[ResourceKeys.Created],
                Meta = Meta
            };
        }

        public Response<T> UnprocessableEntity<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message == null ? _localizer[ResourceKeys.UnprocessableEntity] : message
            };
        }
    }


}
