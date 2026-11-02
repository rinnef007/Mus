# Farming System — Hạt Mầm Vàng (Web — Babylon.js)

> **Status**: Draft — chưa qua design-review, chưa chốt số liệu cuối.
> **System**: Farming System, Category: Gameplay, Priority: MVP (Village stage).
> **Source**: design/gdd/game-concept.md, design/gdd/systems-index.md.
> **Engine**: Babylon.js web, JavaScript, in `web/`. This design replaces
> the Unity farming prototype; it does not reuse Unity C# code.
> **Depends on**: Player Controller & Camera, Time & Seasonal System.
> **Feeds into**: Inventory & Items, Processing & Supply Chain,
> Economy & Currency, Livestock System (manure), Land Planning,
> Green Balance & Pollution, Residents & Relationships.

---

## 1. Overview — hệ thống này làm gì, vì sao tồn tại

Farming là vòng lặp tay chân đầu tiên và là nguồn vốn + nguyên liệu
cho toàn bộ làng. Người chơi tự cuốc, gieo, tưới, thu hoạch trên
từng ô ruộng, chứ không giao ruộng cho hệ thống tự chạy. Mỗi vụ mùa
thành công cho ra nông sản để ăn, để chế biến, để bán và để đầu tư
cho dân làng nâng cấp sạp — đúng chuỗi khép kín đã chốt trong
concept: ruộng của người chơi -> xưởng chế biến của dân -> chợ.

Hệ thống này phải trả lời được 3 câu hỏi trong lúc chơi:
- Hôm nay mình trồng gì, ở đâu, và có kịp thu hoạch trước khi đổi mùa không?
- Đất của mình có đang bị bào mòn vì trồng mãi một loại không?
- Hạt giống thu được có tốt hơn hạt giống ban đầu không?

## 2. Goals — thành công là gì

- Vòng 30 giây phải đọc được ngay: nhìn ô ruộng là biết nó đang ở
  trạng thái nào, cần làm gì tiếp, không cần mở bảng tra cứu.
- Một vụ mùa phải có quyết định, không phải chỉ bấm E lặp lại:
  chọn giống theo mùa, theo đất, theo thời gian còn lại của mùa.
- Làm nông giỏi phải được thưởng bằng hạt giống tốt hơn và đất khỏe
  hơn, không phải chỉ bằng số lượng nhiều hơn.
- Làm nông ẩu phải trả giá nhẹ và sửa được: năng suất giảm, chất
  lượng giảm, chứ không mất trắng cả vụ trong MVP.

## 3. Pillar alignment — gắn với 4 trụ đã chốt

- **Quy mô phải có ý nghĩa**: ruộng bắt đầu nhỏ, mở rộng bằng cách
  khai hoang và đầu tư, không cho sẵn cả cánh đồng lớn ngay từ đầu.
- **Làng là cộng đồng, không phải tài nguyên**: nông sản dư dùng để
  nuôi dân và đầu tư cho sạp của dân, không chỉ để bán lấy xu.
- **Xanh là giới hạn thật**: trồng liên tục không nghỉ làm đất bạc
  màu, năng suất giảm, và đó là tín hiệu để người chơi luân canh
  hoặc để đất nghỉ, trước khi hệ thống Green Balance phạt nặng hơn.
- **Di sản tiếp nối**: hạt giống tốt giữ lại được qua các mùa và
  truyền cho vụ sau, là dạng di sản nhỏ nhất và dễ hiểu nhất của
  game trước khi có hệ thống thế hệ đầy đủ.

## 4. Core mechanics — chơi như thế nào

### 4.1. Ô ruộng và công cụ

- Một ô ruộng là đơn vị nhỏ nhất. Người chơi đứng gần ô, bấm E để
  làm việc phù hợp với trạng thái của ô, giống prototype.
- Công cụ trong MVP chỉ có 3 thứ, không cần chọn công cụ phức tạp:
  cuốc, hạt giống, bình tưới. Sau này Town stage mới tính tới máy móc.
- Trạng thái ô, theo đúng prototype nhưng chạy theo thời gian game,
  không chạy theo giây thật:
  `Chưa cuốc -> Đã cuốc -> Đã gieo -> Cần tưới -> Đang lớn -> Đã chín -> Thu hoạch xong -> Chưa cuốc`
- Sau thu hoạch, ô quay về Chưa cuốc. Người chơi phải cuốc lại,
  để mỗi vụ đều có công sức, không có ô tự động tái sử dụng.

### 4.2. Nước và độ ẩm

- Gieo xong, ô ở trạng thái Cần tưới. Tưới một lần là bắt đầu lớn.
- Độ ẩm giảm dần theo ngày. Nếu ô khô quá lâu trong lúc đang lớn,
  cây chậm lại, không chết ngay trong MVP.
- Mưa theo mùa tự tưới cho các ô đang Cần tưới hoặc đang lớn.
  Đây là điểm nối với Time & Seasonal System, và là lý do người
  chơi phải xem dự báo mùa trước khi gieo.

### 4.3. Thời gian lớn và mùa vụ

- Thời gian lớn tính bằng ngày trong game, không tính bằng giây.
  Prototype dùng 8 giây chỉ để test nhanh, không phải số liệu sản xuất.
- Mỗi giống có mùa hợp nhất. Trồng đúng mùa: lớn đúng thời gian,
  năng suất đủ. Trồng trái mùa: lớn chậm hơn và năng suất giảm,
  không cấm hẳn, để người chơi vẫn có lựa chọn khi cần gấp.
- Nếu đổi mùa mà cây chưa chín, cây không chết ngay trong MVP mà
  chậm lại thêm, trừ khi mùa mới là mùa khắc nghiệt với giống đó
  (ví dụ giống ưa ấm gặp mùa lạnh sâu) — trường hợp này sẽ ghi rõ
  trong bảng giống, không áp dụng chung chung.

## 5. Crops — giống cây trong MVP (số liệu đề xuất để playtest, chưa chốt cuối)

Bảng dưới là đề xuất để chơi thử và cân bằng lại sau, không phải
quyết định cuối của người chơi. Giá bán là giá nông sản thô, trước
chế biến, để hệ thống Processing & Economy cân tiếp.

| Giống | Mùa hợp | Ngày lớn | Hạt giống (xu) | Năng suất / ô | Giá thô / đơn vị | Ghi chú |
|-------|---------|----------|----------------|---------------|------------------|---------|
| Lúa | Xuân, Hè | 3 ngày | 2 | 2 | 3 | Giống khởi đầu, chế biến thành Gạo. |
| Rau xanh | Xuân, Thu | 2 ngày | 3 | 3 | 2 | Nhanh, rẻ, để có tiền sớm và học luân canh. |
| Ngô | Hè, Thu | 4 ngày | 4 | 2 | 5 | Chậm hơn, giá cao hơn, để chế biến sau này. |

- Chỉ 3 giống trong MVP. Thêm giống mới là nội dung mở rộng sau,
  không thêm trong lúc cân bằng MVP.
- Mỗi ô chỉ trồng một giống một vụ. Không trồng xen trong MVP.

## 6. Breeding — lai tạo đơn giản trong MVP

MVP không làm di truyền phức tạp. Breeding ở đây nghĩa là giữ hạt
giống tốt:

- Chất lượng có 3 bậc: Thường, Tốt, Xuất sắc.
- Thu hoạch ở chất lượng cao có tỉ lệ cho ra hạt giống cùng bậc.
  Ví dụ: thu hoạch Xuất sắc có cơ hội giữ lại hạt Xuất sắc cho vụ sau.
- Hạt bậc cao cho năng suất hoặc giá cao hơn một bậc, không tạo ra
  giống mới hoàn toàn trong MVP.
- Người chơi phải tự quyết: bán hết nông sản Xuất sắc lấy tiền ngay,
  hay giữ lại một phần làm giống cho vụ sau. Đó là quyết định
  kinh tế nhỏ nhưng đúng tinh thần kỷ luật của game.

Chất lượng của một vụ phụ thuộc vào 3 thứ, theo thứ tự:
1. Độ màu mỡ của đất lúc gieo.
2. Có tưới đúng lúc hay để khô lâu không.
3. Có trồng đúng mùa không.

## 7. Soil fertility — đất bạc màu và phục hồi

- Mỗi ô có độ màu mỡ 0–100, bắt đầu ở 70.
- Mỗi vụ thu hoạch trừ một lượng nhỏ. Trồng cùng một giống liên
  tục trên cùng một ô trừ nhiều hơn, để khuyến khích luân canh.
- Đất dưới 40: năng suất và chất lượng bắt đầu giảm rõ.
- Phục hồi bằng 2 cách trong MVP:
  - Để đất nghỉ một mùa (không trồng gì).
  - Bón phân từ chăn nuôi (nối với Livestock System, phân là
    sản phẩm phụ của vật nuôi, không phải mua bằng xu là chính).
- Không có phân bón mua vô hạn bằng xu trong MVP, để đất không
  trở thành vấn đề chỉ giải quyết bằng tiền.

## 8. Farm expansion — mở rộng ruộng

- Bắt đầu: ruộng nhỏ, đủ để học vòng lặp, tương đương 4x4 trong
  prototype nhưng tính bằng ô trong game, không khóa cứng 4x4.
- Mở rộng bằng khai hoang: tốn công (thời gian trong game) và một
  ít vật liệu, và phải nằm trong khu đất làng đã quy hoạch.
  Đây là điểm nối với Land Planning & Infrastructure.
- Giới hạn mở rộng trong MVP là giới hạn của làng, không phải giới
  hạn của tiền. Muốn mở rộng nhanh mà không tính tới Green Balance
  sẽ làm đất và môi trường xung quanh xấu đi, dân truyền thống
  phản ứng — chi tiết phạt nằm ở Green Balance System, Farming
  chỉ cung cấp số liệu đất và năng suất cho hệ thống đó.

## 9. Interaction & UI — người chơi thấy gì

- Đứng gần ô: hiện nhắc tương tác ngắn, ví dụ `E: Tưới nước`,
  kèm tên giống, trạng thái, số ngày còn lại, độ ẩm và độ màu mỡ
  bằng biểu tượng đơn giản, không cần mở menu riêng.
- Màu và kích thước cây thay đổi theo giai đoạn lớn, giống
  prototype: mầm nhỏ, đang lớn, chín vàng. Trong bản web, cây là
  khối đơn giản trước, art thật làm sau, không chặn thiết kế.
- Chọn giống: phím số hoặc nút trên giao diện web, 1 = Lúa,
  2 = Rau xanh, 3 = Ngô. Khi đứng gần ô Đã cuốc và bấm E, game
  gieo giống đang chọn, và trừ hạt giống tương ứng.
- Thông báo quan trọng chỉ có 3 loại trong MVP: hết hạt giống,
  ô khô quá lâu, cây đã chín. Không spam thông báo cho từng ô
  từng ngày.

## 10. Economy integration — nông sản đi đâu

- Thu hoạch vào Inventory: hạt giống, nông sản thô, phân bón
  (nếu có từ chăn nuôi).
- Nông sản thô có 3 đường đi, người chơi tự chọn:
  1. Bán thô lấy xu ngay, giá thấp.
  2. Đưa vào Processing để thành sản phẩm giá cao hơn.
  3. Giữ lại làm giống (chỉ với nông sản chất lượng cao) hoặc
     để dành cho dân làng trong các nhiệm vụ mùa sau.
- Farming không tự định giá cuối. Giá thô trong bảng mục 5 là
  đầu vào cho Economy & Processing, hai hệ thống đó mới chốt
  giá chế biến và giá bán cuối sau khi chơi thử.

## 11. Progression — người chơi giỏi lên như thế nào

- Không có cấp độ làm nông bằng XP trong MVP. Tiến bộ thể hiện
  bằng thứ nhìn thấy được: nhiều ô hơn, hạt giống tốt hơn, đất
  khỏe hơn, và vụ mùa ổn định hơn qua các mùa.
- Kỹ năng của người chơi, không phải chỉ số nhân vật, là thứ
  tăng lên: biết luân canh, biết giữ giống, biết gieo đúng mùa.
- Town stage mới tính tới kỹ năng, máy móc và giống đặc biệt.
  MVP không hứa những thứ đó.

## 12. Technical notes — làm bằng Babylon.js web như thế nào

- Dữ liệu giống cây phải nằm trong một bảng dữ liệu duy nhất
  (object / JSON), logic ô ruộng không hard-code tên giống, ngày
  lớn hay giá. Thêm giống mới là thêm một dòng dữ liệu, không
  sửa logic.
- Mỗi ô là một entity với state machine riêng, chạy theo thời
  gian game từ Time System, không chạy theo `setInterval` riêng
  lẻ và không chạy theo giây thật như prototype.
- Code sản xuất phải tách khỏi code prototype trong `web/main.js`.
  Prototype là bản dùng một lần để test vòng lặp, không refactor
  thành Farming System sản xuất.
- Hiệu năng web: số ô trong MVP giữ ở mức làng nhỏ, không vẽ
  từng lá cây. Cây là khối đơn giản đổi màu và tỉ lệ theo giai
  đoạn, art chi tiết làm sau khi vòng lặp đã ổn.

## 13. Explicitly out of MVP Farming

- Không máy móc, không tưới tự động, không nhà kính.
- Không trồng xen, không cây ăn quả lâu năm, không cây công nghiệp.
- Không di truyền phức tạp, không đột biến, không giống lai mới.
- Không chăn nuôi trong file này — Livestock là hệ thống riêng,
  Farming chỉ nhận phân bón từ nó.
- Không quy hoạch đất chi tiết — Land Planning là hệ thống riêng,
  Farming chỉ nhận giới hạn đất từ nó.

## 14. Open questions — cần chốt sau khi chơi thử

- Số ngày lớn và giá trong bảng mục 5 có làm người chơi chờ quá
  lâu hoặc giàu quá nhanh không? Cần một vòng chơi thử với thời
  gian game thật để cân lại.
- Tỉ lệ giữ hạt giống bậc cao bao nhiêu là vừa để người chơi cảm
  thấy đáng giữ mà không bị lạm phát hạt tốt?
- Mưa theo mùa tưới tự động có làm việc tưới tay trở nên thừa
  không, hay vẫn cần tưới tay trong mùa khô?
- Khi nào thì đất dưới 40 nên hiện cảnh báo rõ ràng cho người
  chơi mới, trước khi năng suất giảm?

## 15. Design tests — kiểm tra thiết kế này có đúng không

- Người chơi mới, không đọc hướng dẫn dài, có tự làm được một vụ
  từ cuốc đến thu hoạch trong 10 phút đầu không?
- Người chơi có tự luân canh sau 2–3 vụ mà không cần game ép
  bằng thông báo liên tục không?
- Người chơi có giữ lại hạt tốt thay vì bán hết, ít nhất một lần
  trong 3 mùa đầu không?
- Nếu người chơi trồng trái mùa, họ có hiểu vì sao năng suất giảm
  mà không cảm thấy game phạt vô lý không?
