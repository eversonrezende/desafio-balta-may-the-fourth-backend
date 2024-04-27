namespace MayTheFourth.Core.Contexts.SharedContext.UseCases;

public class Response
{
    public string? Message { get; set; } = string.Empty;
    public int Status { get; set; }
    public bool IsSuccess => Status is >= 200 and <= 299;
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
}
