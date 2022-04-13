using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoComputadores.Entidades
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string numeroPatrimonio { get; set; }
        public string Descricao { get; set; }
        public int LocalId { get; set; }
        public Local Local { get; set; }
    }
}
