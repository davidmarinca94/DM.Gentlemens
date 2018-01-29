var WatchController = function (serviceContext) {
    this.RenderPage = function () {
        $("#divWatchCards").empty();
        var allWatches = serviceContext.ProductService().ReadAll("Watches");
        for (var i = 0; i < allWatches.length; i++) {
            var watchCardController = new WatchCardController("divWatchCards", allWatches[i]);
            watchCardController.RenderCard();
        }
    }
}