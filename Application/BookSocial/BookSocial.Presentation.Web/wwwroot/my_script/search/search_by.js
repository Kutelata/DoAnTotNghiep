$("#btn-search-by").change(function (e) {
    e.preventDefault()
    var searchBy = $(this).val()
    var searchByBook = $(this).data("search-by-book")
    var searchByAuthor = $(this).data("search-by-author")
    if (searchBy == searchByBook) {
        window.location.href = `${baseUrl}/Home/SearchBook`
    }
    if (searchBy == searchByAuthor) {
        window.location.href = `${baseUrl}/Home/SearchAuthor`
    }
})