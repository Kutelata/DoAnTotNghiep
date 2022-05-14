var nextPage = parseInt($("#btn-load-more").data("current-page")) + 1
$("#btn-load-more").click(function (e) {
    e.preventDefault()
    $.ajax({
        method: "get",
        url: `${baseUrl}/Home/ReviewList`,
        data: { page: nextPage },
        success: function (res) {
            $(".review-list").append(res)
            nextPage++

            if ($.isFunction($.fn.chosen)) {
                $("select").chosen();
            }
        }
    })
})