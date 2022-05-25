$("#btn-load-more").click(function (e) {
    e.preventDefault()

    var listReviewIdExclude = []
    $(`.box-display-review`).each((index, item) => {
        if (item.dataset) {
            listReviewIdExclude.push(item.dataset.reviewExclude)
        }
    })
    var stringReviewIdExclude = listReviewIdExclude.toString()

    $.ajax({
        method: "get",
        url: `${baseUrl}/Home/ReviewList`,
        data: { stringReviewIdExclude: stringReviewIdExclude },
        success: function (res) {
            $(".review-list").append(res)

            if ($.isFunction($.fn.chosen)) {
                $("select").chosen();
            }
        }
    })
})