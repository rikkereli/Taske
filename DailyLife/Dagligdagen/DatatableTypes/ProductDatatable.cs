using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dagligdagen.DatatableTypes
{
    /// <summary>
    /// Make datadepentensi for product lists
    /// </summary>
    class ProductDatatable : DataTable
    {
        public int ProductID;
        public string ProductName;
        public string TypeOfProduct;
        public string UnitType;
    }
}
