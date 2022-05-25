$("#btn-load-more").click(function (e) {
    e.preventDefault()
    var bookId = $(this).data("book-id")
    var listReviewIdExclude = []
    $(`.box-display-review`).each((index, item) => {
        if (item.dataset) {
            listReviewIdExclude.push(item.dataset.reviewExclude)
        }
    })
    var stringReviewIdExclude = listReviewIdExclude.toString()

    $.ajax({
        method: "get",
        url: `${baseUrl}/Home/ReviewByBookId`,
        data: { bookId: bookId, stringReviewIdExclude: stringReviewIdExclude },
        success: function (res) {
            $(".review-by-book-id").append(res)
        }
    })
})