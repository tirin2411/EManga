$(document).ready(function () {
    $(".listmn").owlCarousel({
        //autoPlay: true,
        //autoplayTimeOut: 5000,
        items: 4,
        itemsDesktop: [1199, 3],
        itemsDesktopSmall: [979, 3],
        loop: true,
        nav: true,
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            600: {
                items: 3,
                nav: false
            },
            1000: {
                items: 5,
                nav: true,
                loop: false
            }
        }
    });
    $(".listbanner").owlCarousel({
        autoPlay: true,
        autoplayTimeOut: 5000,
        items: 1,
        smartSpeed: 450,
        nav: true,
        loop: true,
        dots: true,
        animateIn: 'flipInX',
        animateOut: 'zoomOutDown'
    });
});