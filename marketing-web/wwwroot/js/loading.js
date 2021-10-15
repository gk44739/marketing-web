// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).on('submit', 'form', function () {
    showLoading();
    var button = $(this).find(':submit');
    setTimeout(function () {
        button.attr('disabled', 'disabled');
    }, 0);
});
$(document).on('invalid-form.validate', 'form', function () {
    hideLoading();
    var button = $(this).find(':submit');
    setTimeout(function () {
        button.removeAttr('disabled');
    }, 1);
});

//per me shfaq loading barin
function showLoading() {
    $('#modalLoading').modal({
        backdrop: 'static',
        keyboard: false
    });
    $("#modalLoading").modal('show');
}

//per me hjek loading barrin
function hideLoading() {
    setTimeout(
        function () {
            $("#modalLoading").modal('hide');
        }, 500);
}
