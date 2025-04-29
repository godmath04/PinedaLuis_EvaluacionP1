using System.ComponentModel.DataAnnotations.Schema;

namespace PinedaLuis_EvaluacionP1.Models
{
    public class Reserva
    {
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }

        public int ValorPago
        {
            //Se considera que cada día de reserva cuesta 20
            get { return (int)(FechaSalida - FechaEntrada).TotalDays * 20; }
        }

        public string ClienteIdentificacion { get; set; }
        [ForeignKey("ClienteIdentificacion")]
        public Cliente? Cliente { get; set; }

    }
}
