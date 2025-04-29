using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PinedaLuis_EvaluacionP1.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage ="Su identificacion es obligatoria")]
        [MaxLength(10, ErrorMessage = "La identificación no puede exceder los 10 caracteres.")]
        public string Identificacion { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "El presupuesto debe ser positivo")]
        [Display(Name = "Presupuesto Referencial")]
        public decimal Presupuesto { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [Range(18,100, ErrorMessage = "La edad debe ser mayor a 18 años")]
        public int Edad { get; set; }

        [Required]
        //Este sirve para saber si viene solo o acompanado
        public bool Individual { get; set; }

        [NotMapped]
        public string elaboradoPor => "Luis Pineda";

        //Relacion con las recompensas
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
        public PlanRecompensa PlanRecompensa { get; set; }



    }
}
