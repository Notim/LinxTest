using System.Collections.Generic;

using testeLinx.Models;

namespace testeLinx.Services {

    public interface IProductServicesContract {

        bool create(ProductEntity newReg);

        IList<ProductEntity> listAll();

        bool delete(int id);

        ProductEntity get(int id);

    }

}