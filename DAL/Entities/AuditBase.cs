using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves_2024II.DAL.Entities
{
    public class AuditBase
    {
        [Key] //Primary key
        [Required] //Campo obligatorio
        public virtual Guid Id { get; set; } //Este será el PK de todas las tablas
        public virtual DateTime? CreatedDate { get; set; }//Fecha de creacion de cada registro
        public virtual DateTime? ModifiedDate { get; set; }//Fechas del cambio de cada registro
    }
}
