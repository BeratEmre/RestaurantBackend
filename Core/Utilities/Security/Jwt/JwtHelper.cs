using Core.Entities.concrete;
using Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        TokenOptions _tokenOptions=new TokenOptions() ;
        DateTime _accesTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            var token =
            _tokenOptions.Audience = Configuration.GetSection("TokenOptions:Audience").Value;
            _tokenOptions.Issuer = Configuration.GetSection("TokenOptions:Issuer").Value;
            _tokenOptions.SecurityKey = Configuration.GetSection("TokenOptions:SecurityKey").Value;
            _tokenOptions.AccessTokenExpiretion = Convert.ToInt32(Configuration.GetSection("TokenOptions:AccessTokenExpiration").Value);
            _accesTokenExpiration = DateTime.Now.AddDays(_tokenOptions.AccessTokenExpiretion);

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials=new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwt = CreateJwtToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accesTokenExpiration,                
            };
        }
        public JwtSecurityToken CreateJwtToken(TokenOptions tokenOptions,User user,SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                expires: _accesTokenExpiration,
                notBefore:DateTime.Now,
                claims: SetClaims(user,operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim("firstName", user.FirstName));
            claims.Add(new Claim("id", user.Id.ToString()));
            claims.Add(new Claim("email", user.Email.ToString()));            
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }

        public List<OperationClaim> DecodeToken(string token)
        {
            ClaimsPrincipal claimsPrincipal = DecodeJwtToken(token);
            List<OperationClaim> claims = new List<OperationClaim>();
            if (claimsPrincipal != null)
            {                
                // Token decoded successfully
                // Access the claims from the claimsPrincipal.Claims collection
                foreach (Claim claim in claimsPrincipal.Claims.Where(x=>x.Type.IndexOf("role")!=-1))
                {
                    Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
                    claims.Add(new OperationClaim { Name = claim.Value });
                }

                foreach (Claim claim in claimsPrincipal.Claims)
                {
                    Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
                    //claims.Add(new OperationClaim { Name = claim.Value });
                }
            }
            return claims;
        }

        private ClaimsPrincipal DecodeJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true, // Set to false if you don't want to validate the token's signature
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey)),
                ValidateIssuer = true, // Set to false if you don't want to validate the token's issuer
                ValidIssuer = _tokenOptions.Issuer,
                ValidateAudience = true, // Set to false if you don't want to validate the token's audience
                ValidAudience = _tokenOptions.Audience,
                // Additional validation parameters if needed
            };

            try
            {
                // Validate and decode the token
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return claimsPrincipal;
            }
            catch (Exception ex)
            {
                // Token validation failed
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
