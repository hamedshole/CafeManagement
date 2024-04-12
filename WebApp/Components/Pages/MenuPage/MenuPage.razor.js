export function InitScrollSpy() {
    debugger
    //window.onwheel+=GoToHeader("header2")
    //document.getElementById("cat1").addEventListener("wheel", myFunction);
    document.getElementById('closeModalBtn').addEventListener('click', (e) => {
        e.preventDefault();
        document.getElementById('root').classList.remove('--modal-open');
        document.getElementById('modalContainer').classList.remove('--open');
        $('body').removeClass('scrollremove');
    })
   
}
export function myFunction() {
    debugger
    this.style.fontSize = "35px";
}
export function GoToSection(secid, headerid) {
    debugger
    var sec = document.getElementById(secid)
    var headeroffset = 140
    var elementposition = sec.getBoundingClientRect().top
    var offsetpostion = elementposition + window.pageYOffset - headeroffset
    window.scrollTo({
        top: offsetpostion,
        behavior: "smooth"
    })

    var p = document.getElementsByClassName("swiper-slide-active").item(0).classList.remove("swiper-slide-active")
    var p = document.getElementById(headerid).classList.add("swiper-slide-active")
}
export function GoToHeader(headerid) {
    debugger
    var h = document.getElementById(header1)
    var p = document.getElementsByClassName("swiper-slide-active").item(0).classList.remove("swiper-slide-active")
    var p = document.getElementById(headerid).classList.add("swiper-slide-active")

}

export function ShowProduct() {
    $('#modalContainer').addClass('is-loading');
    $('#modal-img').css('background-image', '');
    $('#modal-addons').empty();
    $('#modal-img').removeClass('no-image');
    $('#modal-img').css('background-image', '');
    //$.ajax({
    //    type: 'POST',
    //    url: url('ajax/user.get.productinfo.html'),
    //    dataType: "json",
    //    data: { id: id },
    //    success: function (data) {
    //        if (data.status == 'ok') {
    //            $('#modalContainer').removeClass('is-loading');
    //            $('#modal-price').empty();
    //            if (data.waitingstatus == 'ok') {
    //                $('#modal-time').text('زمان آماده سازی : ' + data.waiting + ' دقیقه');
    //                $('#modal-time').css('opacity', 1);
    //            } else {
    //                $('#modal-time').css('opacity', 0);
    //            }
    //            $('#modal-name').text(data.title);
    //            $('#modal-description').text(data.meta);
    //            $('#name_charge_mavad_down').text(data.name + '   (' + data.type + ')');
    //            $("#store_id_down").val(data.id);
    //            $("#charge_box_down").addClass("show-charge-down");
    //            $('#modal-addons').append(data.addons);
    //            if (data.imgempty == true) {
    //                $('#modal-img').addClass('no-image');
    //            } else {
    //                $('#modal-img').css('background-image', 'url(' + data.img + ')');
    //            }
    //            if (data.addonsempty == true) {
    //                $('#main_modal_product').addClass('no-addons');
    //            } else {
    //                if ($('#main_modal_product').hasClass('no-addons')) {
    //                    $('#main_modal_product').removeClass('no-addons');
    //                }
    //            }
    //            if (data.active == 0) {
    //                $('#modal-price').addClass('endedsale');
    //                $('#modal-price').append('<p>ناموجود</p>');
    //            } else if (data.enddsaletime == true) {
    //                $('#modal-price').addClass('endedsale');
    //                $('#modal-price').append('<p>تمام شد</p>');
    //            } else {
    //                if ($('#modal-price').hasClass('endedsale')) {
    //                    $('#modal-price').removeClass('endedsale');
    //                }
    //                $('#modal-price').append('<span>T</span><p id="modal-price">' + data.price + '</p>');
    //            }
    //            if (data.discount == true) {
    //                $('#modal-discount').append('<p>' + data.discount_number + '</p>');
    //                $('#modal-discount').show();
    //            } else {
    //                $('#modal-discount').empty();
    //                $('#modal-discount').hide();
    //            }
    //        }
    //    }
    //});






    $('#root').addClass('--modal-open');
    $('#modalContainer').addClass('--open');
    $('body').addClass('scrollremove');
}