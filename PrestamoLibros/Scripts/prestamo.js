

function AceptarBusClick()
{
    $("#CodE").val($("#CliSeleccionado").val());
    $("#oGrid").toggle();
    $("#NombCompleto").toggle();
    $("#bModal").modal("hide");
}

$(document).ready(function () {
    $(".calendario").datepicker(
       {dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '1980:2030'
        }
    );
});