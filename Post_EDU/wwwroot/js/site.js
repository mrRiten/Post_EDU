function ShowFormComment() {
    var form = document.getElementById("commentForm");

    if (form.style.display === "none") {
        form.style.display = "block";
    }
    else {
        form.style.display = "none";
    }
}