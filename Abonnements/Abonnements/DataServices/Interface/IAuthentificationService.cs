using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abonnements.DataServices.Interface
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }

        Task<bool> LoginAsync(string userMail, string password);

        Task LogoutAsync();

        int GetCurrentUserId();
    }
}
