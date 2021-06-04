using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Produtos.Model;
using Produtos.Model.Interfaces;
using Produtos.Service;
using Produtos.Service.Interfaces;

namespace Produtos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {

        [HttpGet]
        public ActionResult GetAll([FromServices] IProdutosService service)
        {
            var res = service.GetAllProdutos();
            if (service._message.Tipo == Model.Enums.MensagemTipoEnum.Erro)
            {            
                return BadRequest(service._message.Mensagem);
            }

            return Ok(new { resultado = res, mensagem = service._message.Mensagem });
        }

        [HttpGet("{Id}")]
        public ActionResult GetById(int Id,[FromServices] IProdutosService service)
        {
            var resultado = service.GetProdutoById(Id);
            if (service._message.Tipo == Model.Enums.MensagemTipoEnum.Erro)
            {
                return BadRequest(service._message.Mensagem);
            }

            return Ok(resultado);
        }

        [HttpPost]
        public ActionResult Create([FromServices] IProdutosService service, [FromBody] ProdutoViewModel produto)
        {
            if(ModelState.IsValid)
            {
                var res = service.AddProduto(produto.GetProduto());
                return Ok(new { resultado = res, mensagem = service._message.Mensagem });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPut]
        public ActionResult Update([FromServices] IProdutosService service, [FromBody] ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var res = service.UpdateProduto(produto.GetProduto());
                return Ok(new { resultado = res, mensagem = service._message.Mensagem });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id, [FromServices] IProdutosService service)
        {
            var res = service.RemoveProduto(Id);
            return Ok(new { resultado = res, mensagem = service._message.Mensagem });
        }




    }
}
