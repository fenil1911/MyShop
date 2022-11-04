using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        private string category;

        public string Category { get => category; set => category = value; }
    }
}