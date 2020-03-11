using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using testeLinx.Models;
using testeLinx.Services._core;

namespace testeLinx.Services {

    public class ProductServices : IProductServicesContract {

        private static MemContext _singleton;
        
        private static MemContext context => _singleton ??= new MemContext(new DbContextOptionsBuilder<MemContext>()
                                                                           .UseInMemoryDatabase(databaseName: "Test")
                                                                           .Options);
        public bool create(ProductEntity newReg) {

            context.Products.Add(newReg);
            
            return context.SaveChanges() > 0;
        }
        
        public IList<ProductEntity> listAll() {

            var productList = context.Products.ToList();
            
            return productList;
        }
        
        public bool delete(int id) {

            var product = context.Products.Remove(context.Products.Find(id)) ;
            
            return true;
        }
        
        public ProductEntity get(int id) {

            var product = context.Products.FirstOrDefault(x => x.code == id);
            
            return product;
        }

    }

}