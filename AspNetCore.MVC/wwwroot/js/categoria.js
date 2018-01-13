$(function () {

    var btn = $('#buttonCategoria');
    var input = $('#inputCategoria');

    btn.click(function (event) {
        var descricao = $('#inputCategoria').val();
        getDados(descricao);
    });

    input.keypress(function (event) {
        var descricao = input.val();
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == 13) {
            getDados(descricao);
        }
    });
});

function getDados(descricao) {

    $.get('/categoria/search?descricao=' + descricao + '')
        .done(function (response) {            
            montaTabela(response);
        });
}

function montaTabela(dados) {

    //remove linhas
    $('#tableCategorias').children('tbody').children('tr').remove();

    dados.forEach(function (dado) {

        var linha = novaLinha(dado);
        $('tbody').append(linha);
    });
}

function novaLinha(dado) {

    var id = dado.id;

    var novaLinha = $('<tr>');
    var colunaId = $('<td>').text(id);
    var colunaDescricao = $('<td>').text(dado.descricao);
    var colunaData = $('<td>').text(dado.dataCadastro);

    var colunaLinks = $('<td>');
    var span = $('<span>').addClass('pull-right');

    var linkEditar = $('<a>').addClass('btn').addClass('btn-success').addClass('margin-btn')
        .attr('href', '/Categoria/Edit/' + id + '').text('Editar');

    var linkDetalhes = $('<a>').addClass('btn').addClass('btn-primary').addClass('margin-btn')
        .attr('href', '/Categoria/Details/' + id + '').text('Detalhes');

    var linkRemover = $('<a>').addClass('btn').addClass('btn-danger').addClass('margin-btn')
        .attr('href', '/Categoria/Delete/' + id + '').text('Remover');

    span.append(linkEditar);
    span.append(linkDetalhes);
    span.append(linkRemover);

    colunaLinks.append(span);

    novaLinha.append(colunaId);
    novaLinha.append(colunaDescricao);
    novaLinha.append(colunaData);
    novaLinha.append(colunaLinks);

    return novaLinha;
}