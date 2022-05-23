$(document).on("click", ".btn-action-friend", function () {
    var action = $(this).data("action")
    var userFriendId = $(this).data("user-friend-id")
    var question = $(this).text().toLowerCase()

    alertify
        .confirm(`Bạn có muốn ${question} bạn với id = ${userFriendId}?`, function () {
            window.location.href = `${baseUrl}/Home/${action}?userFriendId=${parseInt(userFriendId)}`
        })
        .setHeader('Cảnh báo')
        .set('labels', { ok: 'Đồng ý', cancel: 'Hủy' })
})