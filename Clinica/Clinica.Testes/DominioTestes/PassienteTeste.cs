using Clinica.Dominio;
using Clinica.Dominio.Entidades;
using Clinica.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clinica.Testes.DominioTestes
{
	[TestClass]
	public class PassienteTeste
	{
		private Passiente _passiente;

		[TestInitialize]
		public void Inicializador()
		{
			_passiente = ConstrutorObjeto.CriarPassiente();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Passiente_deve_ter_um_primeiro_nome_valido()
		{
			_passiente.Nome = "";
			_passiente.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Passiente_deve_ter_um_telefone_valido()
		{
			_passiente.Telefone = "";
			_passiente.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Passiente_deve_ter_um_rg_valido()
		{
			_passiente.RG = "";
			_passiente.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Passiente_deve_ter_um_CPF_valido()
		{
			_passiente.CPF = "";
			_passiente.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Passiente_deve_ter_um_bairro_valido()
		{
			_passiente.Endereco.Bairro = "";
			_passiente.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Passiente_deve_ter_um_cep_valido()
		{
			_passiente.Endereco.Cep = "";
			_passiente.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Passiente_deve_ter_um_complemento_valido()
		{
			_passiente.Endereco.Complemento = "";
			_passiente.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Passiente_deve_ter_uma_localidade_valida()
		{
			_passiente.Endereco.Localidade = "";
			_passiente.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Passiente_deve_ter_um_logradouro_valido()
		{
			_passiente.Endereco.Logradouro = "";
			_passiente.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Passiente_deve_ter_um_numero_valido()
		{
			_passiente.Endereco.Numero = "";
			_passiente.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Passiente_deve_ter_uma_uf_valida()
		{
			_passiente.Endereco.Uf = "";
			_passiente.Validar();
		}
	}
}
