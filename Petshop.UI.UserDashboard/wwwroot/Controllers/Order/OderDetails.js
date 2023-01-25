

function showConfirmModal(Id) {
    $.get("OrderInfoConfirm/" + Id).done(function (data) {
        $(".modal-body").html(data);
        $("#confirm").modal();
    });
}
function DeleleOrderInfo(Id) {
    $.get("OrderInfoDelete/" + Id).done(function (data) {
        $(".modal-body").html(data);
        $("#DeleleOrderInfo").modal();
    });
}