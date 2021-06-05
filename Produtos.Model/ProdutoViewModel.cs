using Microsoft.AspNetCore.Http;
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

        public ProdutoViewModel GetProduto(Produto produto)
        {
            this.Id = produto.Id;
            this.Imagem = produto.Imagem;
            this.Nome = produto.NomeProduto;
            this.ValorProduto = produto.ValorVenda;
            
            return this;
        }

        public IList<ProdutoViewModel> GetProdutos(List<Produto> produtos)
        {
            IList<ProdutoViewModel> produtoViews = new List<ProdutoViewModel>();
            foreach (var produto in produtos)
            {
                produtoViews.Add(new ProdutoViewModel()
                {
                    Id = produto.Id,
                    Imagem = produto.Imagem,
                    Nome = produto.NomeProduto,
                    ValorProduto = produto.ValorVenda
                });
            }

            return produtoViews;
        }
    }
}
