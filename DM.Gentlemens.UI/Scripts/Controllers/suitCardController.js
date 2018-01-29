var SuitCardController = function (containerId, suit) {

    this.RenderCard = function () {
        var jqCard = $("<div class='col-sm-6 col-md-4 col-lg-3 mt-4'>")
            .append("<div id='" + suit.ProductID + "'class='card'>")
            .append("<img class='img-fluid' src='https://mdbootstrap.com/img/Photos/Horizontal/Nature/4-col/img%20%282%29.jpg' alt='Card image cap'>")
            .append("<div class='card-block'  style='background-color:lightgrey'>")
            .append("<h4 class='card-title'>" + suit.ProductName + "</h4>")
            .append("<p class='card-text'>" + suit.ProductDescription + "</p>")
            .append("<p class='card-text'>" + suit.Price + " $" + "</p>")
            .append("<a href='#' class='btn btn-primary'>Add to cart</a>");

        $("#" + containerId).append(jqCard);
    }
}