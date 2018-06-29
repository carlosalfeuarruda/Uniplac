using System;

namespace Clinica.Dominio.Entidades
{
	public class Consulta
	{
		public int Id { get; set; }
		public DateTime DataConsulta { get; set; }
		public int Id_Medico { get; set; }
		public int Id_Passiente { get; set; }
		public string Observacoes { get; set; }

		public Consulta()
		{
		}

		public void Validar()
		{
			if (DataConsulta == new DateTime(0001, 01, 01))
				throw new DominioException("Data consulta inválida!");
			if (String.IsNullOrWhiteSpace(Observacoes))
				throw new DominioException("Observação inválida!");
		}
	}
}

