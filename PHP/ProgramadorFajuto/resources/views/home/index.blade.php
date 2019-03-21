@extends('shared.layout')

@section('title', 'title')

@section('content')
<div id="content">
    <div class="container">
        <div class="row">
            <div class="col-xl-8 col-lg-8 col-md-8 col-sm-12 col-xs-12">
                    <section class="white">
                        <div class="post-cabecalho">
                            <ul>
                                    <li class="tag-cabecalho"><h1 class="center-block"></h1></li>
                            </ul>
                        </div>
                        <div class="conteudo">
                            <h3 class="text-uppercase"><b></b></h3>
                        </div>
                        <div class="conteudo">
                            <span class="opacity">em </span>, por @post.Autor.Nome
                        </div>
                        <div class="conteudo">
                            <h5></h5>
                        </div>
                        <div class="conteudo">
                            
                        </div>
                        <div class="conteudo">
                            <div class="row">
                                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                    <a class="button text-capitalize" href=""><b>Continue lendo</b></a>
                                </div>
                                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                    <h3 class="pull-right"><b>Comentarios</b><span class="tag"></span></h3>
                                </div>
                            </div>
                        </div>
                    </section>
                <div class="conteudo text-center">
                    <a href=""><</a>
                    <a href="">></a>
                </div>
            </div>
            <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-xs-12">
                <section class="white">
                    <div class="conteudo cinza">
                        <h4>Posts mais populares</h4>
                    </div>
                    <ul>
                            <li class="conteudo">
                                <a href="">
                                    <img src="~/img/designer.jpg" alt="" class="img-responsive rounded-circle" />
                                    <span></span><br />
                                    <span>
                                            <i class="tag"></i>
                                    </span>
                                </a>
                            </li>
                    </ul>
                </section>
            </div>
        </div>
    </div>
</div>
@endsection