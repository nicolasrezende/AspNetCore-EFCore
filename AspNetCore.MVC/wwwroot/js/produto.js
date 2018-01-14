$(function () {

    var btn = $('#buttonProduto');
    var input = $('#inputProduto');
    var select = $('#selectCategorias');

    btn.click(function (event) {

        var descricao = input.val();
        var categoria = select.val();
        getDados(descricao, categoria);
    });

    input.keypress(function (event) {

        var descricao = input.val();
        var categoria = select.val();
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == 13) {
            getDados(descricao, categoria);
        }
    });
});

function getDados(descricao, categoria) {

    
    $.get('produto/search?categoria=' + categoria + '&descricao=' + descricao + '')
        .done(function (response) {
            montaTabela(response);
        })
        .fail(function (erro) {
            $('#erroProduto').removeAttr('hidden');
        });
}

function montaTabela(dados) {

    //remove linhas
    $('#tableProdutos').children('tbody').children('tr').remove();

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
    var colunaPreco = $('<td>').text(dado.precoUnitario.toLocaleString('pt-br',
        {style: 'currency', currency: 'BRL'}));
    var colunaCategoria = $('<td>').text(dado.categoria.descricao);

    var colunaLinks = $('<td>');
    var span = $('<span>').addClass('pull-right');

    var linkEditar = $('<a>').addClass('btn').addClass('btn-success').addClass('margin-btn')
        .attr('href', '/Produto/Edit/' + id + '').text('Editar');

    var linkDetalhes = $('<a>').addClass('btn').addClass('btn-primary').addClass('margin-btn')
        .attr('href', '/Produto/Details/' + id + '').text('Detalhes');

    var linkRemover = $('<a>').addClass('btn').addClass('btn-danger').addClass('margin-btn')
        .attr('href', '/Produto/Delete/' + id + '').text('Remover');

    span.append(linkEditar);
    span.append(linkDetalhes);
    span.append(linkRemover);

    colunaLinks.append(span);

    novaLinha.append(colunaId);
    novaLinha.append(colunaDescricao);
    novaLinha.append(colunaPreco);
    novaLinha.append(colunaCategoria);
    novaLinha.append(colunaLinks);

    return novaLinha;
}