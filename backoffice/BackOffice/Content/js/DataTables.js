var spanish = {
    "sProcessing": "Procesando...",
    "sLengthMenu": "Mostrar _MENU_ registros",
    "sZeroRecords": "No se encontraron resultados",
    "sEmptyTable": "Ningún dato disponible en esta tabla",
    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
    "sInfoPostFix": "",
    "sSearch": "Buscar:",
    "sUrl": "",
    "sInfoThousands": ",",
    "sLoadingRecords": "Cargando...",
    "oPaginate": {
        "sFirst": "Primero",
        "sLast": "Último",
        "sNext": "Siguiente",
        "sPrevious": "Anterior"
    },
    "oAria": {
        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
    }
};

$(document).ready(function () {
    $('#example').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            null,
            null,
            { "bSearchable": false },
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#ListarCategoria').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            { "bSearchable": false },
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#default').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            null,
            null,
            null,
            null,
            { "bSearchable": false },
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#default1').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            null,
            null,
            null,
            null,
            { "bSearchable": false },
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#MenuDia').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            null,
            { "bSearchable": false },
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#MenuDiaDashboard').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            null,
            { "bSearchable": false },
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#example2').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            null,
            null,
            { "bSearchable": false },
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#example3').DataTable({
        "language": spanish,
        "responsive": true,
        "aoColumns": [
            null,
            null,
            null,
            { "bSearchable": false },
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#dt-mesa').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            null,
            null,
            { "bSearchable": false },
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#CategoriaRest').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            { "bSearchable": false }
        ]
    });
});
$(document).ready(function () {
    $('#ZonaRest').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            { "bSearchable": false }
        ]
    });
});
$(document).ready(function () {
    $('#mesa').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            null,
            null,
            null,
            { "bSearchable": false },
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#contenido_ListarOrden').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            null,
            null,
            null,
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#contenido_Detalle').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            null,
            null,
            null,
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
    $('#contenido_Pago').DataTable({
        "language": spanish,
        "aoColumns": [
            null,
            null,
            null,
            null,
            { "bSearchable": false }
        ]
    });
});

$(document).ready(function () {
            $('#contenido_Menu1').DataTable({
                "language": spanish,
                "bAutoWidth": false,
                "aoColumns": [
                    null,
                     null,
                    null,
                    null,
                    { "bSearchable": false },
                    { "bSearchable": false }
                ]
            });
});