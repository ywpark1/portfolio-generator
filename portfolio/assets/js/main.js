(function ($) {

	$(".hero-area-slider").owlCarousel({
		items: 1,
		loop: true,
		dots: true,
		animateIn: "fadeIn",
		animateOut: "fadeOut",
		mouseDrag: false,
	});

	$(".testimonial-slider").owlCarousel({
		items: 1,
		loop: true,
		dots: true,
	});

	// init Isotope
	var $grid = $('.portfolio-container').isotope({
		masonry: {
			gutter: 10,
		}
	});
	// filter items on button click
	$('.portfolio-filter').on('click', 'li', function () {
		var filterValue = $(this).attr('data-filter');
		$grid.isotope({
			filter: filterValue
		});
	});

	//On click change menu color
	$(".navbar-nav").on("click", "li", function () {
		$(".navbar-nav li").removeClass("active");
		$(this).addClass("active");
	});

	$('.scrl-down').on('click', function (e) {
		e.preventDefault();
		$('html, body').animate({
			scrollTop: $($(this).attr('href')).offset().top
		}, 1000, 'linear');
	});


	//On scroll menu fixed to top
	var menu = $("nav");
	$(window).scroll(function () {
		//more then or equals to
		if ($(window).scrollTop() < 800) {
			menu.removeClass('fixed-top animated slideInDown');

			//less then 100px from top
		} else {
			menu.addClass('fixed-top animated slideInDown');

		}
	});

//	$('.scrollbar-body').mCustomScrollbar({
//		theme: "dark",
//		mouseWheel: {
//			scrollAmount: 150
//		},
//		setHeight: '100%',
//	});

}(jQuery));
