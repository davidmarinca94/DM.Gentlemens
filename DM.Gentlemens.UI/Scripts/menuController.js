var MenuController = function (serviceContext) {
    //trick to preserve the instance of the MenuController where 'this' changes its meaning
    var _self = this;
    var _homeController = new HomeController();
    var _suitController = new SuitController(serviceContext);
    var _shirtController = new ShirtController(serviceContext);
    var _jacketController = new JacketController(serviceContext);
    var _knitwearController = new KnitwearController(serviceContext);
    var _accessoryController = new AccessoryController(serviceContext);
    var _shoeController = new ShoeController(serviceContext);
    var _watchController = new WatchController(serviceContext);

    var _menuElements = [
        {
            Id: "Home",
            ContainerId: "divHomeContainer",
            Controller: _homeController
        },
        {
            Id: "Suits",
            ContainerId: "divSuitsContainer",
            Controller: _suitController
        },
        {
            Id: "Shirts",
            ContainerId: "divShirtsContainer",
            Controller: _shirtController
        },
        {
            Id: "Jackets",
            ContainerId: "divJacketsContainer",
            Controller: _jacketController
        },
        {
            Id: "Knitwear",
            ContainerId: "divKnitwearContainer",
            Controller: _knitwearController
        },
        {
            Id: "Accessories",
            ContainerId: "divAccessoriesContainer",
            Controller: _accessoryController
        },
        {
            Id: "Shoes",
            ContainerId: "divShoesContainer",
            Controller: _shoeController
        },
        {
            Id: "Watches",
            ContainerId: "divWatchesContainer",
            Controller: _watchController
        }
    ];

    this.GenerateMenu = function () {
        var jqNavbarContainer = $("#navbarContainer"); //ul ID
        for (i = 0; i < _menuElements.length; i++) {
            //this creates a li jQuery object
            var jqListItem = $("<li id='" + _menuElements[i].Id + "' class='nav-item'>")
                .append("<a class='nav-link' href='#'>" + _menuElements[i].Id + "</a>");
            jqNavbarContainer.append(jqListItem);
        }

        jqNavbarContainer.on("click", "li", goToPage);
    }

    function goToPage() {
        var jqSelectedListItem = $(this); //'this' is not the same as the one from 'this.GenerateMenu'
        //get the id of the clicked list item
        var selectedId = jqSelectedListItem.attr("id");
        var menuElementId;
        //get the containerId for the selected Id
        var selectedContainerId;
        for (index = 0; index < _menuElements.length; index++) {
            if (_menuElements[index].Id === selectedId) {
                selectedContainerId = _menuElements[index].ContainerId;
                menuElementId = index;
                //we found it, we exit the for
                break;
            }
        }

        if (!selectedContainerId) //is not undefined, null or ''
            return;

        var mainContainers = $("main > div");
        for (i = 0; i < mainContainers.length; i++) {
            if (mainContainers[i].id != selectedContainerId) {
                $(mainContainers[i]).hide();
            }
            else {
                $(mainContainers[i]).show();
                _menuElements[menuElementId].Controller.RenderPage();
            }
        }
    }
}