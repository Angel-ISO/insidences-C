namespace InsidenceAPI.Dtos;

    public class DatosUsuarioDto
    {
        public string Mensaje { get; set; }
        public bool EstaAutenticado { get; set; }
        public string UserName { get; set; }
         public List<string>  Rols { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
