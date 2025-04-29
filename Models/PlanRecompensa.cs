using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PinedaLuis_EvaluacionP1.Models
{
    public class PlanRecompensa
    {

        [Key]
        public int IdRecompensa { get; set; }

        [Required]
        public int Nombre { get; set; }
        public DateTime FechaInicio { get; set; }

        public string ClienteRecompensado { get; set; }
        [ForeignKey("ClienteRecompensado")]
        public Cliente? Cliente { get; set; }

    }
}
