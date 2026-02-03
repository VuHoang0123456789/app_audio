namespace ApiGateway.Entities;

public class Client
{
    public int Id { get; set; }
    public string ClientId { get; set; }
    public virtual ICollection<ClientSecret> ClientSecrets { get; set; }
}
