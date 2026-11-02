# Hạt Mầm Vàng (Seeds of Prosperity) — Game Studio Project

Game 3D nhập vai nông trại kết hợp quản lý đô thị, góc nhìn thứ ba.
Người chơi bắt đầu với cây cuốc trên tay và kết thúc với tư cách kiến trúc
sư trưởng của một đô thị nông nghiệp sinh thái.

Concept đầy đủ ở `design/gdd/game-concept.md`.

## Technology Stack

- **Engine**: Unity 6000.6.7f1 (Unity 6.6, current release, not LTS — chosen by the user on 2026-11-02 because this editor version is already installed)
- **Language**: C#
- **Build System**: Unity Build Pipeline
- **Asset Pipeline**: Unity Asset Import Pipeline + Addressables

> **Note**: Engine-specialist agents exist for Godot, Unity, and Unreal with
> dedicated sub-specialists. Use the set matching your engine. For this
> project, use the Unity specialist set.

## Project Structure

- `design/gdd/game-concept.md` — game concept đã chốt, bao gồm pillars,
  core loop, MVP giai đoạn Thôn và các rủi ro
- `project.yaml` — cấu hình chính của project, bao gồm engine, specialists,
  naming và commands
- `docs/engine-reference/unity/VERSION.md` — phiên bản engine đã chốt và
  trạng thái cài đặt tại thời điểm chốt
- Unity project — do Unity Hub tạo ra tại thư mục gốc của repo, chưa có
  trong repo này cho đến khi người dùng tạo project trong Unity Hub

<!-- ENGINE-REFERENCE-IMPORT: the line below is engine-specific. -->
@docs/engine-reference/unity/VERSION.md

## Technical Preferences

`project.yaml` tại repo root là cấu hình chính — engine, specialists,
naming, platform, performance, modes. Các skill đọc `project.yaml` trước.

Các quy ước đặt tên cho Unity (C#), theo setup-engine:
- Classes: PascalCase
- Public fields/properties: PascalCase
- Private fields: _camelCase
- Methods: PascalCase
- Files: PascalCase, trùng tên class
- Constants: PascalCase hoặc UPPER_SNAKE_CASE

Lưu ý: giá trị `naming.constants` trong `project.yaml` được ghi chú là
chưa xác minh được từ engine reference, cần xác nhận trước khi dựa vào
nó như một quy tắc cứng.

## Coordination Rules

**User-driven collaboration, not autonomous execution.**
Every task follows: **Question -> Options -> Decision -> Draft -> Approval**

- Hỏi và cho xem bản nháp trước khi ghi file, đặc biệt với thay đổi
  nhiều file
- Không commit hay push khi chưa có chỉ đạo của người dùng
- Một câu hỏi bị bỏ qua không phải là câu trả lời: hỏi lại bằng văn bản
  và chờ

## Coding Standards

- Giữ vòng lặp nông trại và vòng lặp quản trị nối với nhau qua chuỗi
  cung ứng, không để hai hệ thống tách rời
- Giữ cân bằng xanh là giới hạn thật, không phải trang trí: tăng trưởng
  phải trả giá bằng ô nhiễm và đồng thuận cộng đồng
- Không thêm thư viện hay dependency mang tính suy đoán khi chưa bắt
  đầu tích hợp thật sự

## Context Management

- `design/gdd/game-concept.md` là tài liệu concept chính, đọc trước khi
  bắt đầu hệ thống mới
- `project.yaml` là cấu hình chính, đọc trước khi chạy lệnh build, test
  hay smoke

> **First session?** Nếu project chưa có engine được cấu hình và chưa có
> game concept, chạy workflow `start` để bắt đầu onboarding có hướng dẫn.
> Project này đã có concept và đã chốt Unity, bước tiếp theo là tạo
> project Unity trong Unity Hub, rồi mới đến prototype vòng lặp chính.
