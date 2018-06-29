using Clinica.Dominio.Entidades;

namespace Clinica.Dominio.Contratos
{
	public interface IPassienteRepositorio : IRepositorio<Passiente>
	{
		Passiente BuscarPorTelefone(string nome);
	}
}