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
    public class MedicosController : Controller
    {
        private MedicoRepositorio _repositorio = new MedicoRepositorio();

        // GET: Medicos
        public ActionResult Index()
        {
            return View(_repositorio.BuscarTudo());
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = _repositorio.BuscarPor((int)id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Telefone,CRM,TipoEspecializacao,RG,CPF,Endereco")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(medico);
                
                return RedirectToAction("Index");
            }

            return View(medico);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = _repositorio.BuscarPor((int)id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Telefone,CRM,TipoEspecializacao,RG,CPF,Endereco")] Medico medico)
        {
            Medico medicoBuscado = _repositorio.BuscarPor(medico.Id);
            medicoBuscado.Nome = medico.Nome;
            medicoBuscado.RG = medico.RG;
            medicoBuscado.Telefone = medico.Telefone;
            medicoBuscado.TipoEspecializacao = medico.TipoEspecializacao;
            medicoBuscado.Endereco = medico.Endereco;
            medicoBuscado.CRM = medico.CRM;
            if (ModelState.IsValid)
            {
                _repositorio.Editar(medicoBuscado);
                
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = _repositorio.BuscarPor((int)id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = _repositorio.BuscarPor(id);
            _repositorio.Deletar(medico);
            
            return RedirectToAction("Index");
        }

       
    }
}
