$(document).on("submit", ".my-post-review", function (e) {
    e.preventDefault()

    var form = $(this)
    var actionUrl = form.attr('action')

    $.ajax({
        type: "post",
        url: actionUrl,
        data: form.serialize(),
        success: function (res) {
            if (res.trim().length != 0) {
                $(`.after-post-review`).after(res)
                form[0].reset()
                $(".postoverlay").fadeOut(500);
                alertify.success("Thêm đánh giá thành công!")
            }
        },
        error: function (res) {
            alertify.error(res.responseText)
        }
    })
})