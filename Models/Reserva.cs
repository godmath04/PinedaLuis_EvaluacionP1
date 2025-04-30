using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PinedaLuis_EvaluacionP1.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        [Required]
        public DateTime FechaEntrada { get; set; }
        [Required]
        public DateTime FechaSalida { get; set; }

        [NotMapped]
        public int ValorPago
        {
            //Se considera que cada día de reserva cuesta 20
            get { return (int)(FechaSalida - FechaEntrada).TotalDays * 20; }
        }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente? Cliente { get; set; }

    }
}
