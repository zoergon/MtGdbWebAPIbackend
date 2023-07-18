using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Services.Interfaces
{
    public interface IAuthenticateService
    {
        LoggedUser Authenticate(string username, string password);
    }
}
