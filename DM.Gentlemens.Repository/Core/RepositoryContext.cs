using DM.Gentlemens.RepositoryAbstraction;
using DM.Gentlemens.RepositoryAbstraction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.Repository.Core
{
    public class RepositoryContext : IRepositoryContext
    {
        #region Members
        private static IRepositoryContext _instance;
        private IUserRepository _userRepository;
        private ICategoryRepository _categoryRepository;
        private IImageRepository _imageRepository;
        private IOrderedProductRepository _orderedProductRepository;
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IShoppingCartRepository _shoppingCartRepository;
        #endregion

        #region Constructor
        public RepositoryContext()
        {
            _instance = this;
        }
        #endregion

        #region Properties
        internal static IRepositoryContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("No RepositoryContext instance available!");
                }
                return _instance;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository();
                return _userRepository;
            }
        }
                
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository();
                return _categoryRepository;
            }
        }

        public IImageRepository ImageRepository
        {
            get
            {
                if (_imageRepository == null)
                    _imageRepository = new ImageRepository();
                return _imageRepository;
            }
        }

        public IOrderedProductRepository OrderedProductRepository
        {
            get
            {
                if (_orderedProductRepository == null)
                    _orderedProductRepository = new OrderedProductRepository();
                return _orderedProductRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository();
                return _orderRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository();
                return _productRepository;
            }
        }

        public IShoppingCartRepository ShoppingCartRepository
        {
            get
            {
                if (_shoppingCartRepository == null)
                    _shoppingCartRepository = new ShoppingCartRepository();
                return _shoppingCartRepository;
            }
        }

        #endregion

        #region IDisposable Implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            
            if (dispose)
            {
                if(_userRepository != null)
                {
                    _userRepository = null;
                }

                if (_categoryRepository != null)
                {
                    _categoryRepository = null;
                }

                if(_imageRepository != null)
                {
                    _imageRepository = null;
                }

                if (_orderedProductRepository != null)
                {
                    _orderedProductRepository = null;
                }

                if (_orderRepository != null)
                {
                    _orderRepository = null;
                }

                if (_productRepository != null)
                {
                    _productRepository = null;
                }

                if (_shoppingCartRepository != null)
                {
                    _shoppingCartRepository = null;
                }
            }
        }

        ~RepositoryContext()
        {
            Dispose(false);
        }
        #endregion
    }
}