$(document).on("click", ".btn-delete-shelf", function () {
    var bookId = $(this).data("book-id")
    alertify
        .confirm(`Bạn có muốn xóa sách với id = ${bookId}?`, function () {
            window.location.href = `${baseUrl}/Home/DeleteShelf?bookId=${parseInt(bookId)}`
        })
        .setHeader('Xóa')
        .set('labels', { ok: 'Đồng ý', cancel: 'Hủy' })
})