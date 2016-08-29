using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
           Mock<IProductRepository> mock=new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>()
            {
                new Product() {Name = "FootBall", Price = 25},
                new Product() {Name = "suff board", Price = 225},
                new Product() {Name = "running shoe", Price = 35}
                });
           // kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}