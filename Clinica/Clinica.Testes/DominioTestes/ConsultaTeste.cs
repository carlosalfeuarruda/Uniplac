using Clinica.Dominio;
using Clinica.Dominio.Entidades;
using Clinica.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Clinica.Testes.DominioTestes
{
	[TestClass]
	public class ConsultaTeste
	{
		private Consulta _consulta;

		[TestInitialize]
		public void Inicializador()
		{
			_consulta = ConstrutorObjeto.CriarConsulta();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Consulta_deve_ter_uma_data_valida()
		{
			_consulta.DataConsulta = new DateTime(0001, 01, 01);
			_consulta.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Consulta_deve_ter_uma_observacao_valida()
		{
			_consulta.Observacoes = "";
			_consulta.Validar();
		}

	}
}
