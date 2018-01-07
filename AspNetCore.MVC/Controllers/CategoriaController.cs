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

        // GET: Categoria
        public IActionResult Index()
        {
            var categorias = _repositoryCategoria.GetAll();
            return View(categorias);
        }

        // GET: Categoria/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var categoria = _repositoryCategoria.GetById(id.Value);
            if (categoria == null)
                ViewData["msg"] = "Categoria não encontrada";

            return View(categoria);
        }

        // POST: Categoria/Edit
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

        // GET: Categoria/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var categoria = _repositoryCategoria.GetById(id.Value);
            if (categoria == null)
                ViewData["msg"] = "Categoria não encontrada";
            return View(categoria);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
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

        // GET: Categoria/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var categoria = _repositoryCategoria.GetById(id.Value);
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var categoria = _repositoryCategoria.GetById(id.Value);
            _repositoryCategoria.Remove(categoria);
            return RedirectToAction("Index");
        }

        // GET: Categoria/search?descricao=th
        //public IActionResult Search(string descricao)
        //{
        //    var categorias = _repositoryCategoria.ListarPorDescricao(descricao);
        //    return View("Index", categorias);
        //}

        //GET: Categoria/search? descricao = th
        [HttpGet]
        public JsonResult Search(string descricao)
        {
            return Json(_repositoryCategoria.ListarPorDescricao(descricao));
        }
    }
}