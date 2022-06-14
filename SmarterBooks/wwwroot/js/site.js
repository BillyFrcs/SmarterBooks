// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    $("#details-click").click(function () {
        $("#details-modal").modal('show');

        console.log("Show Modal");
    });

    $("#close").click(function () {
        $("#details-modal").modal('hide');
    });
});