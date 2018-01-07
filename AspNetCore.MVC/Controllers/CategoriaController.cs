using Microsoft.AspNetCore.Mvc;
using AspNetCore.Domain.Interfaces.Repositories;
using AspNetCore.Domain.Entities;

namespace AspNetCore.MVC.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IRepositoryCategoria _repositoryCategoria;

        public CategoriaController(IRepositoryCategoria repositoryCategoria)
        {
            this._repositoryCategoria = repositoryCategoria;
        }

        public IActionResult Index()
        {
            var categorias = _repositoryCategoria.GetAll();
            return View(categorias);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var categoria = _repositoryCategoria.GetById(id.Value);
            if (categoria == null)
                ViewData["msg"] = "Categoria não encontrada";

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _repositoryCategoria.Update(categoria);
                return RedirectToAction("Index");
            }
            else
            {
                return View(categoria);
            }
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var categoria = _repositoryCategoria.GetById(id.Value);
            if (categoria == null)
                ViewData["msg"] = "Categoria não encontrada";
            return View(categoria);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _repositoryCategoria.Add(categoria);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var categoria = _repositoryCategoria.GetById(id.Value);
            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var categoria = _repositoryCategoria.GetById(id.Value);
            _repositoryCategoria.Remove(categoria);
            return RedirectToAction("Index");
        }
    }
}