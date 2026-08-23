using DVLD.BLL.Enums;
namespace DVLD.BLL.OperationResults
{
    public class OperationResult<T>
    {
        public ErrorCode Result { get; private set; }
        public T? Data { get; set; }
        public string? Message { get; set; } = string.Empty;
        public bool IsSuccess => Result == ErrorCode.None;
        internal static OperationResult<T> Success(T data, string? message = null) =>
        new OperationResult<T> { Result = ErrorCode.None, Data = data, Message = message };
        internal static OperationResult<T> Failure(ErrorCode result, string message = "") =>
            new OperationResult<T> { Result = result, Message = message };
        internal static OperationResult<T> FailureDBAError(ErrorCode result) =>
            new OperationResult<T> { Result = result, Message = "Data base access error." };

    }
    public class OperationResults<T> 
    {
        public ErrorCode Result { get; private set; }
        public List<T> DataList { get; set; } = new List<T>();
        public string? Message { get; set; } = string.Empty;
        public bool IsSuccess => Result == ErrorCode.None;
        internal static OperationResults<T> Success(List<T> DataList, string? message) =>
        new OperationResults<T> { Result = ErrorCode.None, DataList = DataList, Message = message };
        internal static OperationResults<T> Failure(ErrorCode result, string message = "") =>
            new OperationResults<T> { Result = result, Message = message };
        internal static OperationResults<T> FailureDBAError(ErrorCode result) =>
            new OperationResults<T> { Result = result, Message = "Data base access error." };

    }
}
