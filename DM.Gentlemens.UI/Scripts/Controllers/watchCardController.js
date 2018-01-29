var WatchCardController = function (containerId, watch) {

    this.RenderCard = function () {
        var jqCard = $("<div class='col-sm-6 col-md-4 col-lg-3 mt-4'>")
            .append("<div id='" + watch.ProductID + "'class='card'>")
            .append("<img class='img-fluid' src='https://ae01.alicdn.com/kf/HTB122S7NXXXXXXGaXXXq6xXFXXXH/8-Color-Brand-Luxury-Casual-Men-Watch-Analog-Sport-Steel-Case-Quartz-Dial-Leather-Male-Clock.jpg_640x640.jpg' alt='Card image cap'>")
            .append("<div class='card-block'  style='background-color:lightgrey'>")
            .append("<h4 class='card-title'>" + watch.ProductName + "</h4>")
            .append("<p class='card-text'>" + watch.ProductDescription + "</p>")
            .append("<p class='card-text'>" + watch.Price + " $" + "</p>")
            .append("<a href='#' class='btn btn-primary'>Add to cart</a>");

        $("#" + containerId).append(jqCard);
    }
}