using Microsoft.AspNetCore.Http;
using Produtos.Model.Interfaces;
using Produtos.Resource.Enums;
using Produtos.Resource.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Resource
{

    public class Files : IFile
    {
        public IMessageModel message { get; set; }

        public Files(IMessageModel message)
        {
            this.message = message;
        }

        public async System.Threading.Tasks.Task<string> SaveFileAsync(IFormFile file)
        {

            FormatosImagemEnum formats;

            if (file == null || file.Length == 0)
            {
                message.Tipo = Model.Enums.MensagemTipoEnum.Erro;
                message.Erro("Não foi inserido nenhum arquivo");
            }
            try
            {
                string formato = file.FileName.Substring(file.FileName.Length - 3);

                bool formatoAceito = Enum.TryParse(formato.ToUpper(), out formats);

                if (!formatoAceito)
                {
                    message.Tipo = Model.Enums.MensagemTipoEnum.Erro;
                    message.Erro("Não está no formato aceito a imagem.");
                }

                string imagem =  DateTime.Now.ToString("dd-MM-yyyy-mm-ss-f") + "." + formato;
                //Definir um caminho para a imagem
                string filePath = Path.Combine(Directory.GetCurrentDirectory()+"\\Imagens", imagem);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return imagem;
            }
            catch (Exception e)
            {
                return null;
            }


        }
    }
    
}
