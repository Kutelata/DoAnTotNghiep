$(document).on("click", ".btn-delete-comment", function (e) {
    e.preventDefault()
    var commentId = $(this).data("comment-id")
    alertify
        .confirm('Bạn có muốn xóa bình luận với id = ' + commentId + '?', function () {
            $.ajax({
                method: "get",
                url: `${baseUrl}/Home/DeleteComment`,
                data: { commentId: commentId },
                success: function (res) {
                    $(`.comment-id-${commentId}`).remove()
                    alertify.success('Xóa bình luận thành công!')
                },
                error: function (res) {
                    alertify.error(res.responseText)
                }
            })
        })
        .setHeader('Xóa')
        .set('labels', { ok: 'Đồng ý', cancel: 'Hủy' })
})