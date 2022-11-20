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

//TĂNG GIẢM SỐ LƯỢNG SẢN PHẨM (JQUERY)
$('input.product__describe-custom-input').each(function () {
    var $this = $(this),
      qty = $this.parent().find('.is-form'),
      min = Number($this.attr('min')),
      max = Number($this.attr('max'))
    if (min == 0) {
        var d = 0
    }
    else d = min
    $(qty).on('click', function () {
        if ($(this).hasClass('product__describe-custom-reduced')) {
            if (d > min) d += -1
        } else if ($(this).hasClass('product__describe-custom-increase')) {
            var x = Number($this.val()) + 1
            if (x <= 11) d += 1
        }
        if (d >= 11) {
            d -= 1;
        }
        $this.attr('value', d).val(d)
    })
})

//THAY ĐỔI HÌNH ẢNH SẢN PHẨM
function changeImage(id) {
    let imagePath = document.getElementById(id).getAttribute('src');
    document.getElementById('img-main').setAttribute('src', imagePath);
}

//SHOW HIDE
function showHide1() {
    var showHide = document.getElementById("show-hide1");
    showHide.classList.toggle('active');
}

function showHide2() {
    var showHide = document.getElementById("show-hide2");
    showHide.classList.toggle('active');
}

function showHide3() {
    var showHide = document.getElementById("show-hide3");
    showHide.classList.toggle('active');
}

//-------------------- AUTO HIDE ALERT
window.setTimeout(function () {
    $(".alert-hide").fadeTo(10000, 0).slideUp(500, function () {
        $(this).remove();
    });
})