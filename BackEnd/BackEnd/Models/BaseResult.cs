namespace BackEnd.Models
{
    public class BaseResult
    {
        public bool Success { set; get; }

        public List<string>? ErrorMessage { set; get; }

        public object? Data { get; set; }

        public int ErrorCode { get; set; }
    }
}
