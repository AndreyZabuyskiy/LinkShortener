using DataAccess.Repository;
using LinkShortener.BusinessLogic.Dtos;
using LinkShortener.BusinessLogic.Dtos.Request;
using LinkShortener.BusinessLogic.Dtos.Response;
using LinkShortener.BusinessLogic.UseCases;
using LinkShortener.DataAccess.Entities.Request;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BusinessLogic.Services;

public class AuthService : IRegisterUser, ILoginUser, IGetUser
{
    private string _secureKey = "TBWq2ePoc9RWzueO8fsi2lQ55dvM8IOr";
    private readonly IRepository _repository;

    public AuthService(IRepository repository)
    {
        _repository = repository;
    }

    public string Login(LoginDto loginData)
    {
        var user = _repository.GetByLogin(loginData.Login);

        if (user == null) return null;

        if (!BCrypt.Net.BCrypt.Verify(loginData.Password, user.Passport)) return null;

        return GenerateJwt(user.Id);
    }

    public UserReadDto Register(RegisterDto registerData)
    {
        var userModel = new UserCreateModel
        {
            Login = registerData.Login,
            Password = BCrypt.Net.BCrypt.HashPassword(registerData.Password)
        };

        var user = _repository.CreateUser(userModel);

        return new UserReadDto()
        {
            Id = user.Id,
            Login = user.Login
        };
    }

    private string GenerateJwt(Guid id)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secureKey));
        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var header = new JwtHeader(credentials);

        var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));
        var securityToken = new JwtSecurityToken(header, payload);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    private JwtSecurityToken Verify(string jwt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secureKey);
        tokenHandler.ValidateToken(jwt, new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false
        }, out SecurityToken validatedToken);

        return (JwtSecurityToken) validatedToken;
    }

    public UserReadDto GetUser(string jwt)
    {
        var token = Verify(jwt);
        var userId = Guid.Parse(token.Issuer);
        var user = _repository.GetById(userId);

        return new UserReadDto()
        {
            Id = user.Id,
            Login = user.Login
        };
    }
}