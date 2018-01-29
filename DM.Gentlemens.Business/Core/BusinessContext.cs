using DM.Gentlemens.RepositoryAbstraction.Core;
using DM.Gentlemens.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.Business.Core
{
    public class BusinessContext : IDisposable
    {
        #region Members
        private static BusinessContext _instance;
        private IRepositoryContext _repositoryContext;
        private UserBusiness _userBusiness;
        private CategoryBusiness _categoryBusiness;
        private ImageBusiness _imageBusiness;
        private OrderedProductBusiness _orderedProductBusiness;
        private OrderBusiness _orderBusiness;
        private ProductBusiness _productBusiness;
        private ShoppingCartBusiness _shoppingCartBusiness;
        #endregion

        #region Constructor
        public BusinessContext()
        {
            _instance = this;
            _repositoryContext = Getter.GetRepository();
        }
        #endregion

        #region Properties
        internal static BusinessContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("No BusinessContext instance available!");
                }
                return _instance;
            }
        }

        public UserBusiness UserBusiness
        {
            get
            {
                if (_userBusiness == null)
                    _userBusiness = new UserBusiness();
                return _userBusiness;
            }
        }

        public CategoryBusiness CategoryBusiness
        {
            get
            {
                if (_categoryBusiness == null)
                    _categoryBusiness = new CategoryBusiness();
                return _categoryBusiness;
            }
        }

        public ImageBusiness ImageBusiness
        {
            get
            {
                if (_imageBusiness == null)
                    _imageBusiness = new ImageBusiness();
                return _imageBusiness;
            }
        }
        public OrderedProductBusiness OrderedProductBusiness
        {
            get
            {
                if (_orderedProductBusiness == null)
                    _orderedProductBusiness = new OrderedProductBusiness();
                return _orderedProductBusiness;
            }
        }

        public OrderBusiness OrderBusiness
        {
            get
            {
                if (_orderBusiness == null)
                    _orderBusiness = new OrderBusiness();
                return _orderBusiness;
            }
        }

        public ProductBusiness ProductBusiness
        {
            get
            {
                if (_productBusiness == null)
                    _productBusiness = new ProductBusiness();
                return _productBusiness;
            }
        }

        public ShoppingCartBusiness ShoppingCartBusiness
        {
            get
            {
                if (_shoppingCartBusiness == null)
                    _shoppingCartBusiness = new ShoppingCartBusiness();
                return _shoppingCartBusiness;
            }
        }

        internal IRepositoryContext RepositoryContext
        {
            get { return _repositoryContext; }
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
                if (_userBusiness != null)
                {
                    _userBusiness = null;
                }

                if (_categoryBusiness != null)
                {
                    _categoryBusiness = null;
                }
                
                if (_imageBusiness != null)
                {
                    _imageBusiness = null;
                }

                if (_orderBusiness != null)
                {
                    _orderBusiness = null;
                }

                if (_orderedProductBusiness != null)
                {
                    _orderedProductBusiness = null;
                }

                if (_productBusiness != null)
                {
                    _productBusiness = null;
                }

                if (_shoppingCartBusiness != null)
                {
                    _shoppingCartBusiness = null;
                }

                if (_repositoryContext != null)
                {
                    _repositoryContext.Dispose();
                    _repositoryContext = null;
                }

                if (_instance != null)
                {
                    _instance = null;
                }
            }
        }

        ~BusinessContext()
        {
            Dispose(false);
        }
        #endregion
    }
}
