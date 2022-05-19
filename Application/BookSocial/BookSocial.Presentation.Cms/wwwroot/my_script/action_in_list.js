if (search) {
    $("#search").val(search)
}

$("#btn-search").click(function (e) {
    e.preventDefault()
    var value = $("#search").val()
    queryParams.set('search', value)
    queryParams.set('page', 1)
    history.replaceState(null, null, "?" + queryParams.toString())
    window.location.href = window.location.href
})

if (sort) {
    var sortOptions = $("#btn-sort");
    $.each(sortOptions.children(), function (i, option) {
        if ($(option).val() == sort) {
            $(option).prop("selected", true);
        }
    })
}

$("#btn-sort").change(function (e) {
    e.preventDefault()
    var value = $(this).val()
    queryParams.set("sort", value)
    history.replaceState(null, null, "?" + queryParams.toString())
    window.location.href = window.location.href
})