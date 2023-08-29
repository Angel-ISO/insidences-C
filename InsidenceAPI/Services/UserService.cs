/* using Dominio;
using Dominio.Interfaces;
using InsidenceAPI.Dtos;
using InsidenceAPI.Helpers;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aplicacion.Contratos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace InsidenceAPI.Services;

    public class UserService : IUserService
    {
        private readonly JWT _jwt;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _PasswordHasher;
        private readonly  IJwtGenerator _jwtGenerator;

        public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt, 
        IPasswordHasher<User> passwordHasher, IJwtGenerator jwtGenerator)
        {
            _unitOfWork = unitOfWork;
            _jwt = jwt.Value;
            _PasswordHasher = passwordHasher;
            _JwtGenerator = jwtGenerator;

        } 
        public async Task<String> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                Name_User = registerDto.UserName,
                Email = registerDto.Email,
            };

            user.Password = _PasswordHasher.HashPassword(user, registerDto.Password);

            var userExists = _unitOfWork .Users.Find(u => u.Name_User == Autorizacion.Rol_PorDefecto.ToString())
            .First();

            if (userExists == null)
        {  
            var RolPorDefecto = _unitOfWork .Rols.Find(e => e.Name_Rol == Autorizacion.Rol_PorDefecto.ToString()).First();
            try 
            {
                user.Rols.Add(RolPorDefecto);
                _unitOfWork .Users.Add(user);
                await _unitOfWork.SaveAsync();
                
                return $"el usuario {registerDto.UserName} ha sido creado exitosamente";
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
         }
            else{
                return $"el usuario {registerDto.UserName} ya fue registrado en la base de datos";
            }

        }

          public async Task<string> AddRoleAsync(AddRoleDto model)
    {
        var usuario = await _unitOfWork.Users
                    .GetByUserNameAsync(model.UserName);
        if (usuario == null)
        {
            return $"No existe algún usuario registrado con la cuenta {model.UserName}.";
        }
        var resultado = _PasswordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);
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
        return $"Credenciales incorrectas para el usuario {usuario.Name_User}.";
    }


            public async Task<DatosUsuarioDto> GetTokenAsync(LoginDto model)
    {
        DatosUsuarioDto datosUsuarioDto = new DatosUsuarioDto();
        var usuario = await _unitOfWork.Users
                    .GetByUserNameAsync(model.UserName);
        if (usuario == null)
        {
            datosUsuarioDto.EstaAutenticado = false;
            datosUsuarioDto.Mensaje = $"No existe ningún usuario con el username {model.UserName}.";
            return datosUsuarioDto;
        }

        var result = _PasswordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);
        if (result == PasswordVerificationResult.Success)
        {

            datosUsuarioDto.Mensaje = "Ok";
            datosUsuarioDto.EstaAutenticado = true;
            datosUsuarioDto.UserName = usuario.Name_User;
            datosUsuarioDto.Email = usuario.Name_User;
            datosUsuarioDto.Token = _jwtGenerador.CrearToken(usuario);
            return datosUsuarioDto;

        }
        datosUsuarioDto.EstaAutenticado = false;
        datosUsuarioDto.Mensaje = $"Credenciales incorrectas para el usuario {usuario.Name_User}.";
        return datosUsuarioDto;

    }


    }

 */