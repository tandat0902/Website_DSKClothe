//-------------------- SCROLL
window.addEventListener('scroll', function () {
    document.getElementById('hd-banner').classList.toggle('sticky', window.scrollY > 0);
});

window.addEventListener('scroll', function () {
    document.getElementById('hd-bot-sc').classList.toggle('sticky', window.scrollY > 0);
});

//-------------------- UNLOCK BUTTON
var btn_create = document.getElementById('btn-create');
var chkbox = document.getElementById('chkbox');

function unlock_btn() {
    if (chkbox.checked) {
        btn_create.classList.add('unlock-btn');
        document.querySelector(".btn-nor").disabled = false;
    }
    else {
        btn_create.classList.remove('unlock-btn');
        document.querySelector(".btn-nor").disabled = true;
    }
}

//-------------------- AUTO HIDE ALERT
//window.setTimeout(function () {
//    $(".alert").fadeTo(3000, 0).slideUp(500, function () {
//        $(this).remove();
//    });
//})