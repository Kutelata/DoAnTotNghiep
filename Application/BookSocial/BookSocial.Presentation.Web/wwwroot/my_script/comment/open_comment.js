var nextPage = 2

$(document).on("click", ".btn-open-comment", function (e) {
    e.preventDefault()
    var reviewId = $(this).data('review-id')
    if ($(`.comment-${reviewId}`).hasClass("d-none")) {
        $(`.comment-${reviewId}`).removeClass("d-none")

        if ($(`.comment-position-${reviewId}`).hasClass("d-none")) {
            $(`.comment-position-${reviewId}`).removeClass("d-none")
        }
        nextPage = 2

        $.ajax({
            method: "get",
            url: `${baseUrl}/Home/CommentInReview`,
            data: { reviewId: reviewId, page: 1 },
            success: function (res) {
                let isMoreData = res.isMoreData
                let html = res.partialView.result
                let nonCommentEle = $(`.my-non-comment`)
                if (nonCommentEle !== 0) {
                    nonCommentEle.remove()
                }
                if (!isMoreData) {
                    if (!$(`.comment-position-${reviewId}`).hasClass("d-none")) {
                        $(`.comment-position-${reviewId}`).addClass("d-none")
                    }
                }
                $(`.comment-position-${reviewId}`).before(html)
            },
            error: function () {
                let nonCommentEle = $(`.my-non-comment`)
                if (nonCommentEle.length === 0) {
                    $(`.comment-position-${reviewId}`).before(`<li class="my-non-comment">Không có comment</li>`)
                }
                if (!$(`.comment-position-${reviewId}`).hasClass("d-none")) {
                    $(`.comment-position-${reviewId}`).addClass("d-none")
                }
            }
        })
    } else {
        $(`.comment-${reviewId}`).addClass("d-none")
        $(`.comment-view-${reviewId}`).remove()
    }
})

$(document).on("click", ".btn-more-comment", function (e) {
    e.preventDefault()
    var reviewId = $(this).data('review-id')
    var listCommentIdExclude = []

    $(`.comment-view-${reviewId}`).each((index, item) => {
        if (item.dataset && item.dataset.actionBy == 'Insert') {
            listCommentIdExclude.push(parseInt(item.dataset.commentId))
        }
    })
    var stringCommentIdExclude = listCommentIdExclude.toString()

    $.ajax({
        method: "get",
        url: `${baseUrl}/Home/CommentInReview`,
        data: { reviewId: reviewId, page: nextPage, stringCommentIdExclude: stringCommentIdExclude },
        success: function (res) {
            let isMoreData = res.isMoreData
            let html = res.partialView.result
            if (html.trim().length != 0) {
                if (!isMoreData) {
                    if (!$(`.comment-position-${reviewId}`).hasClass("d-none")) {
                        $(`.comment-position-${reviewId}`).addClass("d-none")
                    }
                }
                $(`.comment-position-${reviewId}`).before(html)
                nextPage++
            } else {
                $(`.comment-position-${reviewId}`).addClass("d-none")
            }
        }
    })
})

$(document).on("submit", ".my-post-comment", function (e) {
    e.preventDefault()

    var form = $(this)
    var actionUrl = form.attr('action')
    var reviewId = form.data('review-id')

    $.ajax({
        type: "post",
        url: actionUrl,
        data: form.serialize(),
        success: function (res) {
            if (res.trim().length != 0) {
                $(`.post-comment-${reviewId}`).before(res)
                form[0].reset()
            }
        },
        error: function (res) {
            alertify.error(res.responseText)
        }
    })
})