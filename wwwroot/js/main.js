$('.owl-carousel').owlCarousel({
    loop:false,
    margin:10,
    items: 1,
    autoplay: true,
    dots: true, 
    loop: true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
})

let currentCard = 1; // Khởi tạo số thứ tự card hiện tại

function showCard(cardNumber) {
  // Ẩn tất cả các card
  const cards = document.querySelectorAll('.card-item');
  cards.forEach(function(card) {
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
