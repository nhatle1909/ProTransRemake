namespace Application.Common
{
    public class ServiceResponse<T>
    {
        private bool Success { get; set; } = false;
        private T? Result { get; set; }
        private string Message { get; set; }
        public void TryCatchResponse(Exception ex)
        {
            Success = false;
            Message = ex.Message;
        }
        public void Response(T result, bool success, string message)
        {
            Result = result;
            Success = success;
            Message = message;
        }

    }
}
