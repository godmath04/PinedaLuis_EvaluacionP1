using System.ComponentModel.DataAnnotations;

namespace PinedaLuis_EvaluacionP1.Models
{
    public class Cliente
    {
        [Key]
        [MaxLength(10, ErrorMessage = "La identificación no puede exceder los 10 caracteres.")]
        public string Identificacion { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }


        [Required]
        public DateOnly FechaNacimiento { get; set; }


        [Required]
        [Range(18,100, ErrorMessage = "Debes ser mayor de 18 años para reservar")]
        public int Edad { get; set; }

        [Required]
        public bool Individual { get; set; }

        [Required]
        [Display(Name = "Presupuesto Referencial")]
        public float Presupuesto { get; set; }

        public string elaboradoPor { 
            get
            {
                return "Luis Pineda";
            }
        }



    }
}
