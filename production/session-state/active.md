# Prototype session checkpoint — Hạt Mầm Vàng

- Concept: Hạt Mầm Vàng / Seeds of Prosperity — 3D Farming RPG + Town Management.
- Hypothesis: If the player does plow -> sow -> water -> harvest, then
  processes and sells, they will feel a closed progress loop. We will
  know this is true if the player completes at least 3 full cycles
  (sow to sell) in 10 minutes of playtest without extra guidance.
- Riskiest assumption: the 3D third-person farming loop is not tedious,
  and the processing chain adds motivation beyond harvesting alone.
- Path chosen: Engine — Unity 6000.6.7f1, existing Mus project.
- Scope (minimum): WASD player, 4x4 plots with states
  Untilled -> Tilled -> PlantedDry -> Growing -> Ready, 8-second growth,
  harvest yields 2 crops, processing 3 crops -> 1 processed in 3 seconds,
  market 1 processed -> 10 coins, simple UI counts only.
- Explicitly cut: menus, save, music, Mixamo animations, villagers,
  Họp Làng, seasons, green balance, livestock, land planning, art.
- Prototype isolation: code lives only in `Assets/Prototype/` and is
  throwaway; production code must be written from scratch on PROCEED.
- Current phase: Phase 5 — Implement. Code written locally, not yet
  pushed to Mus. Next: push approval, user Pull + Play, then playtest
  debrief and prototype report with a PROCEED / PIVOT / KILL verdict.
- Fix applied locally 2026-11-02 after first Play: PrototypePlayer
  rewritten to Input System (legacy Input threw InvalidOperationException
  because Active Input Handler is Input System only), player start
  moved to z -8 so plots are in front of the camera, and UI text
  pivots fixed so status/prompt text is not clipped off-screen.
  Fix not yet pushed.
