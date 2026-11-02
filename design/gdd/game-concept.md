# Game Concept: Hạt Mầm Vàng (Seeds of Prosperity)

*Created: 2026-11-02*
*Status: Draft - bản nháp đã chốt trong chat ngày 2026-11-02, chưa qua director gates, chưa chốt engine và nền tảng*

---

## Elevator Pitch

> Hạt Mầm Vàng là game 3D nhập vai nông trại kết hợp quản lý đô thị, góc nhìn thứ ba, nơi bạn bắt đầu với cây cuốc trên tay và kết thúc với tư cách kiến trúc sư trưởng của một đô thị nông nghiệp sinh thái.

---

## Core Identity

| Aspect | Detail |
| ---- | ---- |
| **Genre** | Farming RPG + Town Management / Simulation |
| **Platform** | Chưa chốt - sẽ quyết ở bước setup-engine |
| **Target Audience** | Người chơi mid-core thích nông trại, mô phỏng và xây dựng cộng đồng |
| **Player Count** | Single-player (theo concept hiện tại, cần xác nhận lại nếu muốn thêm chế độ khác) |
| **Session Length** | 30-120 phút cho một buổi chơi, với vòng lặp ngắn 30 giây và 5-15 phút bên trong |
| **Monetization** | Chưa chốt |
| **Estimated Scope** | Large - nhiều hệ thống, ba giai đoạn phát triển, cần thiết kế kỹ trước khi code |
| **Comparable Titles** | Gợi ý cần xác nhận: Stardew Valley cho vòng lặp nông trại, Cities: Skylines cho quy hoạch đô thị - Hạt Mầm Vàng khác ở chỗ hai vòng lặp này nối liền nhau trong một người chơi duy nhất |

---

## Core Fantasy

Bạn không chỉ trồng cây để kiếm tiền, và cũng không chỉ xây thành phố từ trên cao. Bạn là người sống trong vùng đất đó, tự tay làm nông để tạo vốn và nguyên liệu, rồi dùng chính những quyết định quy hoạch của mình để định hình cộng đồng, và cuối cùng phải giữ được tình làng nghĩa xóm cùng không gian xanh giữa lòng đô thị hiện đại.

---

## Unique Hook

Giống Stardew Valley ở vòng lặp nông trại tự tay, và cũng giống game quản lý đô thị ở quy hoạch và ngân sách, nhưng Hạt Mầm Vàng nối hai vai trò đó trong một hành trình duy nhất: từ nông dân đến kiến trúc sư trưởng, và cư dân sẽ phản ứng trực tiếp với từng quyết định quy hoạch của bạn, từ việc kết hôn sinh con đến việc tiếp quản cơ ngơi của cha mẹ.

---

## Player Experience Analysis (MDA Framework)

### Target Aesthetics

| Aesthetic | Priority | How We Deliver It |
| ---- | ---- | ---- |
| **Sensation** | 1 | Phong cách Stylized 3D ấm áp lấy cảm hứng từ Ghibli, ánh sáng động, cảnh quan và trang phục biến đổi theo thời kỳ |
| **Fantasy** | 2 | Vai trò nông dân trở thành kiến trúc sư trưởng của đô thị nông nghiệp sinh thái |
| **Narrative** | 3 | Câu chuyện do người chơi tạo ra qua các thế hệ cư dân, gia phả và các quyết định quy hoạch |
| **Challenge** | 4 | Cân bằng tăng trưởng với ô nhiễm, ngân sách, mất mùa và tranh chấp |
| **Fellowship** | 2 | Cư dân có tính cách, ước mơ nghề nghiệp, phản ứng với quy hoạch, và buổi Họp Làng cuối mùa |
| **Discovery** | 5 | Lai tạo giống đặc sản, mở khóa cơ giới hóa, công nghệ cao và các vùng giao thương mới |
| **Expression** | 3 | Quy hoạch đất đai, kiến trúc và hướng phát triển sinh thái hoặc công nghiệp của đô thị |
| **Submission** | 4 | Vòng lặp nông trại thư giãn xen kẽ với các quyết định quản trị lớn |

### Key Dynamics

- Người chơi sẽ thử nghiệm giống cây và chuỗi chế biến để tối ưu vốn và nguyên liệu cho cả vùng.
- Người chơi sẽ cân nhắc mỗi dự án quy hoạch không chỉ bằng tiền mà bằng phản ứng của từng nhóm cư dân.
- Người chơi sẽ đầu tư vào dân làng thay vì tự xây mọi thứ, để sạp nhỏ tự lớn thành doanh nghiệp địa phương.
- Người chơi sẽ phải đánh đổi giữa tốc độ đô thị hóa và chất lượng nông sản cùng sự đồng thuận của cộng đồng.

### Core Mechanics

1. Làm nông tự tay: cày xới, gieo trồng, lai tạo giống đặc sản và chăn nuôi.
2. Quản trị thôn và quy hoạch: phân vùng đất, phê duyệt ngân sách hạ tầng, xử lý sự cố từ mất mùa đến tranh chấp ranh giới.
3. Thương mại chuỗi khép kín: nông trại cá nhân đến xưởng chế biến của dân làng, rồi xuất khẩu qua bến cảng và nhà ga.
4. Mô phỏng cư dân và thế hệ: tính cách, ước mơ nghề nghiệp, gia phả, kết hôn, sinh con và tiếp quản.
5. Cân bằng xanh: ô nhiễm và chất lượng nông sản phản ứng với tốc độ và hướng đô thị hóa.

---

## Player Motivation Profile

### Primary Psychological Needs Served

| Need | How This Game Satisfies It | Strength |
| ---- | ---- | ---- |
| **Autonomy** | Người chơi toàn quyền định hình kết cục: siêu đô thị công nghiệp hay thành phố sinh thái bền vững | Core |
| **Competence** | Làm chủ nông nghiệp, chuỗi cung ứng, quy hoạch và quản trị qua ba giai đoạn | Core |
| **Relatedness** | Gắn bó với cư dân qua Họp Làng, đồng kiến tạo và các thế hệ tiếp nối | Core |

### Player Type Appeal

- **Achievers**: hoàn thành giai đoạn Thôn, Thị trấn, Thành phố và các mục tiêu quy hoạch.
- **Explorers**: khám phá giống cây, công nghệ, vùng giao thương và hệ thống kinh tế.
- **Socializers**: xây dựng quan hệ với cư dân và giữ đồng thuận cộng đồng.
- **Creators**: thiết kế đô thị, quy hoạch đất đai và hướng phát triển riêng.
- **Competitors**: không phải trọng tâm, không có PvP trong concept hiện tại.

### Flow State Design

- **Onboarding curve**: 10 phút đầu tập trung vào làm nông tự tay và dựng lại mái đình, trước khi mở quản trị lớn.
- **Difficulty scaling**: từ tự cung tự cấp, đến cơ giới hóa và hợp tác xã, rồi nông nghiệp công nghệ cao và sàn giao dịch.
- **Feedback clarity**: cảnh quan, trang phục và chất lượng nông sản biến đổi trực quan theo từng thời kỳ và quyết định.
- **Recovery from failure**: mất mùa và tranh chấp là sự cố cần xử lý trong Họp Làng và quy hoạch lại, không phải kết thúc game ngay.

---

## Core Loop

### Moment-to-Moment (30 seconds)

Cày, gieo, chăm sóc và thu hoạch bằng tay, với phản hồi trực quan ngay trên ruộng và cây trồng.

### Short-Term (5-15 minutes)

Chế biến nông sản, bán hàng, đầu tư vốn và nguyên liệu để dân làng nâng cấp sạp hàng, và chuẩn bị cho một quyết định quy hoạch nhỏ.

### Session-Level (30-120 minutes)

Hoàn thành công việc của mùa, xử lý một sự cố, quy hoạch một công trình, và kết thúc bằng một điểm dừng tự nhiên cùng lý do quay lại vào mùa sau, đặc biệt là Họp Làng cuối mùa.

### Long-Term Progression

- **Thôn quê**: khai hoang, tự cung tự cấp, dựng lại mái đình, thu hút những hộ dân đầu tiên về định cư trên những con đường đất.
- **Thị trấn**: cơ giới hóa, hợp tác xã, xưởng chế biến, trường học và kết nối giao thương liên vùng bằng tàu hỏa.
- **Thành phố**: đô thị sinh thái với nông nghiệp công nghệ cao, viện nghiên cứu sinh học, sàn giao dịch nông sản và du lịch.

### Retention Hooks

- **Curiosity**: giống đặc sản chưa lai tạo, công nghệ chưa mở khóa và vùng giao thương chưa kết nối.
- **Investment**: nông trại, doanh nghiệp địa phương và các thế hệ cư dân mà người chơi đã gắn bó.
- **Social**: đồng thuận cộng đồng và các nguyện vọng được đưa ra trong Họp Làng.
- **Mastery**: tối ưu chuỗi cung ứng và giữ cân bằng xanh trong khi vẫn tăng trưởng.

---

## Game Pillars

### Pillar 1: Quy mô phải có ý nghĩa

Mỗi giai đoạn mở ra cách chơi mới, không chỉ là con số lớn hơn.

*Design test*: Nếu đang phân vân giữa việc tăng chỉ số sản lượng và việc mở một hệ thống mới như hợp tác xã, pillar này chọn hệ thống mới.

### Pillar 2: Làng là cộng đồng, không phải tài nguyên

Cư dân có tính cách, ước mơ và phản ứng với quy hoạch, và đồng thuận của họ là một tài nguyên thật.

*Design test*: Nếu một dự án cho nhiều tiền nhưng làm mất lòng nhóm cư dân truyền thống, pillar này buộc phải tính cả chi phí cộng đồng, không chỉ lợi nhuận.

### Pillar 3: Xanh là giới hạn thật

Đô thị hóa quá nhanh gây ô nhiễm, làm giảm chất lượng nông sản và tạo mâu thuẫn.

*Design test*: Nếu đang phân vân giữa một khu công nghiệp cho lợi nhuận nhanh và một giải pháp sinh thái chậm hơn, pillar này chọn phương án giữ được chất lượng nông sản và không gian xanh.

### Pillar 4: Di sản tiếp nối

Thời gian trôi qua, cư dân kết hôn, sinh con và thế hệ trẻ tiếp quản cơ ngơi với kỹ năng hiện đại hơn.

*Design test*: Nếu một tính năng chỉ phục vụ người chơi hiện tại mà phá vỡ tính liên tục qua các thế hệ, pillar này yêu cầu thiết kế lại để thế hệ sau vẫn kế thừa được.

### Anti-Pillars

- **NOT chỉ cày tiền**: kiếm tiền không phải thử thách cuối game, giữ cộng đồng và không gian xanh mới là bài toán giữ chân người chơi.
- **NOT xây mọi thứ một mình**: người chơi đầu tư để dân tự nâng cấp, không tự tay xây mọi cửa hàng.
- **NOT đô thị hóa không hậu quả**: tăng trưởng luôn có chi phí về môi trường và đồng thuận.

---

## Inspiration and References

| Reference | What We Take From It | What We Do Differently | Why It Matters |
| ---- | ---- | ---- | ---- |
| Stardew Valley (gợi ý cần xác nhận) | Vòng lặp nông trại tự tay và quan hệ cư dân | Nối nông trại với quản lý đô thị toàn vùng trong một hành trình | Xác nhận vòng lặp nông trại có thể giữ chân người chơi lâu dài |
| Cities: Skylines (gợi ý cần xác nhận) | Quy hoạch, hạ tầng và ngân sách đô thị | Người chơi sống trong đô thị đó, không chỉ nhìn từ trên cao | Xác nhận quy hoạch có chiều sâu quản trị thật |
| Ghibli và Solarpunk (cảm hứng phi game) | Cảm giác ấm áp, thiên nhiên và đô thị phủ cây xanh | Cảnh quan biến đổi trực quan từ đường đất đỏ sang đại lộ lát đá và tòa nhà phủ cây | Định hướng art và cảm xúc chủ đạo của game |

---

## Target Player Profile

| Attribute | Detail |
| ---- | ---- |
| **Age range** | Chưa chốt |
| **Gaming experience** | Mid-core, quen với game mô phỏng và xây dựng |
| **Time availability** | Buổi chơi 30-120 phút, với vòng lặp ngắn phù hợp chơi đều theo mùa |
| **Platform preference** | Chưa chốt |
| **Current games they play** | Chưa chốt, gợi ý tham khảo ở bảng trên |
| **What they're looking for** | Một game nông trại không dừng ở nông trại, mà cho họ xây cả một cộng đồng sống được qua nhiều thế hệ |
| **What would turn them away** | Đô thị hóa không hậu quả, cư dân chỉ là số liệu, hoặc giai đoạn cuối chỉ còn cày tiền |

---

## Technical Considerations

| Consideration | Assessment |
| ---- | ---- |
| **Recommended Engine** | Chưa chốt - Godot 4, Unity và Unreal Engine 5 đều có trong studio source, sẽ quyết ở setup-engine |
| **Key Technical Challenges** | Mô phỏng nhiều cư dân có gia phả và phản ứng với quy hoạch, chuỗi cung ứng khép kín, chuyển đổi cảnh quan theo thời kỳ, và hiệu năng khi đô thị lớn dần |
| **Art Style** | Stylized 3D ấm áp, Ghibli kết hợp ánh sáng động hiện đại, chuyển dần sang Solarpunk |
| **Art Pipeline Complexity** | High - cần asset 3D theo thời kỳ, trang phục và cảnh quan biến đổi |
| **Audio Needs** | Moderate - nhạc và âm thanh theo mùa, thời kỳ và sự kiện Họp Làng, cần xác nhận chi tiết sau |
| **Networking** | None trong concept hiện tại |
| **Content Volume** | Chưa chốt số lượng cụ thể - ba giai đoạn, nhiều hệ thống, cần cắt MVP trước |
| **Procedural Systems** | Chưa chốt - lai tạo giống và biến đổi cảnh quan có thể cần hệ thống sinh nội dung, cần prototype để xác nhận |

---

## Risks and Open Questions

### Design Risks

- Vòng lặp nông trại và vòng lặp quản trị có thể tách rời nhau nếu chuỗi cung ứng không nối hai vai trò thật sự.
- Giai đoạn cuối có thể mất động lực nếu chỉ còn cày tiền mà không còn bài toán cộng đồng và xanh.
- Quá nhiều hệ thống cùng lúc có thể làm người chơi mới choáng ngợp ở giai đoạn Thôn.

### Technical Risks

- Mô phỏng cư dân và thế hệ có thể nặng và khó cân bằng khi số dân tăng.
- Chuyển đổi cảnh quan theo thời kỳ có thể tốn asset và hiệu năng.
- Chuỗi cung ứng khép kín cần được prototype sớm để biết có vui và có kiểm soát được không.

### Market Risks

- Thể loại nông trại và quản lý đô thị đều có nhiều game đã thành công, cần hook về cộng đồng và thế hệ thật rõ khi giới thiệu.
- Scope lớn có thể làm game khó hoàn thành nếu không giữ MVP chặt.

### Scope Risks

- Ba giai đoạn đầy đủ, cảng, nhà ga, viện nghiên cứu, sàn giao dịch và du lịch vượt xa một MVP.
- Nếu không cắt scope ở giai đoạn Thôn trước, thiết kế sẽ phình ra trước khi có code chạy được.

### Open Questions

- Engine nào, nền tảng nào, và timeline thực tế là bao nhiêu - sẽ trả lời ở setup-engine và sprint-plan.
- MVP ở giai đoạn Thôn cần bao nhiêu hộ dân và bao nhiêu loại cây để vòng lặp vui - sẽ trả lời bằng prototype.
- Hệ cân bằng xanh đo bằng chỉ số nào, và ngưỡng ô nhiễm ảnh hưởng nông sản ra sao - sẽ trả lời ở design-system cho hệ cân bằng.

---

## MVP Definition

**Core hypothesis**: Người chơi thấy vui khi tự tay làm nông, đầu tư cho dân làng, và thấy quyết định quy hoạch của mình thay đổi cộng đồng trong một mùa.

**Required for MVP** - chỉ trong giai đoạn Thôn:

1. Làm nông tự tay, lai giống và chăn nuôi cơ bản.
2. Vài hộ dân có tính cách và phản ứng với quy hoạch.
3. Quy hoạch đất và hạ tầng thôn cơ bản.
4. Chế biến đơn giản từ nông sản.
5. Họp Làng cuối mùa.
6. Hệ cân bằng xanh và ô nhiễm ở mức đơn giản.
7. Chu kỳ mùa và thời gian trôi.

**Explicitly NOT in MVP**:

- Cảng, nhà ga liên vùng và giao thương liên vùng đầy đủ.
- Hợp tác xã lớn, trường học đầy đủ và cơ giới hóa toàn diện ở giai đoạn Thị trấn.
- Viện nghiên cứu sinh học, sàn giao dịch nông sản và du lịch ở giai đoạn Thành phố.
- Hệ thế hệ tiếp nối đầy đủ, bao gồm kết hôn, sinh con và tiếp quản với kỹ năng mới - sẽ mở rộng sau MVP nếu vòng lặp chính đã vui.

### Scope Tiers

| Tier | Content | Features | Timeline |
| ---- | ---- | ---- | ---- |
| **MVP** | Một thôn, vòng lặp nông trại và quản trị cơ bản | 7 mục ở trên | Chưa chốt |
| **Vertical Slice** | Một thôn hoàn chỉnh với một mùa đầy đủ và Họp Làng | Core + progression trong một mùa | Chưa chốt |
| **Alpha** | Các giai đoạn Thôn và Thị trấn ở dạng thô | Tất cả hệ thống chính, chưa polish | Chưa chốt |
| **Full Vision** | Thôn, Thị trấn và Thành phố sinh thái đầy đủ | Tất cả tính năng, đã polish | Chưa chốt |

---

## Next Steps

- [ ] Chốt engine và nền tảng (`setup-engine`)
- [ ] Prototype vòng lặp nông trại và chuỗi chế biến đơn giản trước khi viết GDD chi tiết
- [ ] Tách concept thành các hệ thống (`map-systems`)
- [ ] Thiết kế từng hệ thống (`design-system`)
- [ ] Kiểm tra toàn bộ thiết kế (`review-all-gdds` và `gate-check`)
- [ ] Lên kế hoạch vertical slice và sprint đầu tiên
