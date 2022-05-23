$(document).on("change", ".btn-change-progress-read-origin", function (e) {
    e.preventDefault()
    var progressReadOrigin = $(this).val()
    var userId = $(this).data('user-id')
    var bookId = $(this).data('book-id')
    $.ajax({
        method: "post",
        url: `${baseUrl}/Home/ChangeProgressReadOrigin`,
        data: { ProgressReadOrigin: progressReadOrigin, UserId: userId, BookId: bookId },
        success: function (data) {
            alertify.success("Thay đổi tiến độ đọc thành công!!!")
        },
        error: function (data) {
            alertify.error("Thay đổi tiến độ đọc thất bại!!!")
        }
    })
})