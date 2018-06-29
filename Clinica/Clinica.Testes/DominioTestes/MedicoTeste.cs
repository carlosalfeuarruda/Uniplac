using Clinica.Dominio;
using Clinica.Dominio.Entidades;
using Clinica.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clinica.Testes.DominioTestes
{
	[TestClass]
	public class MedicoTeste
	{
		private Medico _medico;

		[TestInitialize]
		public void Inicializador()
		{
			_medico = ConstrutorObjeto.CriarMedico();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_um_primeiro_nome_valido()
		{
			_medico.Nome = "aaa";
			_medico.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_um_telefone_valido()
		{
			_medico.Telefone = "";
			_medico.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_um_CRM_valido()
		{
			_medico.CRM = "";
			_medico.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_um_tipo_especializacao_valido()
		{
			_medico.TipoEspecializacao = TipoEspecializacao.Cardiologia;
			_medico.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_um_rg_valido()
		{
			var _medico = ConstrutorObjeto.CriarMedico();
			_medico.RG = "";
			_medico.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_um_CPF_valido()
		{
			_medico.CPF = "45454";
			_medico.Validar();
		}
		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_um_bairro_valido()
		{
			_medico.Endereco.Bairro = "";
			_medico.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_um_cep_valido()
		{
			_medico.Endereco.Cep = "";
			_medico.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_um_complemento_valido()
		{
			_medico.Endereco.Complemento = "";
			_medico.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_uma_localidade_valida()
		{
			_medico.Endereco.Localidade = "";
			_medico.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_um_logradouro_valido()
		{
			_medico.Endereco.Logradouro = "";
			_medico.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void Medico_deve_ter_um_numero_valido()
		{
			_medico.Endereco.Numero = "";
			_medico.Validar();
		}

		[TestMethod]
		[ExpectedException(typeof(DominioException))]
		public void PMedico_deve_ter_uma_uf_valida()
		{
			_medico.Endereco.Uf = "";
			_medico.Validar();
		}
	}
}
