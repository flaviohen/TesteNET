using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teste.NET.Visao.Models;
using Teste.NET.Model;
using Teste.NET.Negocio;

namespace Teste.NET.Visao.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public JsonResult Analisar(string tipoCredito, string valorCredito, string qtParcelas, string dataVencimento) 
		{
			CreditoNegocio creditoNegocio = new CreditoNegocio();
			CreditoModel credito = new CreditoModel();
			credito.ValorCredito = Convert.ToDouble(valorCredito);
			credito.QuantidadeParcela = Convert.ToInt32(qtParcelas);
			switch (tipoCredito)
			{
				case "0":
					credito.TipoCredito = TipoCredito.Direto;
					break;
				case "1":
					credito.TipoCredito = TipoCredito.Consignado;
					break;
				case "2":
					credito.TipoCredito = TipoCredito.PessoaJuridica;
					break;
				case "3":
					credito.TipoCredito = TipoCredito.PessoaFisica;
					break;
				case "4":
					credito.TipoCredito = TipoCredito.Imobiliario;
				    break;
				default:
					break;
			}

			string[] data = dataVencimento.Split("-");
			credito.DataPrimeiroVencimento = new DateTime(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), Convert.ToInt32(data[2]));

			ResultadoAnaliseCredito analise = creditoNegocio.ProcessarCredito(credito);
			return Json(new { Resultado = analise });
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
