var KnitwearCardController = function (containerId, knitwear) {

    this.RenderCard = function () {
        var jqCard = $("<div class='col-sm-6 col-md-4 col-lg-3 mt-4'>")
            .append("<div id='" + knitwear.ProductID + "'class='card'>")
            .append("<img class='img-fluid' src='https://i.pinimg.com/736x/ea/17/f3/ea17f3d2cc4e59e90092b91674ca5b9b--mens-knits-mens-knitwear.jpg' alt='Card image cap'>")
            .append("<div class='card-block'  style='background-color:lightgrey'>")
            .append("<h4 class='card-title'>" + knitwear.ProductName + "</h4>")
            .append("<p class='card-text'>" + knitwear.ProductDescription + "</p>")
            .append("<p class='card-text'>" + knitwear.Price + " $" + "</p>")
            .append("<a href='#' class='btn btn-primary'>Add to cart</a>");

        $("#" + containerId).append(jqCard);
    }
}