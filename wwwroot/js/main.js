
$('.owl-carousel').owlCarousel({
  margin: 10,
  items: 1,
  autoplay: true,
  dots: true,
  loop: true,
  responsive: {
    0: { items: 1 },
    600: { items: 1 },
    1000: { items: 1 }
  }
});


let currentCard = 1; // Khởi tạo số thứ tự card hiện tại

function showCard(cardNumber) {
  // Ẩn tất cả các card
  const cards = document.querySelectorAll('.card-item');
  cards.forEach(function (card) {
    card.style.display = 'none';
  });

  // Hiển thị card của trang đã chọn
  const selectedCard = document.getElementById('card-' + cardNumber);
  if (selectedCard) {
    selectedCard.style.display = 'block';
    currentCard = cardNumber; // Cập nhật số thứ tự card hiện tại
  }
}

// Hàm hiển thị card trước đó
function showPrevCard() {
  if (currentCard > 1) {
    showCard(currentCard - 1);
  }
}

// Hàm hiển thị card tiếp theo
function showNextCard() {
  const totalCards = document.querySelectorAll('.card-item').length;
  if (currentCard < totalCards) {
    showCard(currentCard + 1);
  }
}

// Hiển thị card đầu tiên khi tải trang
showCard(1);

const sliderWrapper = document.querySelector('.slider-wrapper');
const items = document.querySelectorAll('.slider-item');
const itemsPerPage = 3; // Số thẻ hiển thị mỗi trang
const totalItems = items.length;
const totalPages = Math.ceil(totalItems / itemsPerPage); // Tính tổng số trang
let currentPage = 0;

document.getElementById('next').addEventListener('click', () => {
    // Chuyển đến trang tiếp theo
    currentPage = (currentPage + 1) % totalPages; 
    updateSlider();
});

document.getElementById('prev').addEventListener('click', () => {
    // Chuyển đến trang trước
    currentPage = (currentPage - 1 + totalPages) % totalPages; 
    updateSlider();
});

function updateSlider() {
    const offset = -currentPage * (100 / totalPages);
    sliderWrapper.style.transform = `translateX(${offset}%)`;
}