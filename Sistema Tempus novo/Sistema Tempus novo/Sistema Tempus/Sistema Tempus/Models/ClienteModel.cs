using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Tempus.Models
{
    public class ClienteModel
    {
        public int MaiorDeIdade { get; set; }
        public int ClasseA { get; set; }
        public int ClasseB { get; set; }
        public int ClasseC { get; set; }
        public IEnumerable<Cliente> Geral { get; set; }
    }
}