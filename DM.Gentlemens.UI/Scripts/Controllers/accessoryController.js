var AccessoryController = function (serviceContext) {
    this.RenderPage = function () {
        $("#divAccessoryCards").empty();

        var allAccessories = [];
        var ties = serviceContext.ProductService().ReadAll("Ties");
        var neckties = serviceContext.ProductService().ReadAll("Neckties");
        var pocketSquares = serviceContext.ProductService().ReadAll("Pocket Squares");

        for (var i = 0; i < ties.length; i++) {
            allAccessories.push(ties[i]);
        }
        for (var i = 0; i < neckties.length; i++) {
            allAccessories.push(neckties[i]);
        }
        for (var i = 0; i < pocketSquares.length; i++) {
            allAccessories.push(pocketSquares[i]);
        }

        for (var i = 0; i < allAccessories.length; i++) {
            var accessoryCardController = new AccessoryCardController("divAccessoryCards", allAccessories[i]);
            accessoryCardController.RenderCard();
        }
    }
}