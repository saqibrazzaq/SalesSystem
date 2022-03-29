namespace products_api.Services
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "Service ran successfully.";
        public ServiceResponse<T> GetFailureResponse(string message)
        {
            return new ServiceResponse<T>
            {
                Success = false,
                Message = message,
                Data = default(T)
            };
        }
    }
}
