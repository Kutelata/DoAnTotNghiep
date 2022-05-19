var baseUrl = window.location.origin
var queryParams = new URLSearchParams(window.location.search),
    page = queryParams.get('page'),
    search = queryParams.get('search'),
    sort = queryParams.get('sort')