using Microsoft.AspNetCore.Http;
using Produtos.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Resource.Interface
{
    public interface IFile
    {
        IMessageModel message { get; set; }
        System.Threading.Tasks.Task<string> SaveFileAsync(IFormFile file);
    }
}
