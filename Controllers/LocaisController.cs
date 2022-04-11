using DepositoComputadores.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoComputadores.Controllers
{
    public class LocaisController : Controller
    {
        private readonly Contexto db;
        public LocaisController(Contexto contexto)
        {
            db = contexto;
        }

        public ActionResult Index(string texto, string tipoPesquisa)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return View(db.LOCAIS.ToList());
            }
            else if(tipoPesquisa == "Todos")
            {
                return View(db.LOCAIS.Where(a => a.Descricao.Contains(texto)));
            }
            else
            {
                return View(db.LOCAIS.ToList());
            }
            
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Local dadosTela)
        {
            db.LOCAIS.Add(dadosTela);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Edit(int id)
        {
            return View(db.LOCAIS.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Local dadosTela)
        {
            db.LOCAIS.Update(dadosTela);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
        public ActionResult Delete(int id)
        {
            db.LOCAIS.Remove(db.LOCAIS.Find(id));
            return RedirectToAction(nameof(Index));
        }

       
    }
}
