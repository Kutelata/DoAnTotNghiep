$(document).on("click", ".btn-delete-shelf", function () {
    var bookId = $(this).data("book-id")
    if (confirm('Are you sure want to delete book with id = ' + bookId + '?')) {
        window.location.href = `${baseUrl}/Home/DeleteShelf?bookId=${parseInt(bookId)}`
    } else {
        return false
    }
})