$(document).ready(function () {
  const swiper = new Swiper(".landingSlider", {
    pagination: {
      el: ".swiper-pagination",
      type: "progressbar",
    },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
  });

  $('.hamburgerMenu').on('click',function(e) {

    if($(e.currentTarget).hasClass('active')){
      $(e.currentTarget).removeClass('active');
      $(e.currentTarget).siblings('nav').removeClass('active');
      $("body").removeClass('navActive');
    }else{
      $(e.currentTarget).addClass('active');
      $(e.currentTarget).siblings('nav').addClass('active');
      $("body").addClass('navActive');
    }
    

  });

  if($(window).width() < 992){
    $('.animate-box').each(function (i,item) {
      $(item).attr('data-aos-delay',100)
    });
  }
  
  $(window).on('resize',function () {
    if($(window).width() < 992){
      $('.animate-box').each(function (i,item) {
        $(item).attr('data-aos-delay',100)
      });
    }
  });

});
