function ValidateAuthor() {
    var authorName = $('#AuthorName');
    var authorNameError = $('.authorNameError');
    if (authorName.val() == null || authorName.val() == "") {
        console.log("Author Name is Empty");
        authorNameError.text("Tên tác giả không được bỏ trống");
       return false;
       
    } else {
        console.log("Create New Author Success");
        authorNameError.text("");
        return true;
     
    }
}

function CreateModal(url) {
    console.log(url);
    $('.model-create').load(url);
    $('.modalcreate').show();
}