var ShoeCardController = function (containerId, shoe) {

    this.RenderCard = function () {
        var jqCard = $("<div class='col-sm-6 col-md-4 col-lg-3 mt-4'>")
            .append("<div id='" + shoe.ProductID + "'class='card'>")
            .append("<img class='img-fluid' src='https://cdn.shopify.com/s/files/1/0544/8709/products/black_3_grande_18fd8ceb-70b0-42c7-9bc9-8a7c3e30442e.jpg?v=1462398335' alt='Card image cap'>")
            .append("<div class='card-block'  style='background-color:lightgrey'>")
            .append("<h4 class='card-title'>" + shoe.ProductName + "</h4>")
            .append("<p class='card-text'>" + shoe.ProductDescription + "</p>")
            .append("<p class='card-text'>" + shoe.Price + " $" + "</p>")
            .append("<a href='#' class='btn btn-primary'>Add to cart</a>");

        $("#" + containerId).append(jqCard);
    }
}