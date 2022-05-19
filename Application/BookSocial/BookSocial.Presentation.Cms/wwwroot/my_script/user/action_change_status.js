$("#btn-change-status").change(function (e) {
    var userId = $(this).data("id")
    var userStatus = $(this).val()
    window.location.href = `${baseUrl}/Home/ChangeStatus?userId=${userId}&userStatus=${userStatus}`
})