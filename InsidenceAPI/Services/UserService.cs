using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InsidenceAPI.Dtos;
using InsidenceAPI.Helpers;
using Dominio;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using InsidenceAPI.Services;

namespace API.Services;
public class UserService : IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt, IPasswordHasher<User> passwordHasher)
    {
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> RegistrerAsync(RegisterDto registerDto)
    {
        var usuario = new User
        {
            Email = registerDto.Email,
            Name_User = registerDto.UserName,

        };

        usuario.Password = _passwordHasher.HashPassword(usuario, registerDto.Password);

        var usuarioExiste = _unitOfWork.Users
                                            .Find(u => u.Name_User.ToLower() == registerDto.UserName.ToLower())
                                            .FirstOrDefault();

        if (usuarioExiste == null)
        {
            /* var rolPredeterminado = _unitOfWork.Rols
                                                 .Find(u => u.Name_Rol == Autorizacion.Rol_PorDefecto.ToString())
                                                 .First();*/
            try
            {
                //usuario.Rols.Add(rolPredeterminado);
                _unitOfWork.Users.Add(usuario);
                await _unitOfWork.SaveAsync();

                return $"El Usuario {registerDto.UserName} ha sido registrado exitosamente";
            }

            catch (Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
        }
        else
        {

            return $"El usuario con {registerDto.UserName} ya se encuentra resgistrado.";
        }

    }

    public async Task<string> AddRoleAsync(AddRoleDto model)
    {
        var usuario = await _unitOfWork.Users
                                                .GetByUserNameAsync(model.UserName);

        if (usuario == null)
        {
            return $"No existe algun usuario registrado con la cuenta olvido algun caracter?{model.UserName}.";
        }

        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);

        if (resultado == PasswordVerificationResult.Success)
        {
            var rolExiste = _unitOfWork.Rols
                                            .Find(u => u.Name_Rol.ToLower() == model.Role.ToLower())
                                            .FirstOrDefault();

            if (rolExiste != null)
            {
                var usuarioTieneRol = usuario.Rols
                                                .Any(u => u.Id == rolExiste.Id);

                if (usuarioTieneRol == false)
                {
                    usuario.Rols.Add(rolExiste);
                    _unitOfWork.Users.Update(usuario);
                    await _unitOfWork.SaveAsync();
                }

                return $"Rol {model.Role} agregado a la cuenta {model.UserName} de forma exitosa.";
            }

            return $"Rol {model.Role} no encontrado.";
        }

        return $"Credenciales incorrectas para el ususario {usuario.Name_User}.";
    }




    public async Task<DatosUsuarioDto> GetTokenAsync(LoginDto model)
    {
        DatosUsuarioDto datosUsuarioDto = new DatosUsuarioDto();
        var usuario = await _unitOfWork.Users
                                                    .GetByUserNameAsync(model.UserName);

        if (usuario == null)
        {
            datosUsuarioDto.EstaAutenticado = false;
            datosUsuarioDto.Mensaje = $"No existe ningun usuario con el username {model.UserName}.";
            return datosUsuarioDto;
        }

        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);
        if (result == PasswordVerificationResult.Success)
        {
            datosUsuarioDto.Mensaje = "OK";
            datosUsuarioDto.EstaAutenticado = true;
            if (usuario != null && usuario != null)
            {
                JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
                datosUsuarioDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                datosUsuarioDto.UserName = usuario.Name_User;
                datosUsuarioDto.Email = usuario.Email;
                datosUsuarioDto.Rols = usuario.Rols
                                                    .Select(p => p.Name_Rol)
                                                    .ToList();


                return datosUsuarioDto;
            }
            else
            {
                datosUsuarioDto.EstaAutenticado = false;
                datosUsuarioDto.Mensaje = $"Credenciales incorrectas para el usuario {usuario.Name_User}.";

                return datosUsuarioDto;
            }
        }

        datosUsuarioDto.EstaAutenticado = false;
        datosUsuarioDto.Mensaje = $"Credenciales incorrectas para el usuario {usuario.Name_User}.";

        return datosUsuarioDto;

    }

    private JwtSecurityToken CreateJwtToken(User usuario)
    {
        var roles = usuario.Rols;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.Name_Rol));
        }
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Name_User),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", usuario.Id.ToString())
        }
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        Console.WriteLine("", symmetricSecurityKey);

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var JwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);

        return JwtSecurityToken;
    }

    /*public async Task<LoginDto>  UserLogin(LoginDto model)
    {
        var usuario = await _unitOfWork.Usuarios.GetByUsernameAsync(model.Username);
        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);

        if (resultado == PasswordVerificationResult.Success)
        {
            return model;
        }
        return null;
    }*/

}