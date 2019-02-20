self.addEventListener('install', function (event) {
    
});

self.addEventListener('fetch', function (event) {
    event.respondWith(
        caches.match(event.request)
            .then(function (response) {
                if (response) {
                    return response;
                }
                return fetch(event.request);
            }
            )
    );
});