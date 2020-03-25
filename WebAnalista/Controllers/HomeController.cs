using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebAnalista.Models;

namespace WebAnalista.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Produtos produtos = new Produtos();
            
            return View(produtos);
        }

        [HttpPost]
        public IActionResult Index([FromForm] Produtos produtos)
        {
            string recebeNome = Request.Form["nome"];
            string recebeCategoria = Request.Form["categoria"];
            double recebePreco = double.Parse(Request.Form["preco"]);
            double recebeAumento = double.Parse(Request.Form["aumento"]);
            int recebeQuantidade = int.Parse(Request.Form["quantidade"]);
            int recebeSaida = int.Parse(Request.Form["saida"]);
            double venda = double.Parse(Request.Form["venda"]);
            double recebeValorDoEstoque = double.Parse(Request.Form["valorDoEstoque"]);
          
            //preencher os campos do Model

            produtos.Nome = recebeNome.Trim().ToUpper();
            produtos.Categoria = recebeCategoria.Trim().ToUpper();
            produtos.Preco = double.Parse(recebePreco.ToString());
            produtos.Aumento = double.Parse(recebeAumento.ToString());
            produtos.Quantidade = recebeQuantidade;
            produtos.QuantidadeSaida = recebeSaida;

            //calculo dos Métodos

            produtos.CalcularVenda();
            produtos.CalcularValorDoEstoque();
            produtos.ResultadoEstoque = produtos.SaidaEstoque(produtos.QuantidadeSaida);
            
            return View(produtos);
        }
    }
}