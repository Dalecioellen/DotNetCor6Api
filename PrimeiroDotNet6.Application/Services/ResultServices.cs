using FluentValidation.Results;

namespace PrimeiroDotNet6.Application.Services
{
    public class ResultServices
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Error { get; set; }

        public static ResultServices RequestError(string messege, ValidationResult validationResult)
        {
            return new ResultServices
            {
                IsSuccess = false,
                Message = messege,
                Error = validationResult.Errors.Select(e => new ErrorValidation { Field = e.PropertyName, Messege = e.ErrorMessage }).ToList(),


            };
        }

        public static ResultServices<T> RequestError<T>(string messege, ValidationResult validationResult)
        {
            return new ResultServices<T>
            {
                IsSuccess = false,
                Message = messege,
                Error = validationResult.Errors.Select(e => new ErrorValidation { Field = e.PropertyName, Messege = e.ErrorMessage }).ToList(),


            };
        }

        public static ResultServices Fail(string messege) => new ResultServices{ IsSuccess = false, Message = messege };

        public static ResultServices<T> Fail<T>(string messege) => new ResultServices<T> { IsSuccess = false, Message = messege };

        public static ResultServices<T> Ok<T>(T data) => new ResultServices<T> { IsSuccess = true, Data = data };

        public static ResultServices Ok(string messege) => new ResultServices { IsSuccess = false, Message = messege };
    }


    public class ResultServices<T> : ResultServices
    {
        public T Data { get; set; }
    }
}
