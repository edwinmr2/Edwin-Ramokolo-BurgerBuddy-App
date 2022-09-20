/// <reference path="../jquery-3.4.1.js" />
/// <reference path="../jquery-3.4.1.intellisense.js" />

$(function () {

    //Get Orders that are being prepared
    displayOrdersBeingPrepared();
    //Get Store information
    displayOutletInfo();

    //Every 5 seconds (Simmulating that every 5 seconds an order is being made)
    var intervalId = window.setInterval(function () {
        //Create Simulated orders 
        simmulateOrders();
        //Get Orders that are being prepared
        displayOrdersBeingPrepared();
        //Get Store information
        displayOutletInfo();

    }, 5000);

    //Auto Update Orders after 10 seconds of waiting time
    var intervalId = window.setInterval(function () {
        updateOrdersForCollection();
    }, 10000);

    //Force Simmulate Order
    $("#btnSubmit").click(function () {
        simmulateOrders();
    });
});

function simmulateOrders() {
    //Ensure that we are still in oparating HOurs 09h - 17h
    if (getOutletStatus())
        getSimulatedOrders();
}

function displayOrdersBeingPrepared() {
    var orders = getOrdersBeingPrepared();

    $('#listPreparingOrder').text("");
    $.each(orders, function (key, val) {
        $('#listPreparingOrder').append("<li class='list-group-item'>Order #: " + val.OrderNumber + " <br />Source: " + val.PaymentSource.Name + " - " + val.OrderDateTime.toLocaleString() + "</li>");
    });

    $("#numberOfWaitingCustomers").text(orders.length);
}

function displayOutletInfo() {

    var numberOfToysLeft = getToysLeft();
    if (numberOfToysLeft < 0)
        $("#numberOfToys").text("Please note that we do not have any Birdman toys for the day.");
    else
        $("#numberOfToys").text("Number of Birdman toys available " + numberOfToysLeft);

    if (getOutletStatus())
        $("#StoreStatus").text("Open");
    else {
        $("#StoreStatus").text("Closed");
        clearInterval(intervalId);
    }
    


}

function updateOrdersForCollection() {
    return getSimulatedOrderCollection();
}