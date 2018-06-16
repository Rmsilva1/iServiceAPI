using iServiceApi.Models;
using System.Linq;

namespace iServiceApi.Data
{
    public class DBInitializer
    {

        public static void Initialize(IServiceContext context)
        {
            context.Database.EnsureCreated();
            
            if (context.Usuarios.Any())
            {
                return;   // DB has been seeded
            }
            var usuarios = new Usuario[]
            {
                new Usuario{Id = 1, PermissionLevel = 1, IsTecnico = 1, Email = "rafael@hotmail.com", Nome = "Rafael", Telefone = "995779430" },
                new Usuario{Id = 2, PermissionLevel = 1, IsTecnico = 1, Email = "joao@hotmail.com", Nome = "Joao Pedro", Telefone = "123456789" },
                new Usuario{Id = 3, PermissionLevel = 1, IsTecnico = 1, Email = "thanos@hotmail.com", Nome = "Thanos", Telefone = "987654321" },
                new Usuario{Id = 4, PermissionLevel = 1, IsTecnico = 1, Email = "Maria@hotmail.com", Nome = "Maria da Massa", Telefone = "123456789" },
                new Usuario{Id = 5, PermissionLevel = 1, IsTecnico = 1, Email = "jhonny@hotmail.com", Nome = "Jhonny test", Telefone = "123456789"}
            };

            foreach (Usuario u in usuarios)
            {
                context.Usuarios.Add(u);
            }
            context.SaveChanges();   
        }
    }
}
