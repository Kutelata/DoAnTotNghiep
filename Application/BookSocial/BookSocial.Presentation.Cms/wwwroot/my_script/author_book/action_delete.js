$(document).on("click", ".btn-delete", function () {
    var authorId = $(this).data("author-id")
    var bookId = $(this).data("book-id")
    if (confirm('Are you sure want to delete author from book with id = ' + authorId + '?')) {
        window.location.href = `${baseUrl}/Home/DeleteAuthorFromBook?bookId=${bookId}&authorId=${authorId}`
    } else {
        return false
    }
})