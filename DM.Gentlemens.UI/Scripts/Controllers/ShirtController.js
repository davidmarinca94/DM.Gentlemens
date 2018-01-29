var ShirtController = function (serviceContext) {
    this.RenderPage = function () {
        $("#divShirtCards").empty();
        var allShirts = serviceContext.ProductService().ReadAll("Shirts");
        for (var i = 0; i < allShirts.length; i++) {
            var shirtCardController = new ShirtCardController("divShirtCards", allShirts[i]);
            shirtCardController.RenderCard();
        }
    }
}