$(document).on("click", ".btn-delete", function () {
    var authorId = $(this).data("author-id")
    var bookId = $(this).data("book-id")
    alertify
        .confirm(`Bạn có chắc muốn gỡ tác giả với id = ${authorId} ?`, function () {
            window.location.href = `${baseUrl}/Home/DeleteAuthorFromBook?bookId=${bookId}&authorId=${authorId}`
        })
        .setHeader('Xóa')
        .set('labels', { ok: 'Đồng ý', cancel: 'Hủy' })
})