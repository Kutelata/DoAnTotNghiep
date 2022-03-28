$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id")
    if (confirm('Are you sure want to delete genre with id = ' + id + '?')) {
        window.location.href = `${baseUrl}/Home/DeleteGenre?id=${id}`
    } else {
        return false
    }
})