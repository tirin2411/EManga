
var CartController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }
    function registerEvents() {
        $('.btn-plus').on('click',  function (e) {
            e.preventDefault();
            const magaId = $(this).data('id');
            const soluong = parseInt($('#quantity_' + magaId).val()) + 1;
            updateCart(magaId, soluong);
        });

        $('body').on('click', '.minus', function (e) {
            e.preventDefault();
            const magaId = $(this).data('id');
            const soluong = parseInt($('#quantity_' + magaId).val()) - 1;
            updateCart(magaId, soluong);
        });

    }

    function updateCart(magaId, soluong) {
        $.ajax({
            type: "POST",
            url: '/Cart/UpdateCart',
            data: {
                magaId: magaId,
                soluong: soluong
            },
            success: function (res) {
                //console.log(res);
                //$('#quantity').text(res.length);
                $('#quantity_' + magaId).val();
                loadData();
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
    function loadData() {
        $.ajax({
            type: "GET",
            url: '/Cart/GetListItems',
            success: function (result) {
                //if (parseInt(msg) != 0)    // nối không bị lỗi
                //{
                //    $('#product-cart').html(msg);    // đổ giữ liệu kiểu html vào pageContet khi đã lấy được về
                //    $('#loading').css('visibility', 'hidden');    // ẩn hình thông báo trạng thái nạp dữ liệu
                //}
                //$('.leftcolumncart').html(msg); 
                $('#quantity').text(res.length);
                alert('Cập nhật giỏ hàng thành công.');
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}


//$(document).ready(function () {
//    var quantitiy = 1;
//    $('.plus').click(function (e) {
//        // Stop acting like a button
//        e.preventDefault();
//        // Get the field name
//        var quantity = parseInt($('#quantity').val());
//        // If is not undefined
//        $('#quantity').val(quantity + 1);
//        // Increment
//    });

//    $('.minus').click(function (e) {
//        // Stop acting like a button
//        e.preventDefault();
//        // Get the field name
//        var quantity = parseInt($('#quantity').val());

//        // If is not undefined

//        // Increment
//        if (quantity > 1) {
//            $('#quantity').val(quantity - 1);
//        }
//    });
//});