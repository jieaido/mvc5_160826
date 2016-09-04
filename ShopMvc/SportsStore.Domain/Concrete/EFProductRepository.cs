using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository:IProductRepository
    {
        private EFDbContext context=new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
           context.Products.AddOrUpdate(product);
            context.SaveChanges();
        }

        public Product DeleteProduct(int id)
        {
            var result= context.Products.FirstOrDefault(x => x.ProductID == id);
            if (result!=null)
            {
                context.Products.Remove(result);
                context.SaveChanges();
            }
            return result;
        }
    }
}
