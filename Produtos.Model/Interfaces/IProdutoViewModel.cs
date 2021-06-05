using Microsoft.AspNetCore.Http;
using Produtos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Produtos.Model.Interfaces
{
    public interface IProdutoViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorProduto { get; set; }

        public string Imagem { get; set; }

        Produto GetProduto();

        ProdutoViewModel GetProduto(Produto produto);

        IList<ProdutoViewModel> GetProdutos(List<Produto> produtos);

    }
}
