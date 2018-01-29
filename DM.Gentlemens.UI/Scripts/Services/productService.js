var ProductService = function (serviceContext) {
    var _categories = [
        {
            "CategoryID": "9e3480a5-d072-4d42-b926-248bfa4adda2",
            "CategoryName": "Watches",
        },
        {
            "CategoryID": "00034c18-086f-4e47-937a-2a4b5b2c764a",
            "CategoryName": "Ties",
        },
        {
            "CategoryID": "d8c5d334-18c0-4089-b577-54429adec7c7",
            "CategoryName": "Shirts",
        },
        {
            "CategoryID": "992cce09-61e0-4ba8-b0ea-71d42c2e4416",
            "CategoryName": "Knitwear",
        },
        {
            "CategoryID": "c4cf6309-0431-4fbb-8d77-85bec76d42ce",
            "CategoryName": "Shoes",
        },
        {
            "CategoryID": "c69705d2-f515-4ac0-87ca-97e07f5f854a",
            "CategoryName": "Accessories",
        },
        {
            "CategoryID": "71bca2d4-51dd-4a92-9706-ad9550587088",
            "CategoryName": "Suits",
        },
        {
            "CategoryID": "474e50ba-b690-4181-b291-d94543529a84",
            "CategoryName": "Pocket Squares",
        },
        {
            "CategoryID": "37288105-8b2e-404b-9657-dd8d684ede06",
            "CategoryName": "Jackets",
        },
        {
            "CategoryID": "c00c0e89-dc1d-4971-aa39-fd1ff09ffda8",
            "CategoryName": "Neckties",
        }
    ];

    var _products = [];
    $.ajax({
        crossDomain: true,
        url: 'http://localhost:52820/api/products',
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            $.each(data, function (key, val) {
                _products.push(val);
            });
        }
    });

    this.ReadAll = function (categoryName) {
        var retProducts = [];
        var categoryId = _categories.find(item => item.CategoryName == categoryName).CategoryID;
        retProducts =  _products.filter(item => item.CategoryID == categoryId);
        return retProducts;
    }


}