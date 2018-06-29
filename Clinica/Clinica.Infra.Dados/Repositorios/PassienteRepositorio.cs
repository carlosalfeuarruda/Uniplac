using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Clinica.Dominio.Contratos;
using Clinica.Dominio.Entidades;
using Clinica.Infra.Dados.Contexto;

namespace Clinica.Infra.Dados.Repositorios
{
	public class PassienteRepositorio : IPassienteRepositorio
	{
		public ClinicaContexto _contexto;

		public PassienteRepositorio()
		{
			_contexto = new ClinicaContexto();
		}

		public void Adicionar(Passiente entidade)
		{
			DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

			if (dbEntityEntry.State == EntityState.Detached)
			{
				_contexto.Passientes.Attach(entidade);
			}

			_contexto.Passientes.Add(entidade);

			_contexto.SaveChanges();
		}

		public void Adicionar(Medico entidade)
		{
			throw new System.NotImplementedException();
		}

		public Passiente BuscarPor(int id)
		{
			return _contexto.Passientes.Find(id);
		}

		public Passiente BuscarPorTelefone(string telefone)
		{
			return _contexto.Passientes
				.Where(p => p.Telefone == telefone)
				.FirstOrDefault();
		}

		public List<Passiente> BuscarTudo()
		{
			return _contexto.Passientes.ToList();
		}

		public void Deletar(Passiente entidade)
		{
			DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

			if (dbEntityEntry.State == EntityState.Detached)
			{
				_contexto.Passientes.Attach(entidade);
			}

			_contexto.Passientes.Remove(entidade);

			_contexto.SaveChanges();
		}

		public void Editar(Passiente entidade)
		{
			DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

			if (dbEntityEntry.State == EntityState.Detached)
			{
				_contexto.Passientes.Attach(entidade);
			}

			_contexto.SaveChanges();
		}

	}
}