using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace testeLinx.Models {

    public class ProductEntity {

        public int id { get; set; }
        
        public int code { get; set; }

        public string name { get; set; }

        public decimal value { get; set; }

    }

}