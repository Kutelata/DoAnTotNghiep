$(document).on("click", ".btn-delete-review", function () {
    var reviewId = $(this).data("review-id")
    alertify
        .confirm(`Bạn có chắc muốn xóa đánh giá này?`, function () {
            window.location.href = `${baseUrl}/Home/DeleteReview?reviewId=${reviewId}`
        })
        .setHeader('Xóa')
        .set('labels', { ok: 'Đồng ý', cancel: 'Hủy' })
})