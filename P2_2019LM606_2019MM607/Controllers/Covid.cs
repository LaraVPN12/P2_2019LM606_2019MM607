using Microsoft.AspNetCore.Mvc;
using P2_2019LM606_2019MM607.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace P2_2019LM606_2019MM607.Controllers
{
    public class Covid : Controller

    {
        private readonly dbContext _contexto;

        public Covid(dbContext miContexto)
        {
            this._contexto = miContexto;
        }

        public IActionResult Index()
        {
            IEnumerable<caso> casos = from c in _contexto.caso select c;


            return View(casos);
        }

        [HttpPost]
        public ActionResult NewPost(caso nuevoCaso)
        {
            var nuevo = new caso()
            {
                departamento = nuevoCaso.departamento,
                genero = nuevoCaso.genero,
                confirmados = nuevoCaso.confirmados,
                recuperados = nuevoCaso.recuperados,
                fallecidos = nuevoCaso.fallecidos
            };

            _contexto.caso.Add(nuevo);
            _contexto.SaveChanges();

            IEnumerable<caso> casos = from c in _contexto.caso select c;

            return RedirectToAction("Index", casos);
        }
    }
}
