using Clinica.Dominio;
using Clinica.Dominio.Entidades;
using Clinica.Infra.Dados.Contexto;
using System;
using System.Data.Entity;

namespace Clinica.Testes.Base
{
	public class InicializadorBanco<T> : DropCreateDatabaseAlways<ClinicaContexto>
	{
		protected override void Seed(ClinicaContexto context)
		{
			// ----------- MÉDICO -----------

			//Cria médico
			Medico medico1 = new Medico();
			medico1.Nome = "Meu Médico Teste";
			medico1.Telefone = "4562196873";
			medico1.CRM = "4321231684";

			medico1.Endereco = new Endereco
			{
				Cep = "88509900",
				Logradouro = "Avenida Marechal Castelo Branco",
				Complemento = "170",
				Bairro = "Universitário",
				Localidade = "Lages",
				Uf = "SC",
				Numero = "123"
			};

			Medico medico2 = new Medico();
			medico2.Nome = "Meus Médico Teste 2";
			medico2.Telefone = "1111111111";
			medico2.CRM = "222222";

			medico2.Endereco = new Endereco
			{
				Cep = "88509900",
				Logradouro = "Avenida Marechal Castelo Branco",
				Complemento = "170",
				Bairro = "Universitário",
				Localidade = "Lages",
				Uf = "SC",
				Numero = "123"
			};

			//Adicionar no contexto
			context.Medicos.Add(medico1);
			context.Medicos.Add(medico2);

			// ----------- PASSIENTE -----------

			Passiente passiente1 = new Passiente();
			passiente1.Nome = "Meu Médico Teste";
			passiente1.Telefone = "4562196873";

			passiente1.Endereco = new Endereco
			{
				Cep = "88509900",
				Logradouro = "Avenida Marechal Castelo Branco",
				Complemento = "170",
				Bairro = "Universitário",
				Localidade = "Lages",
				Uf = "SC",
				Numero = "123"
			};

			Passiente passiente2 = new Passiente();
			passiente2.Nome = "Meus Médico Teste 2";
			passiente2.Telefone = "1111111111";

			passiente2.Endereco = new Endereco
			{
				Cep = "88509900",
				Logradouro = "Avenida Marechal Castelo Branco",
				Complemento = "170",
				Bairro = "Universitário",
				Localidade = "Lages",
				Uf = "SC",
				Numero = "123"
			};

			//Adicionar no contexto
			context.Passientes.Add(passiente1);
			context.Passientes.Add(passiente2);

			// ----------- CONSULTA -----------

			Consulta consulta1 = new Consulta();
			consulta1.DataConsulta = DateTime.Now;
			consulta1.Id_Medico = 1;
			consulta1.Id_Passiente = 2;
			consulta1.Observacoes = "LALALALALALALA";
			
			Consulta consulta2 = new Consulta();
			consulta2.DataConsulta = DateTime.Now;
			consulta2.Id_Medico = 1;
			consulta2.Id_Passiente = 2;
			consulta2.Observacoes = "TCHETCHETCHETCHE";

			//Adicionar no contexto
			context.Consultas.Add(consulta1);
			context.Consultas.Add(consulta2);

			//Salvar no contexto
			context.SaveChanges();
			base.Seed(context);
		}
	}
}
