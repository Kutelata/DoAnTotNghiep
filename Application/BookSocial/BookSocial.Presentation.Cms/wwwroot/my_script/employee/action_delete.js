$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id")
    if (confirm('Are you sure want to delete employee with id = ' + id + '?')) {
        window.location.href = `${baseUrl}/Home/DeleteEmployee?id=${id}`
    } else {
        return false
    }
})