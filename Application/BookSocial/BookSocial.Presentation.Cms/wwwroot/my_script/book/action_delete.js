$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id")
    if (confirm('Are you sure want to delete book with id = ' + id + '?')) {
        window.location.href = `${baseUrl}/Home/DeleteBook?id=${id}`
    } else {
        return false
    }
})