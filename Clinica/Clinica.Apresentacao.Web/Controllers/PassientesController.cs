using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinica.Dominio.Entidades;
using Clinica.Infra.Dados.Contexto;
using Clinica.Infra.Dados.Repositorios;

namespace Clinica.Apresentacao.Web.Controllers
{
    public class PassientesController : Controller
    {
        private PassienteRepositorio _repositorio = new PassienteRepositorio();

        // GET: Passientes
        public ActionResult Index()
        {
            return View(_repositorio.BuscarTudo());
        }

        // GET: Passientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passiente passiente = _repositorio.BuscarPor((int)id);
            if (passiente == null)
            {
                return HttpNotFound();
            }
            return View(passiente);
        }

        // GET: Passientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Telefone,RG,CPF,Endereco")] Passiente passiente)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(passiente);
                
                return RedirectToAction("Index");
            }

            return View(passiente);
        }

        // GET: Passientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passiente passiente = _repositorio.BuscarPor((int)id);
            if (passiente == null)
            {
                return HttpNotFound();
            }
            return View(passiente);
        }

        // POST: Passientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Telefone,RG,CPF,Endereco")] Passiente passiente)
        {
            Passiente passienteBuscado = _repositorio.BuscarPor(passiente.Id);
            passienteBuscado.Nome = passiente.Nome;
            passienteBuscado.RG = passiente.RG;
            passienteBuscado.CPF = passiente.CPF;
            passienteBuscado.Endereco = passiente.Endereco;
            passienteBuscado.Telefone = passiente.Telefone;

            if (ModelState.IsValid)
            {
                _repositorio.Editar(passienteBuscado);
                
                return RedirectToAction("Index");
            }
            return View(passiente);
        }

        // GET: Passientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passiente passiente = _repositorio.BuscarPor((int)id);
            if (passiente == null)
            {
                return HttpNotFound();
            }
            return View(passiente);
        }

        // POST: Passientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Passiente passiente = _repositorio.BuscarPor(id);
            _repositorio.Deletar(passiente);
            
            return RedirectToAction("Index");
        }

      
    }
}
