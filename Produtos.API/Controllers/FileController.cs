using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Produtos.Resource;
using Produtos.Resource.Interface;

namespace Produtos.API.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        [HttpPost]
        public ActionResult UploadFile(IFormFile file, [FromServices] IFile file1)
        {
            if (ModelState.IsValid)
            {

                var res = file1.SaveFileAsync(file);

                return Created("",new { file = res.Result, error = file1.message.Mensagem});
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
