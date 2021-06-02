$(document).ready(function () {
    console.log("Hello World");
    var theForm = $("#theForm");
    theForm.hide();

    var button = $("#buyButton");

    button.on("click", function () {
        console.log("Buying...");
    })

    var productinfo = $(".product-info li");
    productinfo.on("click", function () {
        console.log("Clink on" + $(this).text());
    });

    var popup = $("#login-block .popup-form");
    $("#login-block .toggle-item").on("click", function () {
        popup.fadeToggle(250);
    });
});
