using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper;
using CsvHelper.Configuration;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using testeLinx.Models;
using testeLinx.Services;

namespace testeLinx.Controllers {

    [ApiController, Route("api/[controller]")]
    public class ProductsController : ControllerBase {

        private readonly IProductServicesContract _ProductServicesContract;
        
        public ProductsController(IProductServicesContract IProductServicesContract) {
            this._ProductServicesContract = IProductServicesContract;
        }
        
        [HttpPost, EnableCors("AllowOrigin")]
        public async Task<IActionResult> Post(IFormCollection form) {
            
            var filePaths = new List<string>();
            foreach (var formFile in form.Files) {
                if (formFile.Length > 0) {
                    
                    var filePath = Path.GetTempFileName();
                    filePaths.Add(filePath);
 
                    using (var stream = new FileStream(filePath, FileMode.Create)) {
                        
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            
            var mappedProductList = new List<ProductEntity>();
            foreach (var path in filePaths) {

                using (TextReader fileReader = System.IO.File.OpenText(path)) {

                    var conf = new CsvConfiguration(CultureInfo.InvariantCulture);
                    
                    var csv = new CsvReader(fileReader, conf);
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.HasHeaderRecord = true;
                    
                    csv.Read();
                    csv.ReadHeader();
                    
                    while (csv.Read()) {
                        var index = 0;
                        
                        var product = new ProductEntity {
                            code = csv.TryGetField<int>(index++, out var code) ? code : 0,
                            name = csv.TryGetField<string>(index++, out var name) ? name : "",
                            value = csv.TryGetField<decimal>(index++, out var value) ? value : 0,
                        };
                        
                        mappedProductList.Add(product);
                    }
                }
            }
            
            mappedProductList.ForEach(newProduct => {
                this._ProductServicesContract.create(newProduct);
            });

            return Ok("Arquivo importado com sucesso !!");
        }
        
        [HttpGet, EnableCors("AllowOrigin")]
        public IEnumerable<ProductDto> Get() {
            return this._ProductServicesContract
                       .listAll()
                       .Select(x => new ProductDto {
                           code  = x.code,
                           name  = x.name,
                           value = x.value
                       }).ToArray();
        }
    }
}