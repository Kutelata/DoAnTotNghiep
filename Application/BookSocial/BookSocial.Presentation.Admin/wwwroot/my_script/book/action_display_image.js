$("#img-file").change(function () {
    //var i = $(this).prev('label').clone();
    //var file = $('#file-upload')[0].files[0].name;
    //$(this).prev('label').text(file);
    if (this.files && this.files[0]) {
        var ImageDir = new FileReader();
        ImageDir.onload = function (e) {
            $('#img-preview').attr('src', e.target.result);
        }
        $('#img-preview').removeClass("d-none");
        ImageDir.readAsDataURL(this.files[0]);
    } else {
        $('#img-preview').addClass("d-none");
    }
})