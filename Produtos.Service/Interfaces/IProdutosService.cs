using System;
using System.Collections.Generic;
using System.Text;
using Produtos.Data;
using Produtos.Model.Interfaces;

namespace Produtos.Service.Interfaces
{
    public interface IProdutosService
    {
        List<Produto> GetAllProdutos();
        Produto GetProdutoById(int Id);
        bool AddProduto(Produto produto);
        bool RemoveProduto(int Id);
        bool UpdateProduto(Data.Produto produto);

        IMessageModel _message { get; set; }
    }
}
