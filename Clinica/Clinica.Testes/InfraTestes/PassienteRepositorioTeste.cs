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
	public class PassienteRepositorioTeste
	{
		private ClinicaContexto _contextoTeste;
		private PassienteRepositorio _repositorio;
		private Passiente _passienteTest;


		[TestInitialize]
		public void Inicializador()
		{
			//AQUI ELE APAGA A BASE ANTIGA E CARREGA NOVAMENTE OS DADOS NO BANCO
			Database.SetInitializer(new InicializadorBanco<ClinicaContexto>());

			//AQUI ELE ADICIONA AS REGRAS DE CRIAÇÃO DO BANCO 
			_contextoTeste = new ClinicaContexto();

			//AQUI ELE ADICIONA OS MÉTODOS DE CRUD
			_repositorio = new PassienteRepositorio();

			//AQUI ELE ADICIONA UM PRODUTO
			_passienteTest = ConstrutorObjeto.CriarPassiente();

			//??????
			_contextoTeste.Database.Initialize(true);
		}

		[TestMethod]
		public void Deveria_adicionar_um_novo_passiente()
		{
			//Preparação
			//Ação
			_repositorio.Adicionar(_passienteTest);
			//Afirmar
			var todosPassientes = _contextoTeste.Passientes.ToList();
			Assert.AreEqual(3, todosPassientes.Count);
		}

		[TestMethod]
		public void Deveria_editar_um_passiente()
		{
			//Preparação
			var passienteEditado = _contextoTeste.Passientes.Find(1);
			passienteEditado.Nome = "EDITADO";
			//Ação
			_repositorio.Editar(passienteEditado);
			//Afirmar
			var passienteBuscado = _contextoTeste.Passientes.Find(1);
			Assert.AreEqual("EDITADO", passienteBuscado.Nome);
		}

		[TestMethod]
		public void Deveria_deletar_um_passiente()
		{
			//Preparação
			var passienteDeletado = _contextoTeste.Passientes.Find(1);
			//Ação
			_repositorio.Deletar(passienteDeletado);
			//Afirmar
			var todosPassientes = _contextoTeste.Passientes.ToList();
			Assert.AreEqual(1, todosPassientes.Count);
		}

		[TestMethod]
		public void Deveria_buscar_passiente_por_id()
		{
			//Preparação
			//Ação
			var passienteBuscado = _repositorio.BuscarPor(1);
			//Afirmar
			Assert.IsNotNull(passienteBuscado);
		}

		[TestMethod]
		public void Deveria_buscar_todos_os_passiente()
		{
			//Preparação
			//Ação
			var passienteBuscado = _repositorio.BuscarTudo();
			//Afirmar
			Assert.IsNotNull(passienteBuscado);
		}

		[TestMethod]
		public void Deveria_buscar_passiente_por_telefone()
		{
			//Preparação
			//Ação
			var medicoBuscado = _repositorio.BuscarPorTelefone("1111111111");
			//Afirmar
			Assert.IsNotNull(medicoBuscado);
		}
	}
}
