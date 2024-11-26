using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2024II.DAL.Entities;

namespace ShoppingAPI_Jueves_2024II.DAL
{
    public class DataBaseContext:DbContext
    {
        //Así me conecto a la Db por medio de este constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
            
        }

        //Este metodo es propio de EF Core me sirve para configurar unos indices de cada campo de una tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); //Aquí creo un indice del campo Name para la tabla countries
            modelBuilder.Entity<State>().HasIndex("Name","CountryId").IsUnique();//Haciendo un índice compuesto
        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        

        #endregion
    }
}
