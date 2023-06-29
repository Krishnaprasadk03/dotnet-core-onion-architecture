using Microsoft.AspNetCore.Mvc;

namespace WebApi.Core
{
    public class CustomResult
    {
        public CustomResult(bool isValid,  string[]? errorMessages, object? data,int Code )
        {
            status = isValid;
            msg = errorMessages;
            result = data;
            code = Code;
        }
        public bool status { get; set; }
        public int code { get; set; }
        public string[]? msg { get; set; }
        public object? result { get; set; }
    }

    public class CustomActionResult : IActionResult
    {
        private readonly CustomResult _result;

        public CustomActionResult(bool isValid,  string[]? errorMessages, object? data,int code )
        {
            _result = new CustomResult(isValid, errorMessages, data,code );
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_result);
            return objectResult.ExecuteResultAsync(context);
        }
    }
}