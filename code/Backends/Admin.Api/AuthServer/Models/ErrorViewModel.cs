using Duende.IdentityServer.Models;

namespace AuthServer.Models;

public class ErrorViewModel
{
    public ErrorViewModel()
    {
    }

    public ErrorViewModel(string error)
    {
        Error = new ErrorMessage { Error = error };
    }

    public ErrorMessage Error { get; set; }
    public string urlReturn { get; set; }
}
