using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Specifications;
using Domain.Entities;
using Domain.Exceptions;
using Application.Models.DTOs;
using Application.Interfaces;
using Application.Core.Repositories;
using Application.Core.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Application.Core.Helpers;
using System.Runtime.ConstrainedExecution;

namespace Application.Services
{
    public class LoginService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;
        private readonly IEncryptionService _encryptionService;
        private readonly IConfiguration _config;
        public LoginService(IUnitOfWork unitOfWork, ILoggerService loggerService, IEncryptionService encryptionService, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
            _encryptionService = encryptionService;
            _config = configuration;
        }

        public async Task<TokenRes> LoginUser(TokenReq req)
        {
            var validateClientSpec = ClientMasterSpecifications.GetClientMasterSpec(req.ClientId);
            var Client = await _unitOfWork.Repository<Client>().FirstOrDefaultAsync(validateClientSpec) ?? throw new InActiveCleintException();
            var userSepc = UserSpecifications.GetUserSpec(req.UserName, _encryptionService.CreatePasswordHash(req.ClientId, "kspn23"));
            var User = await _unitOfWork.Repository<Users>().FirstOrDefaultAsync(userSepc) ?? throw new UserNotFoundException();
            var secretKey = "terp app jwt authentication secret key";
            //_config.GetSection("JWTSecretKey").Value;
            var token = TokenHelper.GenerateJwtToken(User.UserId.ToString(), secretKey, User.GrpCompId.ToString());
            var refreshToken = TokenHelper.GenerateRefreshToken();
            _ = _unitOfWork.Repository<RefreshToken>().AddAsync(new RefreshToken()
            {
                Id = Guid.NewGuid().ToString("n"),
                ProtectedTicket = refreshToken,
                Subject = User.UserId,
                ClientId = req.ClientId,
                FcmToken = "",
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddDays(5)
            });
            await _unitOfWork.SaveChangesAsync();

            var result = new TokenRes()
            {
                UserName = User.UserName,
                UserId = User.UserId,
                GrpComp=User.GrpCompId,
                Comp=User.CompId,
                Token= token,
                RefreshToken =refreshToken,
                IssuedUtc=DateTime.UtcNow,
                ExpiresUtc=DateTime.UtcNow.AddDays(5)
            };
           return result;
        }
    }
}