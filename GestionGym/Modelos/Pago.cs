namespace GestionGym.Modelos
{
    public class Pago
    {
        public int proceso { get; set; }

        public int pagoID { get; set; }
        public string cedula { get; set; }
        public string tipo_membresia_nombre { get; set; }
       
        public string metodoPago { get; set; }

        public string concepto { get; set; }

        public string usuario { get; set; }
        public int estado { get; set; }
    }
}
