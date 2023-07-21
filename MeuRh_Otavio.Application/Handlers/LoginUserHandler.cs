using MediatR;
using MeuRh_Otavio.Application.Commands;
using MeuRh_Otavio.Application.Interfaces;
using MeuRh_Otavio.Domain.Interfaces;

namespace MeuRh_Otavio.Application.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginUserHandler(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Obtenha o usuário pelo e-mail e verifique a senha
            var user = await _userRepository.GetByEmail(request.Email);
            if (user == null || !VerifyPasswordHash(request.Password, user.PasswordHash))
            {
                return null; // Autenticação inválida
            }

            // Gere um token JWT válido para o usuário autenticado
            var token = _jwtService.GenerateToken(user.Id.ToString(), user.Email);

            return token;
        }

        private bool VerifyPasswordHash(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
