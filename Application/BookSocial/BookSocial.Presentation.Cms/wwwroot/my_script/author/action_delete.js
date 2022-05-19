$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id")
    if (confirm('Are you sure want to delete author with id = ' + id + '?')) {
        window.location.href = `${baseUrl}/Home/DeleteAuthor?id=${id}`
    } else {
        return false
    }
})