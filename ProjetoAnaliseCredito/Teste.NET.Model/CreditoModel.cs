using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.NET.Model
{
	public class CreditoModel
	{
		public int QuantidadeParcela { get; set; }
		public double ValorCredito { get; set; }
		public TipoCredito TipoCredito { get; set; }
		public float Taxa { get; set; }
		public DateTime DataPrimeiroVencimento { get; set; }
	}

	public enum TipoCredito 
	{
		Direto = 0,
		Consignado = 1,
		PessoaJuridica = 2,
		PessoaFisica = 3,
		Imobiliario = 4
	}
}
