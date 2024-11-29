using ShoppingAPI_Jueves_2024II.DAL.Entities;

namespace ShoppingAPI_Jueves_2024II.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;
        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        //Se crea método llamado SeederAsync
        //Este método es una especie de MAIN()
        //Tiene la responsabilidad de prepoblar las diferentes tablas de DB
        public async Task SeederAsync()
        {
            //Primero se agrega un método propio de EF que gace lsas veces de 'update-database'
            //En otras palabras es un método que creará la BD inmediatamente se ponga la API en ejecución
            await _context.Database.EnsureCreatedAsync();

            //A partir de aquí se crean métodos para prepoblar la BD
            await PopulateCountriesAsync();

            await _context.SaveChangesAsync();
        }


        #region Private Methos
        private async Task PopulateCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"
                        },
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"
                        }
                    }
                });
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Buenos Aires"
                        }
                    }
                });
            }

        }

        #endregion
    }
}
