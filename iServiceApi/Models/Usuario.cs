using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iServiceApi.Models
{
    public class Usuario
    {
        [Key]
        private long Id { get; set; }

        private int PermissionLevel { get; set; }

        private int IsTecnico { get; set; }

        private String Cpf { get; set; }

        private String Email { get; set; }

        private String Senha { get; set; }

        private String Nome { get; set; }

        private String Telefone { get; set; }

        private String Estado { get; set; }

        private String Cidade { get; set; }

        private String Cep { get; set; }

        private String Bairro { get; set; }

        private String Rua { get; set; }

        private String Complemento { get; set; }

    }
}
