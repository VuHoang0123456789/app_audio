namespace ApiGateway.Entities;

public class ClientSecret
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string Value { get; set; }
    public int ClientId { get; set; }
    public virtual Client Client { get; set; }
}
