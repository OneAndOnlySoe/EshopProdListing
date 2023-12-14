/* =====================================
Template Name: Eshop
Author Name: Naimur Rahman
Author URI: http://www.wpthemesgrid.com/
Description: Eshop - eCommerce HTML5 Template.
Version:1.0
========================================*/
/*=======================================
[Start Activation Code]
=========================================
	01. Mobile Menu JS
	03. Sticky Header JS
	07. Quick View Slider JS
	13. Extra Scroll JS
	16. Scroll UP JS
	19. Preloader JS
=========================================
[End Activation Code]
=========================================*/ 
(function($) {
    "use strict";
     $(document).on('ready', function() {	
		
		/*====================================
			Mobile Menu
		======================================*/ 	
		$('.menu').slicknav({
			prependTo:".mobile-nav",
			duration:300,
			animateIn: 'fadeIn',
			animateOut: 'fadeOut',
			closeOnClick:true,
		});
		
		 /*====================================
		03. Sticky Header JS
		======================================*/
		 jQuery(window).on('scroll', function () {
			 if ($(this).scrollTop() > 200) {
				 $('.header').addClass("sticky");
			 } else {
				 $('.header').removeClass("sticky");
			 }
		 });


		/*=======================
		  Extra Scroll JS
		=========================*/
		$('.scroll').on("click", function (e) {
			var anchor = $(this);
				$('html, body').stop().animate({
					scrollTop: $(anchor.attr('href')).offset().top - 0
				}, 900);
			e.preventDefault();
		});
		
		/*====================================
			Scroll Up JS
		======================================*/
		$.scrollUp({
			scrollText: '<span><i class="fa fa-angle-up"></i></span>',
			easingType: 'easeInOutExpo',
			scrollSpeed: 900,
			animation: 'fade'
		});  
		
	});
		
	
	/*=====================================
	  Preloader JS
	======================================*/ 	
	//After 2s preloader is fadeOut
	$('.preloader').delay(3500).fadeOut('slow');
	setTimeout(function() {
	//After 2s, the no-scroll class of the body will be removed
	$('body').removeClass('no-scroll');
	}, 2000); //Here you can change preloader time
	 
})(jQuery);
