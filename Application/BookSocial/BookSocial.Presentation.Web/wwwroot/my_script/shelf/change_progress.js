$(".btn-change-progress-read").change(function (e) {
    e.preventDefault()
    var progressRead = $(this).val()
    var userId = $(this).data('user-id')
    var bookId = $(this).data('book-id')
    $.ajax({
        method: "post",
        url: `${baseUrl}/Home/ChangeProgressRead`,
        data: { ProgressRead: progressRead, UserId: userId, BookId: bookId },
        success: function (data) {
            alertify.success("Thay đổi tiến độ đọc thành công!!!")
        },
        error: function (data) {
            alertify.success("Thay đổi tiến độ đọc thất bại!!!")
        }
    })
})