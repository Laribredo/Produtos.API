using Produtos.Data;
using Produtos.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Produtos.Model
{
    public class ProdutoViewModel : IProdutoViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="O Campo nome do Produto é necessário.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo Valor do Produto é necessário.")]
        public decimal ValorProduto { get; set; }
        public string Imagem { get; set; }

        public Produto GetProduto()
        {
            return new Produto()
            {
                Id = (int)(this.Id != null ? this.Id : 0),
                Imagem = this.Imagem,
                NomeProduto = this.Nome,
                ValorVenda = this.ValorProduto
            };
        }
    }
}
