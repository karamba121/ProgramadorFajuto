var CACHE_NAME = 'programadorfajuto';
var urlsToCache = [
    '/',
    '/?homescreen=1',
    '/post',
    '/post?homescreen=1',
    '/ferramentas',
    '/ferramentas?homescreen=1',
    '/login',
    '/login?homescreen=1',
    '/lib/bootstrap/dist/css/bootstrap.min.css',
    '/lib/animate-css/animate.min.css',
    '/lib/sweetalert/dist/sweetalert.css',
    '/css/site.css',
    '/lib/jquery/dist/jquery.min.js',
    '/lib/popper.js/dist/umd/popper.min.js',
    '/lib/bootstrap/dist/js/bootstrap.min.js',
    '/lib/jquery-pjax/jquery.pjax.js',
    '/lib/sweetalert/dist/sweetalert.min.js',
    '/js/site.js',
    '/img/designer.jpg',
    '/icons/house.svg',
    '/icons/archive.svg',
    '/icons/garbage-1.svg',
    '/icons/login.svg',
    '/fonts/raleway-regular.ttf',
    '/favicon.ico'
];

self.addEventListener('install', function (event) {
    event.waitUntil(
        caches.open(CACHE_NAME).then(function (cache) {
            return cache.addAll(urlsToCache);
        }).catch(function (error) {
            console.log("Erro ao adicionar url's ao cache.", error);
        }));
});

self.addEventListener('fetch', function (event) {
    event.respondWith(
        caches.match(event.request).then(function (response) {
            return response || fetch(event.request);
        }).catch(function (error) {
            console.log("Erro ao retornar recurso do cache.", error);
        }));
});