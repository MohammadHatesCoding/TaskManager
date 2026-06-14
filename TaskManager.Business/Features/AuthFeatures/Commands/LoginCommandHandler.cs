using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;
    private readonly IJWTService _jWTService;
    private readonly ITokenService _tokenService;
    public LoginCommandHandler(IUnitOfWork unitOfWork, IPasswordService passwordService, IJWTService jWTService, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _passwordService = passwordService;
        _jWTService = jWTService;
        _tokenService = tokenService;
    }
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _unitOfWork.UserRepository
                .Find(x => x.Username.ToLower() == request.command.Username.ToLower());

            if (user == null || !user.IsActive)
                throw new UnauthorizedAccessException();

            var IsValid = _passwordService.VerifyPassword(user.PasswordHash, request.command.Password);

            if (!IsValid)
                throw new UnauthorizedAccessException("Invalid credentials");

            var oldTokens = await _unitOfWork.RefreshTokenRepository.GetAllActiveTokensByUserId(user.Id);

            foreach (var oldToken in oldTokens)
                oldToken.IsRevoked = true;

            var accessToken = _jWTService.GenerateAccessToken(user);

            var rawRefreshToken = _jWTService.GenerateRefreshToken();

            var hashedRefreshToken = _tokenService.Hash(rawRefreshToken);

            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = hashedRefreshToken,
                UserId = user.Id
            };

            await _unitOfWork.RefreshTokenRepository.CreateAsync(refreshTokenEntity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new LoginResponse(AccessToken: accessToken, RefreshToken: rawRefreshToken, AccessTokenExpiresAt: DateTime.UtcNow.AddMinutes(30));
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}