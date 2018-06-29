using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Clinica.Dominio.Contratos;
using Clinica.Dominio.Entidades;
using Clinica.Infra.Dados.Contexto;

namespace Clinica.Infra.Dados.Repositorios
{
	public class MedicoRepositorio : IMedicoRepositorio
	{
		public ClinicaContexto _contexto;

		public MedicoRepositorio()
		{
			_contexto = new ClinicaContexto();
		}

		public void Adicionar(Medico entidade)
		{
			DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

			if (dbEntityEntry.State == EntityState.Detached)
			{
				_contexto.Medicos.Attach(entidade);
			}

			_contexto.Medicos.Add(entidade);

			_contexto.SaveChanges();
		}

		public Medico BuscarPor(int id)
		{
			return _contexto.Medicos.Find(id);
		}

		public Medico BuscarPorNome(string nome)
		{
			return _contexto.Medicos
				.Where(p => p.Nome == nome)
				.FirstOrDefault();
		}

		public List<Medico> BuscarTudo()
		{
			return _contexto.Medicos.ToList();
		}

		public void Deletar(Medico entidade)
		{
			DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

			if (dbEntityEntry.State == EntityState.Detached)
			{
				_contexto.Medicos.Attach(entidade);
			}

			_contexto.Medicos.Remove(entidade);

			_contexto.SaveChanges();
		}

		public void Editar(Medico entidade)
		{
			DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

			if (dbEntityEntry.State == EntityState.Detached)
			{
				_contexto.Medicos.Attach(entidade);
			}

			_contexto.SaveChanges();
		}

	}
}