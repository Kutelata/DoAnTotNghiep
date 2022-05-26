var host = $("#assign-author-value").data("host")
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
        $("#assign-author-birthday").text(ui.item.birthday)
        $("#assign-author-image").attr("src", `${host}${ui.item.image}`)
    }
})