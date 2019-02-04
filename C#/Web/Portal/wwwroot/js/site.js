(function (ProgramadorFajuto, $) {
    var tempo;

    var div = $('main #content')[1];
    if (div !== 'undefined') {
        $(div).unwrap();
    }

    ProgramadorFajuto.BloquearTela = function (clickDoMenu) {
        if (typeof (clickDoMenu) !== 'undefined') {
            setTimeout(function () { $('body').addClass('carregando'); }, 900);
        }

        else {
            $('body').addClass('carregando');
        }
    }

    ProgramadorFajuto.DesbloquearTela = function () {
        $('body').removeClass('carregando');
        setTimeout(function () { $('.white').addClass('animated fadeInDown'); }, 400);
    }

    ProgramadorFajuto.AdicionarMensagem = function (mensagem) {
        swal("Hum...", mensagem);
    }

    ProgramadorFajuto.AdicionarMensagemDeSucesso = function (mensagem) {
        swal("Deu bom!", mensagem, "success");
    }

    ProgramadorFajuto.AdicionarMensagemDeErro = function (mensagem) {
        swal("Opa, parece que deu ruim", mensagem, "error");
    }

    $(document).on('pjax:end', function (event) {
        var agora = new Date().getTime() - tempo;

        if (agora < 1400) {
            setTimeout(function () { ProgramadorFajuto.DesbloquearTela(); }, 1400 - agora);
        }

        else {
            ProgramadorFajuto.DesbloquearTela()
        }
    });

    $(window).on('load pjax:end', function () {
        PosicionarTags();
        ProgramadorFajuto.DesbloquearTela();
    });

    $('#gatilho').on('click', function () {
        MostrarMenu(!$('#cabecalho').hasClass('exposto'));
    });

    $('#menu').on('click', 'li a', function (event) {
        var selecionado = $(this);

        selecionado.parent('li').addClass('selecionado').siblings('li').removeClass('selecionado');
        AtualizarMenuSelecionado('fechar');

        if ($.support.pjax) {
            tempo = new Date().getTime();
            ProgramadorFajuto.BloquearTela(true);
            $.pjax.click(event, { container: '#content', fragment: '#content' });
        }
    });

    $(window).on('resize', function () {
        window.requestAnimationFrame(AtualizarMenuSelecionado);
    });

    MostrarMenu = function (mostrar) {
        if (typeof (mostrar) === 'undefined') mostrar = true;

        $('#cabecalho').toggleClass('exposto', mostrar);
        $('#nav').toggleClass('exposto', mostrar);
        $('main').toggleClass('exposto', mostrar).one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function () {
            mostrar && AtualizarMenuSelecionado();
        });
    }

    function AtualizarMenuSelecionado(tipo) {
        var itemSelecionado = $('.selecionado'),
            posicaoDoItemSelecionado = itemSelecionado.index() + 1,
            posicaoAhEsquerda = itemSelecionado.offset().left,
            marcador = $('.marcador');

        marcador.removeClassPrefix('cor').addClass('cor-' + posicaoDoItemSelecionado).css({
            'left': posicaoAhEsquerda,
        });

        if (tipo === 'fechar') {
            marcador.one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function () {
                MostrarMenu(false);
            });
        }
    }

    PosicionarTags = function () {
        $('.post-cabecalho ul').each(function (i, item) {
            var tags = $(item).find('li');

            tags.each(function (j, tag) {
                $(tag).css({
                    width: (100 / tags.length) + '%'
                });
            });

        });
    }

    $.fn.removeClassPrefix = function (prefix) {
        this.each(function (i, el) {
            var classes = el.className.split(" ").filter(function (c) {
                return c.lastIndexOf(prefix, 0) !== 0;
            });

            el.className = $.trim(classes.join(" "));
        });

        return this;
    };
})(window.ProgramadorFajuto = window.ProgramadorFajuto || {}, jQuery);