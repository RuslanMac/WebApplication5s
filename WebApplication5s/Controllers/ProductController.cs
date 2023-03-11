using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System;
using System.Threading.Tasks;
using System.Xml.XPath;
using WebApplication5s.Application.Dtos.Commands;
using WebApplication5s.Application.Dtos.Queries;
using WebApplication5s.Domain.Models;
using System.Collections.Generic;

namespace WebApplication5s.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Получение товара
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(long id)
        {
            var productQuery = new ProductQuery() { Id = id };
            var result = await _mediator.Send(productQuery);
            return Ok(result);
        }
        /// <summary>
        /// создание товара
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        } 


        /// <summary>
        ///  Добавление фотографтй
        ///</summary>
        [HttpPost("images/{productId}")]
        public async Task ProcessFiles([FromForm] IFormFile[] files, long productId)
        {
            var maxAllowedFiles = 3;
            var filesToProcessCount = Math.Min(files.Length, maxAllowedFiles);
            long maxFileSize = 1024 * 1024 * 15;
            var filesProcessed = 0;

            for (int i = 0; i < filesToProcessCount; i++)
            {
                var file = files[i];
                string trustedFileNameForFileStorage;
                var untrustedFileName = file.FileName;
                var trustedFileNameForDisplay =
                    WebUtility.HtmlEncode(untrustedFileName);

                if (file.Length == 0)
                {

                    throw new ArgumentException($"{trustedFileNameForDisplay} length is 0 (Err: 1)");
                }
                else if (file.Length > maxFileSize)
                {
                    throw new ArgumentException("The limit is exceeded");
                }
                else
                {
                    try
                    {

                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();

                            await _mediator.Send(new AddImageProductCommand
                            {
                                ProductId = productId,
                                Image = fileBytes
                            });
                        }

                    }
                    catch (IOException ex)
                    {
                        throw new Exception("The error while writings"); 
                    }
                }

                filesProcessed++;

            }
        }



    }
}
