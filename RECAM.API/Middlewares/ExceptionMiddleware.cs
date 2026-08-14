using System;
using RECAM.Common.Exceptions;
using RECAM.Common.Responses;
using System.Text.Json;

namespace RECAM.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next; // "下一个中间件"的函数指针

    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger)
    {
        _next = requestDelegate;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try // try/catch 包住 _next(...)，等于包住了下游所有代码
        {
            await _next(httpContext); // 把请求传给下游
        }
        catch (AppException ex)
        {
            await WriteResponseAsync(httpContext, ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal server error");
            await WriteResponseAsync(httpContext, 500, "Internal server error");
        }
    }

    private static async Task WriteResponseAsync(HttpContext httpContext, int statusCode, string message)
    {
        // res contain status, headers, body

        // 1. set status
        httpContext.Response.StatusCode = statusCode;

        // 2. set hearders content-type
        httpContext.Response.ContentType = "application/json";

        // 3. update res body
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        var apiResponse = ApiResponse<object>.Fail(statusCode, message);

        var json = JsonSerializer.Serialize(apiResponse, options);


        await httpContext.Response.WriteAsync(json);
        
    }
    

}
