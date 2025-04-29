using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PinedaLuis_EvaluacionP1.Models
{
    public class PlanRecompensa
    {

        [Key]
        public int IdRecompensa { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }


        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Los puntos no pueden ser negativos")]
        public int PuntosAcumulados { get; set; }

        [DisplayName("SILVER o GOLD")]
        [RegularExpression("^(SILVER|GOLD)$", ErrorMessage = "Tipo debe ser SILVER o GOLD")]
        public string TipoRecompensa { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }

    }
}
