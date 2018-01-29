var JacketController = function (serviceContext) {
    this.RenderPage = function () {
        $("#divJacketCards").empty();

        var allJackets = serviceContext.ProductService().ReadAll("Jackets");
        for (var i = 0; i < allJackets.length; i++) {
            var jacketCardController = new JacketCardController("divJacketCards", allJackets[i]);
            jacketCardController.RenderCard();
        }
    }
}