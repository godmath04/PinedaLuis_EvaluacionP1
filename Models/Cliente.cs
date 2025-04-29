using System.ComponentModel.DataAnnotations;

namespace PinedaLuis_EvaluacionP1.Models
{
    public class Cliente
    {
        [Key]
        public string Identificacion { get; set; }

        [Required]
        public int Edad { get; set; }

        public bool estado { get; set; }

        public float Presupuesto { get; set; }

        public DateOnly FechaNacimiento { get; set; }


        public string elaboradoPor { 
            get
            {
                return "Luis Pineda";
            }
        }



    }
}
