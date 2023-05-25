using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.UAPI;

namespace Proyecto.MVC.Controllers
{
    public class PlatosController : Controller
    {
        private Crud<Modelos.Plato> platos = new Crud<Modelos.Plato>();
        private string Url = "https://localhost:7192/api/Platos";

        // GET: PlatosController
        public ActionResult Index()
        {
            var datos = platos.Select(Url);
            return View(datos);
        }

        // GET: PlatosController/Details/5
        public ActionResult Details(int id)
        {
            var datos = platos.SelectById(Url, id);
            return View(datos);
        }

        // GET: PlatosController/Create
        public ActionResult Create()
        {
            var restaurantes = new Crud<Modelos.Restaurante>().Select(Url.Replace("Platos", "Restaurantes"))
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Nombre
                })
                .ToList();
            ViewBag.restaurantes = restaurantes;
            return View();
        }

        // POST: PlatosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelos.Plato datos)
        {
            try
            {
                platos.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: PlatosController/Edit/5
        public ActionResult Edit(int id)
        {
            var restaurantes = new Crud<Modelos.Restaurante>().Select(Url.Replace("Platos", "Restaurantes"))
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Nombre
                })
                .ToList();
            ViewBag.restaurantes = restaurantes;
            var datos = platos.SelectById(Url, id);
            return View(datos);
        }

        // POST: PlatosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Modelos.Plato datos)
        {
            try
            {
                platos.Update(Url, id, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: PlatosController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = platos.SelectById(Url, id);
            return View(datos);
        }

        // POST: PlatosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Modelos.Plato datos)
        {
            try
            {
                platos.Delete(Url, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
