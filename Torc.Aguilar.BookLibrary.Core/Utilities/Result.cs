using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torc.Aguilar.BookLibrary.Models
{
    public class Result<T>
    {
        public T Value { get; }
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }

        protected Result(T value, bool isSuccess, string errorMessage)
        {
            Value = value;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Success(T value) => new Result<T>(value, true, null);

        public static Result<T> Fail(string errorMessage) => new Result<T>(default(T), false, errorMessage);
    }

}
