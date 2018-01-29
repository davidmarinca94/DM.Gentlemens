$(document).ready(function () {

    var products = [
        {
            productId: 1,
            categoryId: 1,
            productName: 'suit 1',
            productDescription: 'desc',
            price: '123',
            imageUrl: 'https://www.tmlewin.com.au/dw/image/v2/BBQF_PRD/on/demandware.static/-/Sites-tml-catalog-en/default/dwa0112921/images/portrait/55954S.jpg?sw=1556&sh=1680&sm=fit'
        },
        {
            productId: 5,
            categoryId: 2,
            productName: 'shirt 1',
            productDescription: 'desc',
            price: '123',
            imageUrl: 'https://riverisland.scene7.com/is/image/RiverIsland/300588_main?wid=1200'
        },
        {
            productId: 2,
            categoryId: 2,
            productName: 'shirt 2',
            productDescription: 'desc',
            price: '13',
            imageUrl: 'https://res.cloudinary.com/stylight/image/upload/e_trim/t_web_product_325x325/q_auto:eco,f_auto/product-ermenegildo-zegna-slim-fit-cutaway-collar-checked-cotton-shirt-burgundy-1-146317614.jpg'
        },
        {
            productId: 5,
            categoryId: 2,
            productName: 'suit 1',
            productDescription: 'desc',
            price: '123',
            imageUrl: 'https://riverisland.scene7.com/is/image/RiverIsland/300588_main?wid=1200'
        },
        {
            productId: 2,
            categoryId: 2,
            productName: 'shirt 2',
            productDescription: 'desc',
            price: '13',
            imageUrl: 'https://res.cloudinary.com/stylight/image/upload/e_trim/t_web_product_325x325/q_auto:eco,f_auto/product-ermenegildo-zegna-slim-fit-cutaway-collar-checked-cotton-shirt-burgundy-1-146317614.jpg'
        },
        {
            productId: 5,
            categoryId: 2,
            productName: 'shirt 1',
            productDescription: 'desc',
            price: '123',
            imageUrl: 'https://riverisland.scene7.com/is/image/RiverIsland/300588_main?wid=1200'
        },
        {
            productId: 2,
            categoryId: 2,
            productName: 'shirt 2',
            productDescription: 'desc',
            price: '13',
            imageUrl: 'https://res.cloudinary.com/stylight/image/upload/e_trim/t_web_product_325x325/q_auto:eco,f_auto/product-ermenegildo-zegna-slim-fit-cutaway-collar-checked-cotton-shirt-burgundy-1-146317614.jpg'
        }];

    function initializeProducts() {

        var categoryMap = [
            {
                categoryId: 1,
                name: 'suits',
                tabId: '#v-pills-suits'
            },
            {
                categoryId: 2,
                name: 'shirts',
                tabId: '#v-pills-shirts'
            }
        ]

        var categoryProductStorage = [];
        for (var i = 0; i < categoryMap.length; i++) {
            var categId = categoryMap[i].categoryId;
            var categProducts = products.filter(function (item) {
                return item.categoryId == categId;
            });
            categoryProductStorage.push({
                categoryId: categId,
                products: categProducts
            });
        }

        for (var i = 0; i < categoryProductStorage.length; i++) {
            var tabId = categoryMap.find(function (item) {
                return item.categoryId == categoryProductStorage[i].categoryId;
            }).tabId;
            var tab = $(tabId);

            var container = document.createElement('div');
            container.className = "row col-md-9 left-spacer mt-5";


            for (var j = 0; j < categoryProductStorage[i].products.length; j++) {
                var product = categoryProductStorage[i].products[j];
                var innerContainer = document.createElement('div');
                innerContainer.className = "col-md-4col-sm-10 mt-3";
                var productsContainer = document.createElement('div');
                productsContainer.className = "product-container";

                var image = document.createElement('img');
                image.className = "row product-image img-responsive";
                image.setAttribute('src', product.imageUrl, 'style', 'padding-left:0px; padding-right:0px');

                var nameDiv = document.createElement('div');
                nameDiv.className = "row";
                nameDiv.innerText = product.productName;

                var priceDiv = document.createElement('div');
                priceDiv.className = "row";
                priceDiv.innerText = product.price + " $";

                var buttonDiv = document.createElement('div');
                buttonDiv.className = "row";
                var button = document.createElement('button');
                button.className = "btn btn-primary";
                button.innerHTML = "Add to cart";
                button.addEventListener('click', function () {
                    addToCart(product);
                });
                buttonDiv.append(button);

                productsContainer.append(image, nameDiv, priceDiv, buttonDiv);
                innerContainer.append(productsContainer);
                container.append(innerContainer);
            }
            tab.append(container);
        }
    }

    function initializeShoppingCart() {
        // retreive shopping cart from db
        var shoppingCart = $('#shopping-cart');
        for (var i = 1; i < products.length; i++) {
            var product = products[i];

            var innerContainer = document.createElement('div');
            innerContainer.className = "row col-md-12 mt-3";

            var productDetailsDiv = document.createElement('div');
            productDetailsDiv.className = "col-md-11";
            productDetailsDiv.innerHTML = "Product: " + product.productName + "<br/> Price: " + product.price + " <br/> Quantity: 1 <br/>";

            var productActionsDiv = document.createElement('div');
            productActionsDiv.className = "col-md-1";

            var removeProductButton = document.createElement('button');
            removeProductButton.className = "btn btn-danger float-rigth";
            removeProductButton.innerText = "Remove";
            removeProductButton.addEventListener('click', function () {
                removeProductFromShoppingCart(product);
            })
            productActionsDiv.append(removeProductButton);
            innerContainer.append(productDetailsDiv, productActionsDiv);
            shoppingCart.append(innerContainer);

        }
    }

    function addToCart(product) {
        console.log(product);
        // call api method
    }

    function removeProductFromShoppingCart(product) {
        // call remove api method (product id & user id) 
        $('#shopping-cart').empty();
        initializeShoppingCart();
    }
    initializeProducts();
    initializeShoppingCart();
});