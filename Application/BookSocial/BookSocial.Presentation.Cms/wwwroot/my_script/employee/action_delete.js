$(document).on("click", ".btn-delete", function () {
    var id = $(this).data("id")
    alertify
        .confirm(`Bạn có chắc muốn xóa nhân viên với id = ${id} ?`, function () {
            window.location.href = `${baseUrl}/Home/DeleteEmployee?id=${id}`
        })
        .setHeader('Xóa')
        .set('labels', { ok: 'Đồng ý', cancel: 'Hủy' })
})