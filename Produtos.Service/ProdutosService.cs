using Produtos.Data;
using Produtos.Model.Interfaces;
using Produtos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Produtos.Service
{
    public class ProdutosService : IProdutosService
    {
        private ProdutoContext _data;
        public IMessageModel _message { get; set; }

        public ProdutosService(ProdutoContext dataContext, IMessageModel message)
        {
            _data = dataContext;
            _message = message;
        }

        public bool AddProduto(Produto produto)
        {
            try
            {
                var result = _data.Produto.Add(produto);
                _data.SaveChanges();
                _message.Info("O produto foi cadastrado com sucesso.");
                return true;

            }
            catch (Exception e)
            { 
                _message.Tipo = Model.Enums.MensagemTipoEnum.Erro;
                _message.Erro(e.Message);
                return false;
            }
        }

        public List<Produto> GetAllProdutos()
        {
            try
            {
                var result = _data.Produto.ToList();
                _message.Info($"Retornaram {result.Count} produtos.");

                return result;

            }
            catch (Exception e)
            {
                _message.Tipo = Model.Enums.MensagemTipoEnum.Erro;
                _message.Erro(e.Message);
                return null;
            }
           // return null;
        }

        public Produto GetProdutoById(int Id)
        {
            try
            {
                var result = _data.Produto.Where(s => s.Id == Id).FirstOrDefault();
                return result;

            }
            catch (Exception e)
            {
                _message.Tipo = Model.Enums.MensagemTipoEnum.Erro;
                _message.Erro(e.Message);
                return null;
            }
        }

        public bool RemoveProduto(int Id)
        {
            try
            {
                var result = _data.Produto.Where(s => s.Id == Id).FirstOrDefault();
                _data.Produto.Remove(result);
                _data.SaveChanges();
                _message.Info("O produto foi removido com sucesso.");
                return true;

            }
            catch (Exception e)
            {
                _message.Tipo = Model.Enums.MensagemTipoEnum.Erro;
                _message.Erro(e.Message);
                return false;
            }
        }

        public bool UpdateProduto(Produto produto)
        {
            try
            {
                var result = _data.Produto.Update(produto);
                _data.SaveChanges();
                _message.Info("O produto foi alterado com sucesso.");
                return true;

            }
            catch (Exception e)
            {
                _message.Tipo = Model.Enums.MensagemTipoEnum.Erro;
                _message.Erro(e.Message);
                return false;
            }
        }
    }
}
