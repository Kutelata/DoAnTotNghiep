$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id")
    if (confirm('Are you sure want to delete article with id = ' + id + '?')) {
        window.location.href = `${baseUrl}/Home/DeleteArticle?id=${id}`
    } else {
        return false
    }
})