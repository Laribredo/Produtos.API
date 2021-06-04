using Produtos.Model.Enums;
using Produtos.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Model
{
    public class MessageModel : IMessageModel
    {
        public DateTime DataOcorrecia { get; set; }
        public string Detalhe { get; set; }
        public string Mensagem { get; set; }
        public MensagemTipoEnum Tipo { get; set; }

        public void Info(string message)
        {
            Mensagem = message;
        }

        public void Erro(string message, string detalhe)
        {
            Mensagem = message;
            Detalhe = detalhe;
            Tipo = MensagemTipoEnum.Erro;
        }

        public void Erro(string message)
        {
            Mensagem = message;
            Tipo = MensagemTipoEnum.Erro;
        }

        public void Alerta(string message)
        {
            Mensagem = message;
            Tipo = MensagemTipoEnum.Alerta;
        }
    }
}
