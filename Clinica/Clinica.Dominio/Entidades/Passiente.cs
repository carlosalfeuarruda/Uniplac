using Clinica.Dominio;
using System;

namespace Clinica.Dominio.Entidades
{
	public class Passiente
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Telefone { get; set; }
		public string RG { get; set; }
		public string CPF { get; set; }
		public Endereco Endereco { get; set; }

		public Passiente()
		{
		}

		public void Validar()
		{
			if (String.IsNullOrWhiteSpace(Nome))
				throw new DominioException("Nome inválido!");
			if (String.IsNullOrWhiteSpace(Telefone))
				throw new DominioException("Telefone inválido!");
			if (String.IsNullOrWhiteSpace(RG))
				throw new DominioException("RG inválido!");
			if (String.IsNullOrWhiteSpace(CPF))
				throw new DominioException("CPF inválido!");
			//ENDEREÇO
			if (String.IsNullOrWhiteSpace(Endereco.Bairro))
				throw new DominioException("Bairro inválido!");
			if (String.IsNullOrWhiteSpace(Endereco.Cep))
				throw new DominioException("Cep inválido!");
			if (String.IsNullOrWhiteSpace(Endereco.Localidade))
				throw new DominioException("Localidade inválido!");
			if (String.IsNullOrWhiteSpace(Endereco.Uf))
				throw new DominioException("Uf inválido!");
			if (String.IsNullOrWhiteSpace(Endereco.Logradouro))
				throw new DominioException("Logradouro inválido!");
			if (String.IsNullOrWhiteSpace(Endereco.Complemento))
				throw new DominioException("Complemento inválido!");
			if (String.IsNullOrWhiteSpace(Endereco.Numero))
				throw new DominioException("Numero inválido!");
		}
	}
}

