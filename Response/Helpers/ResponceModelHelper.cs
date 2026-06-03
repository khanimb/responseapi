namespace Response.Helpers
{
    public class ResponceModelHelper
    {
        public static ResponceModel<T> CreateSuccessResponse<T>(T data)
        {
            return new ResponceModel<T>
            {
                Data = data,
                Errors = null,
                Success = true
            };
        }
        public static ResponceModel<T> CreateErrorResponse<T>(List<string> errors)
        {
            return new ResponceModel<T>
            {
                Data = default(T),
                Errors = errors,
                Success = false
            };
        }
    }
}
