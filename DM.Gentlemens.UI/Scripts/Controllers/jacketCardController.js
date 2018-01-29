var JacketCardController = function (containerId, jacket) {

    this.RenderCard = function () {
        var jqCard = $("<div class='col-sm-6 col-md-4 col-lg-3 mt-4'>")
            .append("<div id='" + jacket.ProductID + "'class='card'>")
            .append("<img class='img-fluid' src='https://www.onlineoutlet.pk/content/images/thumbs/0004079_highstreet-faux-leather-jacket-for-men.jpeg' alt='Card image cap'>")
            .append("<div class='card-block'  style='background-color:lightgrey'>")
            .append("<h4 class='card-title'>" + jacket.ProductName + "</h4>")
            .append("<p class='card-text'>" + jacket.ProductDescription + "</p>")
            .append("<p class='card-text'>" + jacket.Price + " $" + "</p>")
            .append("<a href='#' class='btn btn-primary'>Add to cart</a>");

        $("#" + containerId).append(jqCard);
    }
}