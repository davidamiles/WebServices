//var mainMenu = new MenuItem("Main", null);
//mainMenu.SubMenuItems.push(new MenuItem("Item 1", "", function () { executeItem1(); }));
//mainMenu.SubMenuItems.push(new MenuItem("Item 2", "", function () { executeItem2(); }));
//mainMenu.SubMenuItems.push(new MenuItem("Item 3", "", function () { executeItem3(); }));//
//
//var menuItems = [];
//menuItems.push(mainMenu);
//
//var menu = new Menu(document.getElementById("menuContainerDiv"));
//menu.AddMenuItems(menuItems);
//
//
//
//
//.MenuContainer
//{
//    border: 1px solid black;
//}

//.MenuItem
//{
//    position: relative;
//    display: inline-block;
//}

//.MenuItem:hover .MenuContent
//{
//    display: block;
//}

//.MenuItemButton
//{
//    border: 1px solid #e5f0ff;
//    display: inline;    
//    color: black;
//    font-family: sans-serif;
//    font-size: 12px;    
//    background-color: white;
//    padding-bottom: 5px;
//    padding-left: 10px;
//    padding-right: 10px;
//    padding-top: 5px; 
//}

//.MenuItemButton:hover
//{
//    background-color: whitesmoke;
//    color: black;
//    cursor: pointer;
//}

//.MenuContent
//{
//    background-color:white;
//    position: absolute;
//    display: none;
//    min-width: 160px;    
//    box-shadow: 0px, 8px, 16px, 0px, rgba(0,0,0,0.2);
//}

//.MenuContent a
//{
//    color: black;
//    padding: 12px 16px;
//    display: block;
//    text-decoration: none;
//    font-family: sans-serif;
//    font-size: 12px;    
//}

//.MenuContent a:hover
//{    
//    background-color: whitesmoke;
//    cursor: pointer;
//}


function Menu(divContainer)
{
    var _menuItems = null;
    var _self = this;
    var _divContainer = divContainer;

    this.AddMenuItems = function (menuItems)
    {
        _menuItems = menuItems;
        addItems();
    }

    this.AddMenuItemsToAnchor = function (menuItems)
    {
        _menuItems = menuItems;
        addItemsToAnchor();
    }

    function addItems()
    {
        _menuItems.forEach(function (menuItem)
        {
            var div = document.createElement("div");
            div.className = "MenuItem";

            var menuItemButton = document.createElement("button");
            menuItemButton.innerHTML = menuItem.Name;
            menuItemButton.className = "MenuItemButton";

            if (menuItem.OnClickCallback != null)
            {
                menuItemButton.onclick = menuItem.OnClickCallback;
            }
            else
            {
                if (menuItem.Href != null)
                {
                    menuItemButton.onclick = function ()
                    {
                        window.location = menuItem.Href;
                    }
                }
            }

            div.appendChild(menuItemButton);

            var subMenuContentDiv = document.createElement("div");
            subMenuContentDiv.className = "MenuContent";

            menuItem.SubMenuItems.forEach(function (menuItem)
            {
                var anchor = document.createElement("a");
                anchor.innerHTML = menuItem.Name;

                if (menuItem.OnClickCallback != null)
                {
                    anchor.onclick = menuItem.OnClickCallback;
                }
                else
                {
                    anchor.href = menuItem.Href;
                }


                subMenuContentDiv.appendChild(anchor);
            });

            div.appendChild(subMenuContentDiv);
            _divContainer.appendChild(div);

        });
    }

    function addItemsToAnchor()
    {
        _menuItems.forEach(function (menuItem)
        {
            var subMenuContentDiv = document.createElement("div");
            subMenuContentDiv.className = "MenuContent";

            menuItem.SubMenuItems.forEach(function (menuItem)
            {
                var anchor = document.createElement("a");
                anchor.innerHTML = menuItem.Name;

                if (menuItem.OnClickCallback != null)
                {
                    anchor.onclick = menuItem.OnClickCallback;
                }
                else
                {
                    anchor.href = menuItem.Href;
                }

                subMenuContentDiv.appendChild(anchor);
            });

            _divContainer.appendChild(subMenuContentDiv);

        });
    }
}

function MenuItem(name, href, onClickCallback, useSingleAnchor)
{
    this.Name = name;
    this.Href = href;
    this.OnClickCallback = onClickCallback;
    this.SubMenuItems = [];
    this.UseSingleAnchor = useSingleAnchor;
}