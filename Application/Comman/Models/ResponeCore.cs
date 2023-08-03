using System.Net;

namespace Application.Comman.Models;

public class ResponseCore<T>
{
    public ResponseCore()
    {

    }
    public ResponseCore(bool isSuccess, ICollection<string> Errors)
    {
        this.Errors = Errors;
        this.IsSuccess = isSuccess;
    }
    public ResponseCore(bool isSuccess, T Result)
    {
        IsSuccess = isSuccess;
        this.Result = Result;
    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public bool IsSuccess { get; set; } = true;
    public ICollection<string>? Errors { get; set; }
    public T? Result { get; set; }

}

