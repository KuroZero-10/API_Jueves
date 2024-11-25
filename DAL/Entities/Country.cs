using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves_2024II.DAL.Entities
{
    public class Country:AuditBase
    {
        [Display(Name="País")] //Para identificar el nombre mas facil
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50,ErrorMessage ="El campo {0} debe tener maximo {1} caracteres")]
        public string Name { get; set; }

    }
}
