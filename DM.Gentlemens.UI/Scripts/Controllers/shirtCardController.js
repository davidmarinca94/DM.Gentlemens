var ShirtCardController = function (containerId, shirt) {

    this.RenderCard = function () {
        var jqCard = $("<div class='col-sm-6 col-md-4 col-lg-3 mt-4'>")
            .append("<div id='" + shirt.ProductID + "'class='card'>")
            .append("<img class='img-fluid' src='http://www.binhindioutlet.me/wp-content/uploads/2015/04/MS1001.jpg' alt='Card image cap'>")
            .append("<div class='card-block'  style='background-color:lightgrey'>")
            .append("<h4 class='card-title'>" + shirt.ProductName + "</h4>")
            .append("<p class='card-text'>" + shirt.ProductDescription + "</p>")
            .append("<p class='card-text'>" + shirt.Price + " $" + "</p>")
            .append("<a href='#' class='btn btn-primary'>Add to cart</a>");

        $("#" + containerId).append(jqCard);
    }
}