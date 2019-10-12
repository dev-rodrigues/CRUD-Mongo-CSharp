using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMongo.Model
{
    public class Contato
    {
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int Tipo { get; set; }

        public Contato(string email, string telefone, int tipo)
        {
            this.Email = email;
            this.Telefone = telefone;
            this.Tipo = tipo;
        }

        public Contato()
        {

        }
    }
}
