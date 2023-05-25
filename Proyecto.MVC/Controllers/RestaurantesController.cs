using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.UAPI;

namespace Proyecto.MVC.Controllers
{
    public class RestaurantesController : Controller
    {
        private Crud<Modelos.Restaurante> restaurantes = new Crud<Modelos.Restaurante>();
        private string Url = "https://localhost:7192/api/Restaurantes";

        // GET: RestaurantesController
        public ActionResult Index()
        {
            var datos = restaurantes.Select(Url);
            return View(datos);
        }

        // GET: RestaurantesController/Details/5
        public ActionResult Details(int id)
        {
            var datos = restaurantes.SelectById(Url, id);
            return View(datos);
        }

        // GET: RestaurantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelos.Restaurante datos)
        {
            try
            {
                restaurantes.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: RestaurantesController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = restaurantes.SelectById(Url, id);
            return View(datos);
        }

        // POST: RestaurantesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Modelos.Restaurante datos)
        {
            try
            {
                restaurantes.Update(Url,id, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: RestaurantesController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = restaurantes.SelectById(Url, id);
            return View(datos);
        }

        // POST: RestaurantesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Modelos.Restaurante datos)
        {
            try
            {
                restaurantes.Delete(Url, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
