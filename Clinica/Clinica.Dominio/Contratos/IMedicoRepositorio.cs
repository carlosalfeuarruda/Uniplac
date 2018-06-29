using Clinica.Dominio.Entidades;

namespace Clinica.Dominio.Contratos
{
	public interface IMedicoRepositorio : IRepositorio<Medico>
	{
		Medico BuscarPorNome(string nome);
	}
}