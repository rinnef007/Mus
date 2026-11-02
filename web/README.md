# Web prototype — vòng lặp làm nông + chế biến (Babylon.js, bản dùng một lần)

## Câu hỏi test

Giống prototype Unity trước đó: nếu người chơi làm cuốc -> gieo ->
tưới -> thu hoạch, rồi chế biến và bán, họ có cảm thấy vòng lặp
khép kín và có tiến triển không? Biết là đúng nếu trong 10 phút
chơi thử, người chơi tự làm được ít nhất 3 vòng đầy đủ từ gieo
đến bán mà không cần hướng dẫn thêm.

## Cách chạy — không cần cài đặt gì

1. Pull repo Mus về máy bằng GitHub Desktop.
2. Mở file `web/index.html` bằng trình duyệt (cần mạng để tải
   Babylon.js từ CDN chính thức `https://cdn.babylonjs.com/babylon.js`).
3. Chơi ngay trong trình duyệt, không cần Unity Hub, không cần build.

## Cách chơi

- WASD hoặc phím mũi tên di chuyển, E tương tác với thứ ở gần nhất.
- Ruộng 4x4 ở giữa: E lần lượt là cuốc đất, gieo hạt, tưới nước,
  đợi cây lớn trong 8 giây, rồi thu hoạch được 2 lúa.
- Hộp vàng bên phải là trạm chế biến: 3 lúa -> 1 gạo, mất 3 giây.
- Hộp xanh bên trái là sạp chợ: 1 gạo -> 10 xu.
- Góc trái trên hiện hạt giống, lúa, gạo, xu. Ban đầu có 20 hạt giống.

## Cố tình cắt bỏ

Không menu, không lưu game, không nhạc, không animation Mixamo,
không dân làng, không Họp Làng, không mùa vụ, không cân bằng xanh,
không chăn nuôi, không quy hoạch đất. Camera là góc cố định theo
sau người chơi, chưa phải camera thứ ba xoay tự do cuối cùng.
Hình ảnh chỉ là khối đơn giản, chưa phải art thật.

## Quy tắc quan trọng

Code trong `web/` là bản dùng một lần để test ý tưởng trên web.
Code Unity trong `Assets/Prototype/` vẫn nằm trong repo làm lịch
sử, không được mang sang đây và không dùng chung với code web này.
Sau khi chơi thử, anh báo lại cho Rin: vòng lặp có hiểu không,
có nhàm không, có lỗi trình duyệt nào không, và anh đánh giá
PROCEED, PIVOT hay KILL cho ý tưởng này.
