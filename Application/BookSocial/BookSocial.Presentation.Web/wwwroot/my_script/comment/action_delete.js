$(document).on("click", ".btn-delete-comment", function () {
    var commentId = $(this).data("comment-id")
    if (confirm('Are you sure want to delete comment with id = ' + commentId + '?')) {
        window.location.href = `${baseUrl}/Home/DeleteComment?commentId=${commentId}`
    } else {
        return false
    }
})