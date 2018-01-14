using Microsoft.AspNetCore.Mvc;
using AspNetCore.Domain.Interfaces.Repositories;
using AspNetCore.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;
using AspNetCore.MVC.ViewModels;

namespace AspNetCore.MVC.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IRepositoryCategoria _repositoryCategoria;
        private readonly IMapper _mapper;

        public CategoriaController(IRepositoryCategoria repositoryCategoria, IMapper mapper)
        {
            this._repositoryCategoria = repositoryCategoria;
            this._mapper = mapper;
        }

        // GET: Categoria
        public IActionResult Index()
        {
            var categoriasViewModel =
                _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_repositoryCategoria.GetAll());
            return View(categoriasViewModel);
        }

        // GET: Categoria/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var categoriaViewModel =
                _mapper.Map<Categoria, CategoriaViewModel>(_repositoryCategoria.GetById(id.Value));
            if (categoriaViewModel == null)
                ViewData["msg"] = "Categoria não encontrada";

            return View(categoriaViewModel);
        }

        // POST: Categoria/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoriaViewModel categoria)
        {
            if (ModelState.IsValid)
            {
                var categoriaDomain = _mapper.Map<CategoriaViewModel, Categoria>(categoria);
                _repositoryCategoria.Update(categoriaDomain);
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

            var categoriaViewModel =
                _mapper.Map<Categoria, CategoriaViewModel>(_repositoryCategoria.GetById(id.Value));
            if (categoriaViewModel == null)
                ViewData["msg"] = "Categoria não encontrada";
            return View(categoriaViewModel);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaViewModel categoria)
        {
            if (ModelState.IsValid)
            {
                var categoriaDomain = _mapper.Map<CategoriaViewModel, Categoria>(categoria);
                _repositoryCategoria.Add(categoriaDomain);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Categoria/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var categoriaViewModel =
                _mapper.Map<Categoria, CategoriaViewModel>(_repositoryCategoria.GetById(id.Value));
            return View(categoriaViewModel);
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

        //GET: Categoria/search?descricao=th
        [HttpGet]
        public JsonResult Search(string descricao)
        {
            return Json(_repositoryCategoria.ListarPorDescricao(descricao));
        }
    }
}