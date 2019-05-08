function addCommentLi() {
    var time = "Just Now"
    var name = $("#name").val()
    var comment = $("#comment").val()

    var li = $(`<li><article><header><figure class="avatar"><img src="../images/demo/avatar.png" alt=""></figure>` +
        `<address>By <a href="#">${name}</a></address>` +
        `<p>${time}</p></header>` +
        `<div class="comcont"><p>${comment}</p></div></article></li>`);

    $(li).appendTo("#prices-comments-ul");

    var dataToSend = {
        "Username": name,
        "Content": comment
    }

    $.ajax(
            {
                type: "POST",
                traditional: true,
                contentType: "application/json",
                url: "tourpackages/createcomment",
                data: JSON.stringify(dataToSend),
            })
        .done(function(resp) {
            $('#comment').val("");
        })
        .fail(function(resp) {
            alert("Failure");
            console.dir(resp);
        });
}