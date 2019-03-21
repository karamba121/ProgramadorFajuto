<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="/css/app.css">
<title>{{ $title }}</title>
</head>
<body class="carregando">
    @include('shared.header')
            
    <main>
        <div id="content">
            @yield('content')
        </div>
    </main>
            
    @include('shared.menu')

    <script src="/js/app.js"></script>

    @section('scripts')
    @include('shared.messages')
</body>

                