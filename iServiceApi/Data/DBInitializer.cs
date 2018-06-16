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
                new Usuario(1L,1,1,"rafael@hotmail.com","Rafael","995779430"){ },
                new Usuario(2L,1,1,"joao@hotmail.com","Joao Pedro","123456789"){ },
                new Usuario(3L,1,1,"thanos@hotmail.com","Thanos","987654321"){ },
                new Usuario(4L,1,1,"Maria@hotmail.com","Maria da Massa","123456789"){ },
                new Usuario(5L,1,1,"jhonny@hotmail.com","Jhonny test","123456789"){ }
            };

            foreach (Usuario u in usuarios)
            {
                context.Usuarios.Add(u);
            }
            context.SaveChanges();   
        }
    }
}
