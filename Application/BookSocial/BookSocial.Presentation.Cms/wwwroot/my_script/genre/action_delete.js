$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id")
    alertify
        .confirm(`Bạn có chắc muốn xóa thể loại với id = ${id} ?`, function () {
            window.location.href = `${baseUrl}/Home/DeleteGenre?id=${id}`
        })
        .setHeader('Xóa')
        .set('labels', { ok: 'Đồng ý', cancel: 'Hủy' })
})