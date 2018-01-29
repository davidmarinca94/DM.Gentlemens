var AccessoryCardController = function (containerId, accessory) {

    this.RenderCard = function () {
        var jqCard = $("<div class='col-sm-6 col-md-4 col-lg-3 mt-4'>")
            .append("<div id='" + accessory.ProductID + "'class='card'>")
            .append("<img class='img-fluid' src='https://cdn.shopify.com/s/files/1/1024/6595/products/CLAS102_512x.progressive.jpg?v=1506828675' alt='Card image cap'>")
            .append("<div class='card-block'  style='background-color:lightgrey'>")
            .append("<h4 class='card-title'>" + accessory.ProductName + "</h4>")
            .append("<p class='card-text'>" + accessory.ProductDescription + "</p>")
            .append("<p class='card-text'>" + accessory.Price + " $" + "</p>")
            .append("<a href='#' class='btn btn-primary'>Add to cart</a>");

        $("#" + containerId).append(jqCard);
    }
}