$(document).on("click", ".btn-delete-review", function () {
    var reviewId = $(this).data("review-id")
    if (confirm('Are you sure want to delete review with id = ' + reviewId + '?')) {
        window.location.href = `${baseUrl}/Home/DeleteReview?reviewId=${reviewId}`
    } else {
        return false
    }
})