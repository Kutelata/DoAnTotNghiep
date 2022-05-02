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

var filterOptions = $("#btn-filter")
var defaultSelected = filterOptions.data("default-selected")
$.each(filterOptions.children(), function (i, option) {
    if ($(option).val() == defaultSelected) {
        $(option).prop("selected", true);
    }
})
if (filter) {
    $.each(filterOptions.children(), function (i, option) {
        if ($(option).val() == filter) {
            $(option).prop("selected", true);
        } else {

        }
    })
}

$("#btn-filter").change(function (e) {
    e.preventDefault()
    var value = $(this).val()
    queryParams.set("filter", value)
    history.replaceState(null, null, "?" + queryParams.toString())
    window.location.href = window.location.href
})