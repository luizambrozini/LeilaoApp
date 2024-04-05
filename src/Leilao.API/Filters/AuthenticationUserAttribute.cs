using Leilao.Applicarion.Repositories;
using Leilao.Applicarion.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Leilao.API.Filters
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IUserRepository _userRepository;
        public AuthenticationUserAttribute(IUserRepository userRepository) => _userRepository = userRepository;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context.HttpContext);
                var email = FronBase64String(token);
                var exist = _userRepository.ExisteUserWithEmail(email);
                if (exist == false)
                {
                    context.Result = new UnauthorizedObjectResult("Email not valid.");
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private String TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();
            if (string.IsNullOrEmpty(authentication))
            {
                throw new Exception("Token is not present.");
            }
            return authentication["Bearer ".Length..];
        }

        private String FronBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
