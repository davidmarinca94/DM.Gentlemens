var ServiceContext = function () {
    var _self = this;
    var _productService;

    this.ProductService = function () {
        if (!_productService) {
            _productService = new ProductService(_self);
        }
        return _productService;
    }
}