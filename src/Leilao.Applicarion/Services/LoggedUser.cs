using Leilao.Applicarion.Entities;
using Leilao.Applicarion.Repositories.Contracts;
using Microsoft.AspNetCore.Http;

namespace Leilao.Applicarion.Services
{
    public class LoggedUser : ILoggedUser
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;
        public LoggedUser(IHttpContextAccessor httpContext, IUserRepository userRepository)
        {
            _contextAccessor = httpContext;
            _userRepository = userRepository;
        }
        public User User()
        {
            var token = TokenOnRequest();
            var email = FronBase64String(token);
            return _userRepository.GetUserByEmail(email);
        }

        private string TokenOnRequest()
        {
            var authentication = _contextAccessor.HttpContext!.Request.Headers["Authorization"].ToString();
            return authentication["Bearer ".Length..];
        }

        private string FronBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }





}
