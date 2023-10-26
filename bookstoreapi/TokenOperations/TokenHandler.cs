using System.IdentityModel.Tokens.Jwt;
using System.Text;
using bookstoreapi.Entities;
using bookstoreapi.TokenOperations.Models;
using Microsoft.IdentityModel.Tokens;

namespace bookstoreapi.TokenOperations
{
    public class TokenHandler
    {
        private readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Token CreateAccessToken(User user)
        {
            Token tokenModel= new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Token:SecurityKey")));
            SigningCredentials signingCredentials= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            tokenModel.Expiration= DateTime.Now.AddMinutes(15);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Auidience"],
                expires: tokenModel.Expiration,
                notBefore: DateTime.Now,
                signingCredentials:signingCredentials

            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            tokenModel.AccessToken= tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken= CreateRefreshToken();
        
            return tokenModel;
        } 
        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}