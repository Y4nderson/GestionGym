namespace GestionGym.Modelos
{
    public class Usuario
    {

        public int proceso { get; set; }
        public int usuarioID { get; set; }
        public string usuario { get; set; }
        public string contrasenahash { get; set; }
        public string correoElectronico { get; set; }
        public string nombreCompleto { get; set; }
        public string rol { get; set; }
        public string permisos { get; set; }
        public int estado { get; set; }
        public DateTime fechaDeCreacion { get; set; }
        public DateTime ultimoAcceso { get; set; }


    }
}
