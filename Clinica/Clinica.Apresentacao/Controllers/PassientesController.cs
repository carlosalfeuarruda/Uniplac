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

namespace Clinica.Apresentacao.Controllers
{
    public class PassientesController : Controller
    {
        
        private PassienteRepositorio passienteRepositorio = new PassienteRepositorio();


        // GET: Passientes
        public ActionResult Index()
        {
            return View(passienteRepositorio.BuscarTudo());
        }

        // GET: Passientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passiente passiente = passienteRepositorio.BuscarPor((int)id);
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
                passienteRepositorio.Adicionar(passiente);
                
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
            Passiente passiente = passienteRepositorio.BuscarPor((int)id);
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
            Passiente passienteBuscado = passienteRepositorio.BuscarPor(passiente.Id);
            passienteBuscado.Nome = passiente.Nome;
            passienteBuscado.CPF = passiente.CPF;
            passienteBuscado.RG = passiente.RG;
            passienteBuscado.Telefone = passiente.Telefone;
            passienteBuscado.Endereco = passiente.Endereco;
           
            if (ModelState.IsValid)
            {
                passienteRepositorio.Editar(passienteBuscado);
                
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
            Passiente passiente = passienteRepositorio.BuscarPor((int)id);
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
            Passiente passiente = passienteRepositorio.BuscarPor(id);
            passienteRepositorio.Deletar(passiente);
            
            return RedirectToAction("Index");
        }

       
    }
}
