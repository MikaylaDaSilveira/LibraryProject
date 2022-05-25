/****************************************************************************
     * Add a new TodoItem.
     *
     * 1) send an update to the DB
     * 2) if successful then add the item to the list
     ****************************************************************************/
    function addNewBookInfoItem(newItemValue) {
        
        // Get the value from the Input field in the FORM
        let bookinfoDescriptionValue = document.getElementById("newBookInfoDescription").value.trim();
        let bookinfoAuthorValue = document.getElementById("newBookInfoAuthor").value.trim();
        let bookinfoYearValue = document.getElementById("newBookInfoYear").value.trim();

        // Check that a value have added
        if (bookinfoDescriptionValue === "" || bookinfoAuthorValue === "" || bookinfoYearValue === "") {
            alert("Please enter some values for your item");
            return;
        }
        createBookInfoItem(bookinfoDescriptionValue, bookinfoAuthorValue, bookinfoYearValue);
        document.getElementById("newBookInfoDescription").value = ""; createBookInfoItem
    }

    /****************************************************************************
     * This function will add the a new todo item to the UL element
     * Specifically this will add:
     *
     *   <li>the item description<span class="close">X</>li>
     *
     * 1) add to DB
     * 2) if successful then add the item to the list
     *
     ****************************************************************************/
function addBookInfoItemToDisplay(item) {
    let bookinfoItemNode = document.createElement("li");
        let descriptionTextNode = document.createTextNode(item["description"]);
        bookinfoItemNode.appendChild(descriptionTextNode);

    document.getElementById("bookinfoList").appendChild(bookinfoItemNode);

        let tickSpanNode = document.createElement("SPAN");
        let tickText = document.createTextNode("\u2713");  // \u2713 is unicode for the tick symbol
        tickSpanNode.appendChild(tickText);
        bookinfoItemNode.appendChild(tickSpanNode);
        tickSpanNode.className = "tickHidden";

        let closeSpanNode = document.createElement("SPAN");
        let closeText = document.createTextNode("X");
        closeSpanNode.className = "close";
        closeSpanNode.appendChild(closeText);
        bookinfoItemNode.appendChild(closeSpanNode);

        closeSpanNode.onclick = function (event) {
            // When the use press the "X" button, the click event is normally also passed to its parent element.
            // (i.e. the element containing the <SPAN>). In the case the LI element that is holding the TodoItem
            // which would have resulted in a toggle of item between "DONE" and "NEW"
            //
            // stopPropagation() tells the event not to propagate
            event.stopPropagation();

            if (confirm("Are you sure that you want to delete " + item.description + "?")) {
                deleteBookInfoItem(item["id"]);

                // Remove the HTML list element that is holding this todo item
                bookinfoItemNode.remove();
            }
        }

        bookinfoItemNode.onclick = function () {
            if (item["status"] === "NEW") {
                item["status"] = "DONE"
            } else {
                item["status"] = "NEW"
            }

            updateBookInfoItem(item);

            bookinfoItemNode.classList.toggle("checked");
            tickSpanNode.classList.toggle("tickVisible");
        }

        if (item["status"] !== "NEW") {
            bookinfoItemNode.classList.toggle("checked");
            tickSpanNode.classList.toggle("tickVisible");
        }
    }

    /****************************************************************************
     * CRUD functions calling the REST API
     ****************************************************************************/

function createBookInfoItem(bookinfoDescription, bookinfoAuthor, bookinfoYear) {

        // Create a new JSON object for the new item with the status of NEW
        // Since the id is generated by the microservice, we will use -1 as a dummy
        // If the POST is successful the microservice will store the new item in the database
        // and returns a JSON via the response with the generated id for the new item
    const newItem = {
        "BookTitle": bookinfoDescription, "BookAuthor": bookinfoAuthor, "BookYear": bookinfoYear};
        const requestOptions = {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(newItem)
    };
    
    fetch('https://localhost:7202/bookinfo', requestOptions)
        // get the JSON content from the response
        .then((response) => {
            if (!response.ok) {
                alert("An error has occurred.  Unable to create the Book item")
                throw response.status;
            } else return response.json();
        })

        // add the item to the UL element so that it will appear in the browser
        .then(item => addBookInfoItemToDisplay(item));
    }

    // Load the list - expecting an array of bookinfo_items to be returned
function readBookInfoItems() {
    fetch('http://localhost:5066/bookinfo')
            // get the JSON content from the response
            .then((response) => {
                if (!response.ok) {
                    alert("An error has occurred.  Unable to read the Book list")
                    throw response.status;
                } else return response.json();
            })
            // Add the items to the UL element so that it can be seen
            // As items is an array, we will the array.map function to through the array and add item to the UL element
            // for display
            .then(items => items.map(item => addBookInfoItemToDisplay(item)));
    }

function updateBookInfoItem(item) {
        const requestOptions = {
            method: 'PUT',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(item)
        };
    fetch('http://localhost:5066/bookinfo/' + item.id, requestOptions)
            .then((response) => {
                if (!response.ok) {
                    alert("An error has occurred.  Unable to UPDATE the Book item")
                    throw response.status;
                } else return response.json();
            })
    }

function deleteBookInfoItem(bookinfoItemId) {
    fetch(http://localhost:5066/bookinfo/ + bookinfoItemId, {method: 'DELETE'})
            .then((response) => {
                if (!response.ok) {
                    alert("An error has occurred.  Unable to DELETE the Book item")
                    throw response.status;
                } else return response.json();
            })
    }