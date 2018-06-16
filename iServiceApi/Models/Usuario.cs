using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iServiceApi.Models
{
    public class Usuario
    {
        public Usuario(long Id, int PermissionLevel, int IsTecnico, string Email, string Nome, string Telefone) {
            this.Id = Id;
            this.PermissionLevel = PermissionLevel;
            this.Email = Email;
            this.Nome = Nome;
            this.Telefone = Telefone;
        }

        [Key]
        public long Id { get; set; }

        public int PermissionLevel { get; set; }

        public int IsTecnico { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Rua { get; set; }

        public string Complemento { get; set; }

        public string HashAuth { get; set; }

        public class TokenConfigurations
        {
            public string Audience { get; set; }
            public string Issuer { get; set; }
            public int Seconds { get; set; }
        }

    }
}
