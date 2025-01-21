using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PruebaIDT.Models.DTOs.Token;

namespace PruebaIDT.Service.JWT
{
    public class GenerateToken()
    {
        public TokenDto GenerateJwtToken(string rol)
        {
            #region Client
            var keyCliente = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("))6a=UU5c@zv4e1+lG<%<=:!8C|<<xf1C!ERv;[kr+VRB@bRJu!y|^X{@EM=:7eL!_0`-]5'gvG|'D:%1lweM@KC?gc49*)£k}*l"));
            var signingCredentialCliente = new SigningCredentials(keyCliente, SecurityAlgorithms.HmacSha512);

            List<Claim> claims = [];


            claims.Add(new Claim(ClaimTypes.Role, rol));

            JwtSecurityToken tokenCliente = new(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signingCredentialCliente
            );

            return new TokenDto() { Token = new JwtSecurityTokenHandler().WriteToken(tokenCliente) };
            #endregion
        }
    }
}
