using System.Threading.Tasks;
using Thucook.EntityFramework;
using Thucook.Main.ApiService.Models;

namespace Thucook.Main.ApiService
{
    public interface IJwtService
    {
        string GenerateJwt(User user, Location location);
    }
}
