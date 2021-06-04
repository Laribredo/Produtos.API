using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Data
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorVenda { get; set; }
        public string Imagem { get; set; }
    }
}
