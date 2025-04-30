using MediatR;
using Refit;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;
namespace UdemyMicroservice.Shared
{
    public interface IRequestByServiceResult<T> : IRequest<ServiceResult<T>>;
    public interface IRequestByServiceResult : IRequest<ServiceResult>;
    
    public class ServiceResult
    {

        [JsonIgnore] public HttpStatusCode Status { get; set; }
        public ProblemDetails? Fail { get; set; }
        [JsonIgnore] public bool IsSuccess => Fail is null;
        [JsonIgnore] public bool IsFail => !IsSuccess;

        // static factory methods
        public static ServiceResult SuccessAsNoContent()
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.NoContent
            };
        }
        public static ServiceResult ErrorAsNotFound()
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.NotFound,
                Fail = new ProblemDetails
                {
                    Title = "Not Found",
                    Detail = "The requested resource was not found."
                }
            };
        }

        public static ServiceResult Error(ProblemDetails problemDetails, HttpStatusCode status)
        {
            return new ServiceResult
            {
                Status = status,
                Fail = problemDetails
            };
        }
        public static ServiceResult Error(string title, string detail, HttpStatusCode status)
        {
            return new ServiceResult
            {
                Status = status,
                Fail = new ProblemDetails
                {
                    Title = title,
                    Detail = detail,
                }
            };
        }
        public static ServiceResult Error(string title, HttpStatusCode status)
        {
            return new ServiceResult
            {
                Status = status,
                Fail = new ProblemDetails
                {
                    Title = title,
                }
            };
        }

        public static ServiceResult ErrorFromProblemDetails(ApiException exception)
        {
            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult
                {
                    Fail = new ProblemDetails
                    {
                        Title = exception.Message,
                        Detail = exception.Content
                    },
                    Status = exception.StatusCode,
                };
            }
            else
            {
                var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(exception.Content, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });

                return new ServiceResult
                {
                    Status = exception.StatusCode,
                    Fail = problemDetails
                };
            }
        }
        public static ServiceResult ErrorFromValidation(IDictionary<string, object> errors)
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails()
                {
                    Title = "Validation errors occured",
                    Detail = "Please check the errors property for more details",
                    Extensions = errors,
                }
            };
        }
    }


    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }
        [JsonIgnore] public string? UrlAsCreated { get; set; }
        // 200
        public static ServiceResult<T> SuccessAsOk(T data)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.OK,
                Data = data
            };
        }
        // 201 => Created => responses body header => location => api/v1/...
        public static ServiceResult<T> SuccessAsCreated(T data, string url)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.Created,
                Data = data,
                UrlAsCreated = url
            };
        }

        public new static ServiceResult<T> Error(ProblemDetails problemDetails,HttpStatusCode status)
        {
            return new ServiceResult<T>
            {
                Status = status,
                Fail = problemDetails
            };
        }
        public new static ServiceResult<T> Error(string title, string detail,HttpStatusCode status)
        {
            return new ServiceResult<T>
            {
                Status = status,
                Fail = new ProblemDetails
                {
                    Title = title,
                    Detail = detail,
                    Status = (int)status
                }
            };
        }
        public new static ServiceResult<T> Error(string title,  HttpStatusCode status)
        {
            return new ServiceResult<T>
            {
                Status = status,
                Fail = new ProblemDetails
                {
                    Title = title,
                    Status = (int)status
                }
            };
        }

        public new static ServiceResult<T> ErrorFromProblemDetails(ApiException exception)
        {
            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult<T>
                {
                    Fail = new ProblemDetails
                    {
                        Title = exception.Message,
                        Detail = exception.Content
                    },
                    Status = exception.StatusCode,
                };
            }
            else
            {
                var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(exception.Content, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });

                return new ServiceResult<T>
                {
                    Status = exception.StatusCode,
                    Fail = problemDetails
                };
            }
        }
        public new static ServiceResult<T> ErrorFromValidation(IDictionary<string,object> errors)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails()
                {
                    Title = "Validation errors occured",
                    Detail = "Please check the errors property for more details",
                    Extensions = errors,
                    Status = HttpStatusCode.BadRequest.GetHashCode()
                }
            };
        }
    }
}
