using System.Threading.Tasks;
using KoohTajrobe.Business.Dto;

namespace KoohTajrobe.Business.Interfaces
{
    public interface IAuthenticationBusiness
    {
        Task Register(RegisterDto registerDto);
        Task Login(LoginDto loginDto);
        Task Logout();
    }
}