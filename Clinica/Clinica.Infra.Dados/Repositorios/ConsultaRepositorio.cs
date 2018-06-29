using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Clinica.Dominio.Contratos;
using Clinica.Dominio.Entidades;
using Clinica.Infra.Dados.Contexto;

namespace Clinica.Infra.Dados.Repositorios
{
	public class ConsultaRepositorio : IConsultaRepositorio
	{
		public ClinicaContexto _contexto;

		public ConsultaRepositorio()
		{
			_contexto = new ClinicaContexto();
		}

		public void Adicionar(Consulta entidade)
		{
			DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

			if (dbEntityEntry.State == EntityState.Detached)
			{
				_contexto.Consultas.Attach(entidade);
			}

			_contexto.Consultas.Add(entidade);

			_contexto.SaveChanges();
		}

		public Consulta BuscarPor(int id)
		{
			return _contexto.Consultas.Find(id);
		}

		public List<Consulta> BuscarTudo()
		{
			return _contexto.Consultas.ToList();
		}

		public void Deletar(Consulta entidade)
		{
			DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

			if (dbEntityEntry.State == EntityState.Detached)
			{
				_contexto.Consultas.Attach(entidade);
			}

			_contexto.Consultas.Remove(entidade);

			_contexto.SaveChanges();
		}

		public void Editar(Consulta entidade)
		{
			DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

			if (dbEntityEntry.State == EntityState.Detached)
			{
				_contexto.Consultas.Attach(entidade);
			}

			_contexto.SaveChanges();
		}

	}
}