var ShoeController = function (serviceContext) {
    this.RenderPage = function () {
        $("#divShoeCards").empty();
        var allShoes = serviceContext.ProductService().ReadAll("Shoes");
        for (var i = 0; i < allShoes.length; i++) {
            var shoeCardController = new ShoeCardController("divShoeCards", allShoes[i]);
            shoeCardController.RenderCard();
        }
    }
}