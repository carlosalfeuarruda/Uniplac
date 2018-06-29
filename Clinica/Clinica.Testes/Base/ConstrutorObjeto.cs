using System;
using Clinica.Dominio;
using Clinica.Dominio.Entidades;

namespace Clinica.Testes.Base
{
	class ConstrutorObjeto
	{
		public static Medico CriarMedico()
		{
			return new Medico
			{
				Id = 1,
				Nome = "João Teste",
				Telefone = "5549999821850",
				CRM = "465456465465454",
				TipoEspecializacao = TipoEspecializacao.Cardiologia,
				RG = "46917416846",
				CPF = "085522633452",
				Endereco = new Endereco
				{
					Numero = "261",
					Logradouro = "Av. Castelo Branco",
					Bairro = "Universitário",
					Localidade = "Lages",
					Uf = "SC",
					Cep = "88 987 876",
					Complemento = ""
				},
			};

		}

		internal static Passiente CriarPassiente()
		{
			return new Passiente
			{
				Id = 1,
				Nome = "João Teste",
				Telefone = "5549999821850",
				RG = "46917416846",
				CPF = "085522633452",
				Endereco = new Endereco
				{
					Numero = "261",
					Logradouro = "Av. Castelo Branco",
					Bairro = "Universitário",
					Localidade = "Lages",
					Uf = "SC",
					Cep = "88 987 876",
					Complemento = ""
				},
			};
		}

		internal static Consulta CriarConsulta()
		{
			return new Consulta
			{
				Id = 1,
				DataConsulta = DateTime.Now,
				Id_Medico = 1,
				Id_Passiente = 2,
				Observacoes = "LALALALALALALA"
			};
		}
	}
}
