using Clinica.Dominio.Entidades;
using Clinica.Infra.Dados.Contexto;
using Clinica.Infra.Dados.Repositorios;
using Clinica.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;

namespace Clinica.Testes.InfraTestes
{

	[TestClass]
	public class ConsultaoRepositorioTeste
	{
		private ClinicaContexto _contextoTeste;
		private ConsultaRepositorio _repositorio;
		private Consulta _consultaTest;


		[TestInitialize]
		public void Inicializador()
		{
			//AQUI ELE APAGA A BASE ANTIGA E CARREGA NOVAMENTE OS DADOS NO BANCO
			Database.SetInitializer(new InicializadorBanco<ClinicaContexto>());

			//AQUI ELE ADICIONA AS REGRAS DE CRIAÇÃO DO BANCO 
			_contextoTeste = new ClinicaContexto();

			//AQUI ELE ADICIONA OS MÉTODOS DE CRUD
			_repositorio = new ConsultaRepositorio();

			//AQUI ELE ADICIONA UM PRODUTO
			_consultaTest = ConstrutorObjeto.CriarConsulta();

			//??????
			_contextoTeste.Database.Initialize(true);
		}

		[TestMethod]
		public void Deveria_adicionar_uma_nova_consulta()
		{
			//Preparação
			//Ação
			_repositorio.Adicionar(_consultaTest);
			//Afirmar
			var todasConsultas = _contextoTeste.Consultas.ToList();
			Assert.AreEqual(3, todasConsultas.Count);
		}

		[TestMethod]
		public void Deveria_editar_uma_consulta()
		{
			//Preparação
			var consultaEditada = _contextoTeste.Consultas.Find(1);
			consultaEditada.Id_Medico = 39;

			//Ação
			_repositorio.Editar(consultaEditada);

			//Afirmar
			var consultaBuscada = _contextoTeste.Consultas.Find(1);

			Assert.AreEqual(39, consultaBuscada.Id_Medico);
		}

		[TestMethod]
		public void Deveria_deletar_uma_consulta()
		{
			//Preparação
			var consultaDeletada = _contextoTeste.Consultas.Find(1);

			//Ação
			_repositorio.Deletar(consultaDeletada);

			//Afirmar
			var todasConsultas = _contextoTeste.Consultas.ToList();

			Assert.AreEqual(1, todasConsultas.Count);
		}

		[TestMethod]
		public void Deveria_buscar_consulta_por_id()
		{

			//Preparação

			//Ação
			var consultaBuscada = _repositorio.BuscarPor(1);

			//Afirmar

			Assert.IsNotNull(consultaBuscada);
		}

		[TestMethod]
		public void Deveria_buscar_todas_as_consultas()
		{
			//Preparação
			//Ação
			var consultaBuscada = _repositorio.BuscarTudo();
			//Afirmar
			Assert.IsNotNull(consultaBuscada);
		}
	}
}
