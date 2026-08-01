using Services;
using System.Collections.Generic;
namespace DVLD_BusinessLogicLayer
{
    public class OperationResult<T> where T : class, new()
    {
        public enResult Result { get; private set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess => Result == enResult.rSuccess;
        internal static OperationResult<T> Success(T data, string message = null) =>
        new OperationResult<T> { Result = enResult.rSuccess, Data = data, Message = message };
        internal static OperationResult<T> Failure(enResult result, string message = "") =>
            new OperationResult<T> { Result = result, Message = message };
        internal static OperationResult<T> FailureDBAError(enResult result) =>
            new OperationResult<T> { Result = result, Message = "Data base access error." };

    }
    public class OperationResults<T> where T : class, new()
    {
        public enResult Result { get; private set; }
        public List<T> DataList { get; set; }
        public string Message { get; set; }
        public bool IsSuccess => Result == enResult.rSuccess;
        internal static OperationResults<T> Success(List<T> DataList, string message = null) =>
        new OperationResults<T> { Result = enResult.rSuccess, DataList = DataList, Message = message };
        internal static OperationResults<T> Failure(enResult result, string message = "") =>
            new OperationResults<T> { Result = result, Message = message };
        internal static OperationResults<T> FailureDBAError(enResult result) =>
            new OperationResults<T> { Result = result, Message = "Data base access error." };

    }
}
