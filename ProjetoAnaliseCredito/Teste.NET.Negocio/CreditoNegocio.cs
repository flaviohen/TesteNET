using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Teste.NET.Model;

namespace Teste.NET.Negocio
{
	public class CreditoNegocio
	{
		private float RetornarTaxaPorTipoCredito(TipoCredito tipoCredito) 
		{
			float taxa = 0;
			float percentual = 0;
			if (tipoCredito == TipoCredito.Direto) 
			{
				percentual = 2;
				taxa = percentual / 100;
			}
			if (tipoCredito == TipoCredito.Consignado) 
			{
				percentual = 1;
				taxa = percentual / 100;
			}
			if (tipoCredito == TipoCredito.PessoaJuridica) 
			{
				percentual = 5;
				taxa = percentual / 100;
			}
			if (tipoCredito == TipoCredito.PessoaFisica) 
			{
				percentual = 3;
				taxa = percentual / 100;
			}
			if (tipoCredito == TipoCredito.Imobiliario) 
			{
				percentual = 9;
				taxa = percentual / 100;
			}

			return taxa;
		}
		private List<string> ValidarLiberacaoCredito(CreditoModel solicitacaoCredito, ref StatusCredito statusCredito) 
		{
			double valorMaximoEmprestimo = 1000000;
			int qtdParcelasMaxima = 72;
			int qtdParcelaMinina = 5;
			double valorMinimoTipoPessoaJuridica = 15000;
			int qtDiasSomadoDiaAtualDataMininaVencimento = 15;
			int qtDiasSomadoDiaAtualDataMaximaVencimento = 40;

			DateTime DiaAtual = DateTime.Now;
			DateTime DataMinimaVencimento = DiaAtual.AddDays(qtDiasSomadoDiaAtualDataMininaVencimento);
			DateTime DataMaximaVencimento = DiaAtual.AddDays(qtDiasSomadoDiaAtualDataMaximaVencimento);

			List<string> MsgValidacao = new List<string>();

			if (solicitacaoCredito.ValorCredito > valorMaximoEmprestimo)
				MsgValidacao.Add("O valor máximo a ser liberado para qualquer tipo de empréstimo é de " + valorMaximoEmprestimo.ToString("C"));
			if (solicitacaoCredito.QuantidadeParcela < qtdParcelaMinina)
				MsgValidacao.Add("A quantidade de parcela deve ser no minimo "+ qtdParcelaMinina);
			if (solicitacaoCredito.QuantidadeParcela > qtdParcelasMaxima)
				MsgValidacao.Add("A quantidade de parcela deve ser no maximo "+ qtdParcelasMaxima);
			if (solicitacaoCredito.TipoCredito == TipoCredito.PessoaJuridica) 
			{
				if (solicitacaoCredito.ValorCredito < valorMinimoTipoPessoaJuridica)
					MsgValidacao.Add("O valor minimo de emprestimo para Pessoa Juriridica é de no minimo " + valorMinimoTipoPessoaJuridica.ToString("C"));
			}
			if (solicitacaoCredito.DataPrimeiroVencimento < DataMinimaVencimento)
				MsgValidacao.Add("A data de primeiro vencimento não pode ser menor que: " + DataMinimaVencimento.ToString("dd/MM/yyyy"));
			if (solicitacaoCredito.DataPrimeiroVencimento > DataMaximaVencimento)
				MsgValidacao.Add("A data de primeiro vencimento não pode ser maior que " + DataMaximaVencimento.ToString("dd/MM/yyyy"));

			if (MsgValidacao.Count > 0)
				statusCredito = StatusCredito.Recusado;
			else
				statusCredito = StatusCredito.Aprovado;

			return MsgValidacao;
		}
		public ResultadoAnaliseCredito ProcessarCredito(CreditoModel solicitacaoCredito) 
		{
			StatusCredito stCredito = StatusCredito.Aprovado;
			List<string> MsgValidacao = ValidarLiberacaoCredito(solicitacaoCredito, ref stCredito);
			ResultadoAnaliseCredito analiseCredito = new ResultadoAnaliseCredito();
			solicitacaoCredito.Taxa = RetornarTaxaPorTipoCredito(solicitacaoCredito.TipoCredito);
			if (stCredito == StatusCredito.Aprovado)
			{
				analiseCredito.StatusAnaliseCredito = StatusCredito.Aprovado;
				analiseCredito.ValorTotalComJuros = Math.Round(solicitacaoCredito.ValorCredito + (solicitacaoCredito.ValorCredito * solicitacaoCredito.Taxa),2);
				analiseCredito.ValorJuros = Math.Round(solicitacaoCredito.ValorCredito * solicitacaoCredito.Taxa,2);
			}
			else 
			{
				analiseCredito.StatusAnaliseCredito = StatusCredito.Recusado;
				analiseCredito.ValorTotalComJuros = 0;
				analiseCredito.ValorJuros = 0;
				analiseCredito.MsgValidacao = MsgValidacao;
			}

			return analiseCredito;
		}
	}
}
