namespace GestionGym.Modelos
{
    public class Cliente
    {
        public int proceso { get; set; }

        public int clienteID { get; set; }
        public string nombreCompleto { get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }

        public DateTime fechaDeIncripcion { get; set; }
        public DateTime fechaDeVencimiento { get; set; }
        public int estado { get; set; }

    }
}
