$(document).ready(function () {
    var _serviceContext = new ServiceContext();
    _serviceContext.ProductService();
    var _menuController = new MenuController(_serviceContext);
    var _menuControllerFooter = new MenuControllerFooter(_serviceContext);
    _menuController.GenerateMenu();
    _menuControllerFooter.GenerateMenuFooter();
});