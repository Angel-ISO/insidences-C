using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aplicacion.Contratos;
using Dominio;
using Microsoft.IdentityModel.Tokens;

namespace Segurity.SegurityToken;

   public class JwtGenerator : IJwtGenerator
{
    public string CrearToken(User user)
    {
        var claims = new List<Claim>{
            new Claim(JwtRegisteredClaimNames.NameId, user.Name_User)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234$%&/()=?¡¡*¨[:_¨[:Ñ_*¡=(&$#!#%&/())?¡¡=)(/&//)==///)==((=_:[¨*]¡¡?)((?=)/&%$$##!%%&/()==?-,{,m+´¿'009696}))]]"));
        var credenciales = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
        var tokenDescripcion = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(15),
            SigningCredentials = credenciales
        };
        var tokenManejador = new JwtSecurityTokenHandler();
        var token = tokenManejador.CreateToken(tokenDescripcion);
        return tokenManejador.WriteToken(token);

    }
}