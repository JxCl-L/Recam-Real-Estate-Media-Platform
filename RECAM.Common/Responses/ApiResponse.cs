

namespace RECAM.Common.Responses;

public class ApiResponse<T>
{
    public bool Success { get; set; }

    public int Code { get; set; }

    public string Message { get; set; } = string.Empty; // avoid null string 

    public T? Data { get; set; } // T is the error 



    public static ApiResponse<T> Ok(T data, string message = "ok")
    {
        return new ApiResponse<T>
        {
            Success = true,
            Code = 200,
            Message = message,
            Data = data
        };
    }

    public static ApiResponse<T> Fail(int code, string message)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Code = code,
            Message = message
        };
    }



}
