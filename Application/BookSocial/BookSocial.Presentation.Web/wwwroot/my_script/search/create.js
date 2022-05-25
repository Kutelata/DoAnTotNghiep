// upload image
$("#img-file").change(function () {
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