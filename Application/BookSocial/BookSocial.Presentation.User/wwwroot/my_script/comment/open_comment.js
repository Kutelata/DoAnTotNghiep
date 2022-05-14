$(".btn-open-comment").click(function (e) {
    e.preventDefault()
    var reviewId = $(this).data('review-id')
    if ($(`.comment-${reviewId}`).hasClass("d-none")) {
        $(`.comment-${reviewId}`).removeClass("d-none")
        alert("remove")
    } else {
        $(`.comment-${reviewId}`).addClass("d-none")
        alert("add")
    }
})