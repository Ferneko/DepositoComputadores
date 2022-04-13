using DepositoComputadores.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoComputadores.Models
{
    public class EquipamentoViewModel : Equipamento
    {
        public List<Local> TodosLocais { get; set; }
    }
}
