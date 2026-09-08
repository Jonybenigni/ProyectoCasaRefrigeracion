using Refrigeracion.Abstactions;

namespace Refrigeracion.WebApi.Configurations
{
    public class TokenParameters : ITokensParameters
    {
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IList<string>? Roles { get; set; }
    }
}
