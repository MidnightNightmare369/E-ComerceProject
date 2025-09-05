namespace Orders.Share.Responses;

public class ActionResponse<T>
{
    public bool WasSuccess { get; set; }
    public T? Result { get; set; }
    public string? Message { get; set; }
}