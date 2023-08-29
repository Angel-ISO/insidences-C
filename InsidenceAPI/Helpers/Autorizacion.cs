namespace InsidenceAPI.Helpers;

    public class Autorizacion
    {
        public enum Rols
        {
            Administrador,
            Gerente,
            Empleado,
            Camper
        }
        public const Rols Rol_PorDefecto = Rols.Empleado;
    }
