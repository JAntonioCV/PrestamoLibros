﻿
function btnBuscarLi() {
    $("#linkBuscarLi").attr("href", function () {
        return ((this.href.replace('_Titu_', $("#bTitulo").val())).replace('_Auto_', $("#bAutor").val()));
    })
}

function btnBuscarCli() {

    //Selecciona el elemento por medio del selector id #linkBuscarEmp
    $("#linkBuscarCli").attr("href", function () {
        return ((this.href.replace('_Nom_', $("#bNombres").val())).replace('_Ape1_', $("#bApellido1").val()));
    })
}//fin del click buscarEmp


function SeleccionarCli(codSel) {
    $("#CliSeleccionado").val(codSel);
    $("#btnAceptarBus").removeAttr('disabled');
}