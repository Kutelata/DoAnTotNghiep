$(document).on("click", ".btn-action-friend", function () {
    var action = $(this).data("action")
    var userFriendId = $(this).data("user-friend-id")
    var question = $(this).text().toLowerCase()
    if (confirm(`Are you sure want to ${question} friend with id = ${userFriendId}?`)) {
        window.location.href = `${baseUrl}/Home/${action}?userFriendId=${parseInt(userFriendId)}`
    } else {
        return false
    }
})