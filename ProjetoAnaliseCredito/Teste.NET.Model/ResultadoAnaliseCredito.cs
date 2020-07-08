using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.NET.Model
{
	public class ResultadoAnaliseCredito
	{
		public StatusCredito StatusAnaliseCredito { get; set; }
		public double ValorTotalComJuros { get; set; }
		public double ValorJuros { get; set; }
		public List<string> MsgValidacao { get; set; }
	}

	public enum StatusCredito 
	{
		Aprovado,
		Recusado
	}
}
