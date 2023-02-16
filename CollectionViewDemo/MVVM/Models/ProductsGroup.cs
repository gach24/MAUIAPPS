using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewDemo.MVVM.Models
{
    public class ProductsGroup : List<Product>
    {
        #region PROPERTIES
        public string Name { get; set; }
        #endregion

        #region CONSTRUCTORS

        public ProductsGroup(string name, List<Product> products) : base(products) 
        {
            Name = name;
        }


        #endregion

    }
}
