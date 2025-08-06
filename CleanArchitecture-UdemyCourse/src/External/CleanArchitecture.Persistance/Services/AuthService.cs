using AutoMapper;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> userManager;
    private readonly IMapper mapper;
    private readonly IJwtProvider jwtProvider;

    public AuthService(UserManager<User> userManager, IMapper mapper, IJwtProvider jwtProvider)
    {
        this.userManager = userManager;
        this.mapper = mapper;
        this.jwtProvider = jwtProvider;
    }

    public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        User user = await userManager.FindByIdAsync(request.UserId);

        if (user == null) 
            throw new Exception("kullanıcı bulunamadı");

        if (user.RefreshToken != request.RefreshToken) 
            throw new Exception("refresh token geçerli değil");

        if (user.RefreshTokenExpires < DateTime.Now)
            throw new Exception("Refresh token süresi dolmuş");
        
        LoginCommandResponse response = await jwtProvider.CreateTokenAsync(user);
        return response;
    }

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await userManager.Users.Where(p =>
            p.Email == request.UserNameOrEmail ||
            p.UserName == request.UserNameOrEmail).FirstOrDefaultAsync(cancellationToken);

        if (user == null) throw new Exception("Kullanici Bulunamadi");

        var result = await userManager.CheckPasswordAsync(user, request.Password);
        if(result)
        {
            LoginCommandResponse response = await jwtProvider.CreateTokenAsync(user);
            return response;
        }
        throw new Exception("Sifreyi yanlis girdiniz");
    }

    public async Task RegisterAsync(RegisterCommand request)
    {
        User user = mapper.Map<User>(request);
        IdentityResult result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
    }
}
