$(document).on("click", ".btn-delete-comment", function (e) {
    e.preventDefault()
    var commentId = $(this).data("comment-id")
    if (confirm('Are you sure want to delete comment with id = ' + commentId + '?')) {
        $.ajax({
            method: "get",
            url: `${baseUrl}/Home/DeleteComment`,
            data: { commentId: commentId },
            success: function (res) {
                $(`.comment-id-${commentId}`).remove()
                alert('Delete comment success!')
            },
            error: function (res) {
                alert(res.responseText)
            }
        })
    } else {
        return false
    }
})