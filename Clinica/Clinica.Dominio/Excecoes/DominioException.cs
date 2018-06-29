using System;

namespace Clinica.Dominio
{
	public class DominioException : Exception
	{
		public DominioException(string message)
			: base(message)
		{
		}
	}
}