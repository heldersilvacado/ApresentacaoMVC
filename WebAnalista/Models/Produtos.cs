using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAnalista.Models
{
    public class Produtos
    {
        //atributos da classe
        [DisplayName("Nome")]
        [Required(ErrorMessage ="Você deve entrar com um nome para o produto")]
        public string Nome {get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Você deve entrar com um nome para a Categoria")]
        public string Categoria { get; set; }

        [DisplayName("Preco")]
        [Required(ErrorMessage = "Você deve entrar com o preço do produto")]
        public double Preco { get; set; }

        [DisplayName("Aumento")]
        [Range(0, 999999.99)]
        [Required(ErrorMessage = "Você deve entrar com o aumento do produto")]
        public double Aumento { get; set; }

        [DisplayName("Venda")]
        [Range(0, 999999.99)]
        [Required(ErrorMessage = "Você deve entrar com a venda do produto")]
        public double Venda { get; set; }

        [DisplayName("Quantidade")]
        [Range(0,999999.99)]
        [Required(ErrorMessage = "Você deve entrar com a quantidade do produto")]
        public int Quantidade { get;  set; }

        [DisplayName("QuantidadeEntrada")]
        [Range(0, 999999.99)]
        [Required(ErrorMessage = "Você deve entrar com a quantidade do produto")]
        public int QuantidadeEntrada { get; set; }

        [DisplayName("QuantidadeSaida")]
        [Range(0, 999999.99)]
        [Required(ErrorMessage = "Você deve entrar com a quantidade do produto")]
        public int QuantidadeSaida { get; set; }

        public int ResultadoEstoque { get; set; }
        //Contrutores das Classes
        public Produtos()
        {
        }

        public Produtos(string nome, string categoria, double preco, double aumento, double venda, int quantidade, int quantidadeEntrada, int quantidadeSaida)
        {
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            Aumento = aumento;
            Venda = venda;
            Quantidade = quantidade;
            QuantidadeEntrada = quantidadeEntrada;
            QuantidadeSaida = quantidadeSaida;
        }

        //métodos da Classe

        public double CalcularVenda()
        {
            double venda;
            venda = Preco*(Aumento/100)+Preco;
            return venda;
        }
        
        public double CalcularValorDoEstoque()
        {
            return (Preco * (Aumento / 100) + Preco)*Quantidade;
        }

        public int EntradaEstoque(int QuantidadeEntrada)
        {
            return Quantidade += QuantidadeEntrada;
        }

        public int SaidaEstoque(int QuantidadeSaida)
        {
            return Quantidade -= QuantidadeSaida;
        }

        public override string ToString()
        {
            return Nome + ", R$ " + Preco.ToString("F2", CultureInfo.InvariantCulture)
                   + ", temos " + Quantidade + " unidades. "
                   + " O Valor do Estoque é de: " + CalcularValorDoEstoque().ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}
