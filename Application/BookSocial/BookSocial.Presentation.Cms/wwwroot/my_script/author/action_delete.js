$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id")
    alertify
        .confirm(`Bạn có chắc muốn xóa tác giả với id = ${id} ?`, function () {
            window.location.href = `${baseUrl}/Home/DeleteAuthor?id=${id}`
        })
        .setHeader('Xóa')
        .set('labels', { ok: 'Đồng ý', cancel: 'Hủy' })
})