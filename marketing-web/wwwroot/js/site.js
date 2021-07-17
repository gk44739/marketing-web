$(document).ready(function () {
  const landingSlider = new Swiper(".landingSlider", {
    pagination: {
      el: ".swiper-pagination",
      type: "progressbar",
    },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
  });

  const workSlider = new Swiper(".worksSlider", {
    slidesPerView: 1,
    centeredSlidesBounds: true,
    centeredSlidesBounds: true,
    initialSlide: 3,
    centeredSlides: true,
    center:true,
    spaceBetween: 40,
    grabCursor: true,
    pagination: {
      el: ".swiper-pagination",
      clickable: true,
    },
    breakpoints: {
      "@0.00": {
        slidesPerView: 1,
        spaceBetween: 10,
      },
      "@0.75": {
        slidesPerView: 2,
        spaceBetween: 20,
      },
      "@1.00": {
        slidesPerView: 3,
        spaceBetween: 40,
      },
      "@1.50": {
        slidesPerView: 4,
        spaceBetween: 50,
      },
    },
  });

  $(".hamburgerMenu").on("click", function (e) {
    if ($(e.currentTarget).hasClass("active")) {
      $(e.currentTarget).removeClass("active");
      $(e.currentTarget).siblings("nav").removeClass("active");
      $("body").removeClass("navActive");
      $(e.currentTarget)
        .siblings("nav")
        .children("ul")
        .children()
        .each(function (i, item) {
          $(item).removeClass("aos-init aos-animate");
        });
    } else {
      $(e.currentTarget).addClass("active");
      $(e.currentTarget).siblings("nav").addClass("active");
      $("body").addClass("navActive");
      $(e.currentTarget)
        .siblings("nav")
        .children("ul")
        .children()
        .each(function (i, item) {
          $(item).addClass("aos-init aos-animate");
        });
    }
  });

  if ($(window).width() < 992) {
    $(".animate-box").each(function (i, item) {
      $(item).attr("data-aos-delay", 100);
    });
  }

  $(window).on("resize", function () {
    if ($(window).width() < 992) {
      setTimeout(() => {
        $(".linksNavbar")
          .children()
          .each(function (i, item) {
            $(item).removeClass("aos-init aos-animate");
          });
      }, 50);
      $(".animate-box").each(function (i, item) {
        $(item).attr("data-aos-delay", 100);
      });
    }
  });
});
