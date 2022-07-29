// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $(".bootstrap-star-rating-readonly").rating({
        displayOnly: true,
        showCaption: false,
        size: "sm"
    });

    $(".bootstrap-star-rating").rating({

        size: "sm",
        step: 1
    });
});
