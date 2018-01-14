using Microsoft.AspNetCore.Mvc;
using AspNetCore.Domain.Interfaces.Repositories;
using AutoMapper;
using System.Collections.Generic;
using AspNetCore.Domain.Entities;
using AspNetCore.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AspNetCore.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IRepositoryProduto _repositoryProduto;
        private readonly IRepositoryCategoria _repositoryCategoria;
        private readonly IMapper _mapper;

        public ProdutoController(IRepositoryProduto repositoryProduto, IRepositoryCategoria repositoryCategoria,
            IMapper mapper)
        {
            this._repositoryProduto = repositoryProduto;
            this._repositoryCategoria = repositoryCategoria;
            this._mapper = mapper;
        }

        // GET: Produto
        public IActionResult Index()
        {
            var produtosViewModel =
                _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_repositoryProduto.GetAll());

            var categorias = _repositoryCategoria.GetAll().ToList();
            categorias.Add(new Categoria { Descricao = "Todas" });
            ViewData["Categorias"] = new SelectList(categorias.OrderBy(c => c.Id), "Id", "Descricao");
            return View(produtosViewModel);
        }

        // GET: Produto/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(_repositoryProduto.GetById(id.Value));
            return View(produtoViewModel);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_repositoryCategoria.GetAll(), "Id", "Descricao");
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<ProdutoViewModel, Produto>(produto);
                _repositoryProduto.Add(produtoDomain);
                return RedirectToAction("Index");
            }

            ViewData["CategoriaId"] = new SelectList(_repositoryCategoria.GetAll(), "Id", "Descricao");
            return View(produto);
        }

        // GET: Produto/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(_repositoryProduto.GetById(id.Value));
            ViewData["CategoriaId"] = new SelectList(_repositoryCategoria.GetAll(), "Id", "Descricao");
            return View(produtoViewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProdutoViewModel produto)
        {
            if (id != produto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<ProdutoViewModel, Produto>(produto);
                _repositoryProduto.Update(produtoDomain);
                return RedirectToAction("Index");
            }

            ViewData["CategoriaId"] = new SelectList(_repositoryCategoria.GetAll(), "Id", "Descricao");
            return View(produto);
        }

        // GET: Produto/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(_repositoryProduto.GetById(id.Value));
            return View(produtoViewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var produto = _repositoryProduto.GetById(id.Value);
            _repositoryProduto.Remove(produto);
            return RedirectToAction("Index");
        }

        // GET: Produto/search?categoria=5&descricao=th
        [HttpGet]
        public JsonResult Search(int categoria, string descricao)
        {
            IEnumerable<Produto> produtos;
            produtos = categoria != 0 
                ? _repositoryProduto.PesquisarPorDescricaoECategoria(descricao, categoria) 
                : _repositoryProduto.PesquisarPorDescricao(descricao);

            var produtosViewModel =
                _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtos);
            return Json(produtosViewModel);
        }
    }
}