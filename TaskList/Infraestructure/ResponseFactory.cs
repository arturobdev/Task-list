using Microsoft.AspNetCore.Mvc;

namespace TaskList.Infraestructure
{
    public class ResponseFactory
    {
        public static IActionResult CreateSuccessResponse(int StatusCode, object? ErrorMessage)
        {
            var response = new ApiSuccessResponse()
            {
                Status = StatusCode,
                Data = ErrorMessage
            };
            return new ObjectResult(response)
            {
                StatusCode = StatusCode
            };
        }

        public static IActionResult CreateErrorResponse(int StatusCode, params string[] errors) 
        {
            var response = new ApiErrorResponse()
            {
                Status = StatusCode,
                Error = new List<ApiErrorResponse.ResponseError>()
            };

            foreach (var error in errors)
            {
                response.Error.Add(new ApiErrorResponse.ResponseError()
                {
                    Error = error
                });
            }

            return new ObjectResult(response)
            {
                StatusCode = StatusCode,
            };
        }
    }

}