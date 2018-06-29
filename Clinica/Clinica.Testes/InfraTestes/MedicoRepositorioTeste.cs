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
	public class MedicoRepositorioTeste
	{
		private ClinicaContexto _contextoTeste;
		private MedicoRepositorio _repositorio;
		private Medico _medicoTest;


		[TestInitialize]
		public void Inicializador()
		{
			//AQUI ELE APAGA A BASE ANTIGA E CARREGA NOVAMENTE OS DADOS NO BANCO
			Database.SetInitializer(new InicializadorBanco<ClinicaContexto>());

			//AQUI ELE ADICIONA AS REGRAS DE CRIAÇÃO DO BANCO 
			_contextoTeste = new ClinicaContexto();

			//AQUI ELE ADICIONA OS MÉTODOS DE CRUD
			_repositorio = new MedicoRepositorio();

			//AQUI ELE ADICIONA UM PRODUTO
			_medicoTest = ConstrutorObjeto.CriarMedico();

			//??????
			_contextoTeste.Database.Initialize(true);
		}

		[TestMethod]
		public void Deveria_adicionar_um_novo_medico()
		{
			//Preparação
			//Ação
			_repositorio.Adicionar(_medicoTest);
			//Afirmar
			var todosMedicos = _contextoTeste.Medicos.ToList();
			Assert.AreEqual(3, todosMedicos.Count);
		}

		[TestMethod]
		public void Deveria_editar_um_medico()
		{
			//Preparação
			var medicoEditado = _contextoTeste.Medicos.Find(1);
			medicoEditado.Nome = "EDITADO";

			//Ação
			_repositorio.Editar(medicoEditado);

			//Afirmar
			var medicoBuscado = _contextoTeste.Medicos.Find(1);

			Assert.AreEqual("EDITADO", medicoBuscado.Nome);
		}

		[TestMethod]
		public void Deveria_deletar_um_medico()
		{
			//Preparação
			var medicoDeletado = _contextoTeste.Medicos.Find(1);

			//Ação
			_repositorio.Deletar(medicoDeletado);

			//Afirmar
			var todosMedicos = _contextoTeste.Medicos.ToList();

			Assert.AreEqual(1, todosMedicos.Count);
		}

		[TestMethod]
		public void Deveria_buscar_medico_por_id()
		{

			//Preparação

			//Ação
			var medicoBuscado = _repositorio.BuscarPor(1);

			//Afirmar

			Assert.IsNotNull(medicoBuscado);
		}

		[TestMethod]
		public void Deveria_buscar_todos_os_medicos()
		{
			//Preparação

			//Ação
			var medicoBuscado = _repositorio.BuscarTudo();

			//Afirmar

			Assert.IsNotNull(medicoBuscado);
		}

		[TestMethod]
		public void Deveria_buscar_medico_por_nome()
		{
			//Preparação

			//Ação
			var medicoBuscado = _repositorio.BuscarPorNome("Meu Médico Teste");

			//Afirmar

			Assert.IsNotNull(medicoBuscado);
		}
	}
}
