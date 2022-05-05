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
            alert("Change progress read success!!!")
        },
        error: function (data) {
            alert("Change progress read fail!!!")
        }
    })
})