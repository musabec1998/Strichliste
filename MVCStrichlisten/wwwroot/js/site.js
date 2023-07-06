// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Id und Namen des zu ändernden Benutzers in den modalen Dialog schreiben
$(".settings").on('click', function ()
{
    console.log($(this).val());
    console.log($(this).data("name"));

    $("#userId").val($(this).val());
    $("#userName").val($(this).data("name"));

});

// Modalen Dialog schließen
// Nötig wegen dem Ajax Aufruf
$("#closeModal").on('click', function ()
{
    $("#ModalForm").modal('hide');
});