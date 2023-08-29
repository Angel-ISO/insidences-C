using Dominio;
using Dominio.Interfaces;
using InsidenceAPI.Dtos;
using InsidenceAPI.Helpers;
using Microsoft.AspNetCore.Identity;

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
            var user await _unitOfWork.Users.GetByNameUserAsync(model.UserName);
            if (user == null)
            {
                return $"no existe en la base de datos el usuario regitrado como: {model.UserName}";
            }
            var resultado = _PasswordHasher.VerifyHashedPassword(user , user.Password, model.Password);
            if (resultado == PasswordVerificationResult.Success)
            {
                var RolExist = _unitOfWork .Rols.Find(l => l.Name_Rol.ToLower() == model.Role.ToLower()).FirstOrDefault();


                 if (RolExist != null )
            {
                var userHaveRol = user.Roks.Any(u => u.Id == RolExist.Id);
            }
            }
           
        }


    }

