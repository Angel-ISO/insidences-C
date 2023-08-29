using InsidenceAPI.Dtos;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace InsidenceAPI.Services;

    public interface IUserService
    {
      Task <string> RegistrerAsync (RegisterDto model);
      Task <DatosUsuarioDto> GetTokenAsync (LoginDto model);
      Task <string> AddRoleAsync (AddRoleDto model);

    }
