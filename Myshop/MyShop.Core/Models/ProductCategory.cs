namespace MyShop.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        private string category;

        public string Category { get => category; set => category = value; }
    }
}