/*=============== SHOW MENU ===============*/
const navMenu = document.getElementById("nav-menu"),
  navToggle = document.getElementById("nav-toggle"),
  navClose = document.getElementById("nav-close");

/*===== Menu Show =====*/
/* Validate if constant exists */
if (navToggle) {
  navToggle.addEventListener("click", () => {
    navMenu.classList.add("show-menu");
  });
}

/*===== Hide Show =====*/
/* Validate if constant exists */
if (navClose) {
  navClose.addEventListener("click", () => {
    navMenu.classList.remove("show-menu");
  });
}

/*=============== IMAGE GALLERY ===============*/
function imgGallery() {
  const mainImg = document.querySelector(".details__img"),
    smallImg = document.querySelectorAll(".details__small-img");

  smallImg.forEach((img) => {
    img.addEventListener("click", function () {
      mainImg.src = this.src;
    });
  });
}

imgGallery();

/*=============== SWIPER CATEGORIES ===============*/
let swiperCategories = new Swiper(".categories__container", {
  spaceBetween: 24,
  loop: true,
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },

  breakpoints: {
    350: {
      slidesPerView: 2,
      spaceBetween: 24,
    },
    768: {
      slidesPerView: 3,
      spaceBetween: 24,
    },
    992: {
      slidesPerView: 4,
      spaceBetween: 24,
    },
    1200: {
      slidesPerView: 5,
      spaceBetween: 24,
    },
    1400: {
      slidesPerView: 6,
      spaceBetween: 24,
    },
  },
});

/*=============== SWIPER PRODUCTS ===============*/
let swiperProducts = new Swiper(".new__container", {
  spaceBetween: 24,
  loop: true,
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },

  breakpoints: {
    768: {
      slidesPerView: 2,
      spaceBetween: 24,
    },
    992: {
      slidesPerView: 4,
      spaceBetween: 24,
    },
    1400: {
      slidesPerView: 4,
      spaceBetween: 24,
    },
  },
});

/*=============== PRODUCTS TABS ===============*/
const tabs = document.querySelectorAll("[data-target]"),
  tabsContents = document.querySelectorAll("[content]");

tabs.forEach((tab) => {
  tab.addEventListener("click", () => {
    const target = document.querySelector(tab.dataset.target);

    tabsContents.forEach((tabsContent) => {
      tabsContent.classList.remove("active-tab");
    });

    target.classList.add("active-tab");

    tabs.forEach((tab) => {
      tab.classList.remove("active-tab");
    });

    tab.classList.add("active-tab");
  });
});


/*=============== MẢNG TIN TỨC ===============*/
      let news = document.getElementById('news');
  
      // Mảng các tin tức
      const newsArray = [
        "CHỈ CÒN 2 NGÀY DUY NHẤT - NHANH TAY CHỐT ĐƠN",
        "MIỄN PHÍ VẬN CHUYỂN NỘI THÀNH TP.HCM"
      ];
  
      // Hàm thay đổi tin tức
      let newsIndex = 0;
      function changeNews() {
        // Ẩn tin tức hiện tại với hiệu ứng mờ
        news.classList.add('hidden');
  
        setTimeout(() => {
          // Thay đổi tin tức sau khi mờ đi
          news.textContent = newsArray[newsIndex];
          newsIndex = (newsIndex + 1) % newsArray.length;
  
          // Hiện lại tin tức mới với hiệu ứng mờ
          news.classList.remove('hidden');
        }, 1000); // Chờ 1 giây (thời gian mờ đi) trước khi thay đổi tin tức
      }
  
      // Khởi động interval để thay đổi tin tức
      setInterval(() => {
        changeNews(); // Thay đổi tin tức
      }, 3000); // Thay đổi mỗi 2 giây
    

/*=============== Cập nhật số lượt đánh giá ===============*/
document.addEventListener("DOMContentLoaded", function () {
  // Lấy số lượt đánh giá từ tab "Đánh Giá"
  const reviewTab = document.querySelector(".detail__tab[data-target='#reviews']");
  const reviewCount = reviewTab.textContent.match(/\d+/); // Lấy số đầu tiên trong chuỗi

  // Cập nhật số lượt đánh giá trong phần thông tin sản phẩm
  const productReviewCount = document.querySelector(".details__rating .review-count");
  if (reviewCount && productReviewCount) {
    productReviewCount.textContent = `(${reviewCount[0]} đánh giá)`;
  }
});

/*=============== Khi nhấp vào số lượng đánh giá sẽ tự động cuộn đến tab đánh giá ===============*/
document.addEventListener("DOMContentLoaded", function () {
  // Lấy liên kết "Số lượt đánh giá"
  const reviewLink = document.querySelector(".review-count");
  const reviewsTab = document.querySelector(".detail__tab[data-target='#reviews']");
  const tabsContainer = document.querySelector(".detail__tabs"); // Phần chứa các tab

  reviewLink.addEventListener("click", function (event) {
    event.preventDefault(); // Ngăn hành động mặc định (chuyển hướng)

    // Kích hoạt tab "Đánh Giá"
    document.querySelector(".detail__tab.active-tab")?.classList.remove("active-tab");
    reviewsTab.classList.add("active-tab");

    // Ẩn nội dung tab khác và hiển thị nội dung "Đánh Giá"
    document.querySelector(".details__tab-content.active-tab")?.classList.remove("active-tab");
    document.querySelector("#reviews").classList.add("active-tab");

    // Cuộn đến phần tabsContainer
    tabsContainer.scrollIntoView({ behavior: "smooth" });
  });
});

/*=============== Khi nhấp vào sao đánh giá sẽ tự động cuộn đến mục thêm đánh giá ===============*/
document.addEventListener("DOMContentLoaded", function () {
  // Lấy danh sách ngôi sao
  const ratingStars = document.querySelectorAll(".details__rating .star");
  const reviewsTab = document.querySelector(".detail__tab[data-target='#reviews']");
  const reviewForm = document.querySelector(".review__form");

  ratingStars.forEach((star) => {
    star.addEventListener("click", function () {
      // Kích hoạt tab "Đánh Giá"
      document.querySelector(".detail__tab.active-tab")?.classList.remove("active-tab");
      reviewsTab.classList.add("active-tab");

      // Ẩn nội dung tab khác và hiển thị tab "Đánh Giá"
      document.querySelector(".details__tab-content.active-tab")?.classList.remove("active-tab");
      document.querySelector("#reviews").classList.add("active-tab");

      // Cuộn mượt đến phần "Thêm đánh giá"
      reviewForm.scrollIntoView({ behavior: "smooth" });
    });
  });
});

/*=============== Thêm đánh giá sản phẩm ===============*/
document.addEventListener("DOMContentLoaded", function () {
  const stars = document.querySelectorAll(".rating__star__form .star");  // Tất cả các ngôi sao
  const reviewForm = document.querySelector(".review__form form");
  let ratingValue = 0;  // Lưu trữ số sao người dùng chọn

  // Xử lý khi người dùng nhấp vào ngôi sao
  stars.forEach(star => {
    star.addEventListener("click", function () {
      ratingValue = parseInt(this.getAttribute("data-value"));
      highlightStars(ratingValue);  // Làm sáng các sao đã chọn
    });
  });

  // Xử lý khi người dùng hover vào sao (chỉ để thay đổi màu sắc sao)
  stars.forEach(star => {
    star.addEventListener("mouseover", function () {
      const hoverValue = parseInt(this.getAttribute("data-value"));
      highlightStars(hoverValue);  // Làm sáng sao khi hover
    });

    star.addEventListener("mouseout", function () {
      highlightStars(ratingValue);  // Giữ nguyên màu sắc sao đã chọn khi không hover
    });
  });

  // Hàm để làm sáng các sao
  function highlightStars(rating) {
    stars.forEach(star => {
      const starValue = parseInt(star.getAttribute("data-value"));
      if (starValue <= rating) {
        star.style.color = "#ffcc00";  // Màu vàng khi chọn
      } else {
        star.style.color = "#ccc";  // Màu xám khi chưa chọn
      }
    });
  }

  // Xử lý khi gửi form
  reviewForm.addEventListener("submit", function (event) {
    event.preventDefault();  // Ngăn gửi form (để kiểm tra thông tin)
    
    const username = reviewForm.querySelector("input[type='text']").value;
    const reviewText = reviewForm.querySelector("textarea").value;
    
    // Kiểm tra xem người dùng đã chọn sao chưa
    if (ratingValue === 0) {
      alert("Bạn vui lòng chọn số sao!");
      return;
    }

    // Kiểm tra xem các trường còn lại có hợp lệ không
    if (!username || !reviewText) {
      alert("Bạn vui lòng điền đầy đủ thông tin!");
      return;
    }

    // Reset form sau khi gửi
    reviewForm.reset();
    ratingValue = 0;  // Reset ratingValue khi gửi đánh giá
    highlightStars(0);  // Reset các sao về màu xám
    alert("Cảm ơn bạn đã đánh giá!");
  });
});



/*=============== Ngăn cuộn trang và hiện thông báo khi nhấn nút Thêm vào giỏ hàng ===============*/
document.addEventListener("DOMContentLoaded", function () {
  const addToCartButton = document.getElementById("add-to-cart");

  // Ngăn trang cuộn lên đầu khi nhấn nút "Thêm vào giỏ hàng"
  addToCartButton.addEventListener("click", function (event) {
    // Ngừng hành động mặc định (nếu có)
    event.preventDefault();
  });
});

// Lấy phần tử nút "Thêm vào giỏ hàng" qua ID
document.getElementById("add-to-cart").addEventListener("click", function (event) {
  event.preventDefault(); // Ngăn chặn hành động mặc định của thẻ <a>

  // Tạo thông báo
  const notification = document.createElement("div");
  notification.textContent = "Đã thêm vào giỏ hàng!";
  notification.style.position = "fixed";
  notification.style.bottom = "20px";
  notification.style.right = "20px";
  notification.style.backgroundColor = "#ff77c0b6";
  notification.style.color = "#fff";
  notification.style.padding = "10px 20px";
  notification.style.borderRadius = "5px";
  notification.style.boxShadow = "0 4px 6px rgba(0, 0, 0, 0.1)";
  notification.style.zIndex = "1000";
  notification.style.fontSize = "14px";

  // Thêm thông báo vào body
  document.body.appendChild(notification);

  // Tự động xóa thông báo sau 2 giây
  setTimeout(function () {
    notification.remove();
  }, 1500);
});
