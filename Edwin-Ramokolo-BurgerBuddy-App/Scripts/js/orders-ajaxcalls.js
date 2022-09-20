/// <reference path="../jquery-3.4.1.js" />
/// <reference path="../jquery-3.4.1.intellisense.js" />



function getSimulatedOrders() {
    var isSimulated = false;
    $.ajax({
        url: window.location.origin + '/api/Orders',
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {
            isSimulated = results;
        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return isSimulated;
}

function getSimulatedOrderCollection() {
    var isSimulated = false;
    $.ajax({
        url: window.location.origin + '/api/UpdateOrders',
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {
            isSimulated = results;
        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return isSimulated;
}

function getOrdersBeingPrepared() {
    var orders = null;
    $.ajax({
        url: window.location.origin + '/api/GetPreparingOrders',
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {
            orders = results;
        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return orders;
}

function getToysLeft() {
    var numberOfToys = false;
    $.ajax({
        url: window.location.origin + '/api/GetNumberOfSmileyMealsToday',
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {
            numberOfToys = 50 - results;
        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return numberOfToys;
}

///Check if store is closed
function getOutletStatus() {
    var isStoreOpen = false;
    $.ajax({
        url: window.location.origin + '/api/OutletClosed',
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {
            isStoreOpen = results;
        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return isStoreOpen;
}