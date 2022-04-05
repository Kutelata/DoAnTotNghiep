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
                }))
                response(data)
            }
        })
        
    },

    select: function (e, ui) {
        $("#assign-author-id").val(ui.item.id)
    },

    change: function (e, ui) {
        $("#assign-author-id").val(ui.item.id)
    }
})