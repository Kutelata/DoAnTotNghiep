var host = $("#assign-author-value").data("host")

function getFormattedDate(date) {
    var convertDate = new Date(date)

    var year = convertDate.getFullYear()

    var month = (1 + convertDate.getMonth()).toString()
    month = month.length > 1 ? month : '0' + month

    var day = convertDate.getDate().toString()
    day = day.length > 1 ? day : '0' + day

    return day + '/' + month + '/' + year
}

$("#assign-author-value").autocomplete({
    source: function (request, response) {
        var data = []
        $.ajax({
            method: "get",
            url: `${baseUrl}/Home/AuthorData`,
            data: { search: request.term },
            success: function (res) {
                res.forEach(element => data.push({
                    "id": element.id,
                    "value": element.name,
                    "image": element.image,
                    "birthday": element.birthday,
                }))
                response(data)
            }
        })
    },

    select: function (e, ui) {
        $("#assign-author-birthday").removeClass("d-none")
        $("#assign-author-image").removeClass("d-none")

        $("#assign-author-id").val(parseInt(ui.item.id))
        $("#assign-author-birthday").text(getFormattedDate(ui.item.birthday))
        $("#assign-author-image").attr("src", `${host}${ui.item.image}`)
    }
})