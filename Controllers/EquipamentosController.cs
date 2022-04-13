using DepositoComputadores.Entidades;
using DepositoComputadores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                List<Equipamento> model = db.EQUIPAMENTOS.Include(a => a.Local).ToList();
                return View(model);
            }
            else if (tipoPesquisa == "Todos")
            {
                return View(db.EQUIPAMENTOS.Where(a => a.Descricao.Contains(texto) || a.Local.Descricao.Contains(texto) ).Include(a => a.Local));
            }
            else if (tipoPesquisa == "patrimonio")
            {
                return View(db.EQUIPAMENTOS.Where(a => a.numeroPatrimonio.Contains(texto) || a.Local.Descricao.Contains(texto)).Include(a => a.Local));
            }
            else if (tipoPesquisa == "descricao")
            {
                return View(db.EQUIPAMENTOS.Where(a => a.Local.Descricao.Contains(texto)).Include(a => a.Local));
            }
            else
            {
                return View(db.EQUIPAMENTOS.Include(a => a.Local).ToList());
            }
            
        }


        public ActionResult Create()
        {
            EquipamentoViewModel model = new EquipamentoViewModel();
            model.TodosLocais = db.LOCAIS.ToList();
            return View(model);
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
            ViewBag["locais"] = db.LOCAIS.ToList();
            return View(db.EQUIPAMENTOS.Where(a => a.Id == id).Include(a => a.Local).FirstOrDefault());
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
