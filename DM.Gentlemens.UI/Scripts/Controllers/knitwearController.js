var KnitwearController = function (serviceContext) {
    this.RenderPage = function () {
        $("#divKnitwearCards").empty();

        var allKnitwears = serviceContext.ProductService().ReadAll("Knitwear");
        for (var i = 0; i < allKnitwears.length; i++) {
            var knitwearCardController = new KnitwearCardController("divKnitwearCards", allKnitwears[i]);
            knitwearCardController.RenderCard();
        }
    }
}