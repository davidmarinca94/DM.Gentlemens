var SuitController = function (serviceContext) {
    this.RenderPage = function () {
        $("#divSuitCards").empty();
        var allSuits = serviceContext.ProductService().ReadAll("Suits");
        for (var i = 0; i < allSuits.length; i++) {
            var suitCardController = new SuitCardController("divSuitCards", allSuits[i]);
            suitCardController.RenderCard();
        }
    }
}