using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContato.Model
{
    public class Contato
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }

        public override string ToString(){
        	return "id: " + id "nome: " + nome "telefone: " + telefone;
        } 
    }
}
