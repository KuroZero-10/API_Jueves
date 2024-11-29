using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves_2024II.DAL.Entities
{
    public class State:AuditBase
    {
        [Display(Name="Estado/Departamento")]
        [MaxLength(50,ErrorMessage ="El campo {0} debe tener máximo {1} caracteres")]
        public string Name { get; set; }

        //Así se relaciona dos tablas con EF Core
        [Display(Name = "País")]
        public Country? country { get; set; }

        //FK
        [Display(Name = "Id País")]
        public Guid CountryId { get; set; }
    }
}
