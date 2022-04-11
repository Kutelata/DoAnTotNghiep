$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id")
    if (confirm('Are you sure want to delete user with id = ' + id + '?')) {
        window.location.href = `${baseUrl}/Home/DeleteUser?id=${id}`
    } else {
        return false
    }
})