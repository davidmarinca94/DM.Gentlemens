var MenuControllerFooter = function () {
    //trick to preserve the instance of the MenuController where 'this' changes its meaning
    var _self = this;

    var _menuElementsFooter = [
        {
            Id: "About",
            ContainerId: "divAboutContainer"
        },
        {
            Id: "Shipping",
            ContainerId: "divShippingContainer"
        },
        {
            Id: "Help",
            ContainerId: "divHelpContainer"
        }
    ];

    this.GenerateMenuFooter = function () {
        var jqNavbarContainerFooter = $("#navbarContainerFooter"); //ul ID
        for (i = 0; i < _menuElementsFooter.length; i++) {
            //this creates a li jQuery object
            var jqListItemFooter = $("<li id='" + _menuElementsFooter[i].Id + "' class='nav-item'>")
                .append("<a class='nav-link' href='#'>" + _menuElementsFooter[i].Id + "</a>");
            jqNavbarContainerFooter.append(jqListItemFooter);
        }

        jqNavbarContainerFooter.on("click", "li", goToPageFooter);
    }

    function goToPageFooter() {
        var jqSelectedListItemFooter = $(this); //'this' is not the same as the one from 'this.GenerateMenu'
        //get the id of the clicked list item
        var selectedIdFooter = jqSelectedListItemFooter.attr("id");
        //get the containerId for the selected Id
        var selectedContainerIdFooter;
        for (index = 0; index < _menuElementsFooter.length; index++) {
            if (_menuElementsFooter[index].Id === selectedIdFooter) {
                selectedContainerIdFooter = _menuElementsFooter[index].ContainerId;
                //we found it, we exit the for
                break;
            }
        }

        if (!selectedContainerIdFooter) //is not undefined, null or ''
            return;

        var mainContainers = $("main > div");
        for (i = 0; i < mainContainers.length; i++) {
            if (mainContainers[i].id != selectedContainerIdFooter) {
                $(mainContainers[i]).hide();
            }
            else {
                $(mainContainers[i]).show();
            }
        }
    }
}