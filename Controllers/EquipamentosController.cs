using DepositoComputadores.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoComputadores.Controllers
{
    public class EquipamentosController : Controller
    {
        private readonly Contexto db;
        public EquipamentosController(Contexto contexto)
        {
            db = contexto;
        }

        public ActionResult Index(string texto, string tipoPesquisa)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return View(db.EQUIPAMENTOS.ToList());
            }
            else if (tipoPesquisa == "Todos")
            {
                return View(db.EQUIPAMENTOS.Where(a => a.Descricao.Contains(texto) || a.Local.Descricao.Contains(texto) ));
            }
            else
            {
                return View(db.EQUIPAMENTOS.ToList());
            }
            
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Equipamento dadosTela)
        {
            db.EQUIPAMENTOS.Add(dadosTela);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Edit(int id)
        {
            return View(db.EQUIPAMENTOS.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Equipamento dadosTela)
        {
            db.EQUIPAMENTOS.Update(dadosTela);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {
            db.EQUIPAMENTOS.Remove(db.EQUIPAMENTOS.Find(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
