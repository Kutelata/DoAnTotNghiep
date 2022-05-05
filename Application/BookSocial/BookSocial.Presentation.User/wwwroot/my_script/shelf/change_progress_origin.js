$(".btn-change-progress-read-origin").change(function (e) {
    e.preventDefault()
    var progressReadOrigin = $(this).val()
    var userId = $(this).data('user-id')
    var bookId = $(this).data('book-id')
    $.ajax({
        method: "post",
        url: `${baseUrl}/Home/ChangeProgressReadOrigin`,
        data: { ProgressReadOrigin: progressReadOrigin, UserId: userId, BookId: bookId },
        success: function (data) {
            alert("Change progress read success!!!")
        },
        error: function (data) {
            alert("Change progress read fail!!!")
        }
    })
})