# Systems Index: Hạt Mầm Vàng / Seeds of Prosperity (Web — Babylon.js)

> **Status**: Draft
> **Created**: 2026-11-02
> **Last Updated**: 2026-11-02
> **Source Concept**: design/gdd/game-concept.md
> **Engine note**: This index replaces the Unity path. The Unity scaffold
> and C# prototype in this repo are history only. The web game is built
> with Babylon.js, JavaScript, in `web/`, with no build step for the
> prototype. Production web code should be modularised out of the
> single-file prototype when it grows past prototype scope.

---

## Overview

Hạt Mầm Vàng is a 3D Farming RPG + Town Management game for the web.
The player starts as a hands-on farmer and grows a village into a
town and then an ecological city. The MVP is the Village stage only:
hand farming, a few reactive resident households, basic land planning
and village infrastructure, simple processing, a season-end village
meeting, a simple green-balance system, and a seasonal time cycle.
The core loop is 30 seconds of plow / sow / water / harvest, 5 minutes
of processing / selling / funding residents, a session of seasonal
tasks and one planning project, and a long-term village -> town ->
eco-city arc. Systems below are ordered so foundations are designed
before the features that depend on them.

---

## Systems Enumeration

| # | System Name | Category | Priority | Status | Design Doc | Depends On |
|---|-------------|----------|----------|--------|------------|------------|
| 1 | Web App & Scene Boot | Core | MVP | Not Started | — | — |
| 2 | Input System (inferred) | Core | MVP | Not Started | — | Web App & Scene Boot |
| 3 | Player Controller & Camera | Core | MVP | Not Started | — | Input System |
| 4 | Farming System | Gameplay | MVP | Not Started | — | Player Controller & Camera, Time System |
| 5 | Inventory & Items (inferred) | Economy | MVP | Not Started | — | Farming System |
| 6 | Processing & Supply Chain | Economy | MVP | Not Started | — | Farming System, Inventory & Items |
| 7 | Economy & Currency | Economy | MVP | Not Started | — | Processing & Supply Chain |
| 8 | Livestock System | Gameplay | MVP | Not Started | — | Farming System, Economy & Currency |
| 9 | Time & Seasonal System | Gameplay | MVP | Not Started | — | Web App & Scene Boot |
| 10 | Residents & Relationships | Gameplay | MVP | Not Started | — | Farming System, Land Planning |
| 11 | Land Planning & Infrastructure | Gameplay | MVP | Not Started | — | Residents & Relationships, Economy & Currency |
| 12 | Họp Làng (Village Meeting) | Gameplay | MVP | Not Started | — | Residents & Relationships, Time & Seasonal System |
| 13 | Green Balance & Pollution | Gameplay | MVP | Not Started | — | Farming System, Land Planning |
| 14 | UI / HUD | UI | MVP | Not Started | — | Inventory & Items, Economy & Currency |
| 15 | Save & Persistence (inferred) | Persistence | Vertical Slice | Not Started | — | Inventory & Items, Economy & Currency |
| 16 | Audio (inferred) | Audio | Vertical Slice | Not Started | — | UI / HUD |
| 17 | Cooperatives & Workshops | Economy | Alpha | Not Started | — | Processing & Supply Chain, Residents & Relationships |
| 18 | Schools & Town Services | Gameplay | Alpha | Not Started | — | Land Planning & Infrastructure |
| 19 | Rail & Inter-regional Trade | Economy | Alpha | Not Started | — | Processing & Supply Chain |
| 20 | City Stage: Research, Exchange, Tourism | Meta | Full Vision | Not Started | — | Cooperatives & Workshops, Schools & Town Services |

---

## Categories

| Category | Description | Typical Systems |
|----------|-------------|-----------------|
| **Core** | Foundation systems everything depends on | Web boot, input, player controller, camera |
| **Gameplay** | The systems that make the game fun | Farming, livestock, residents, planning, meetings, green balance, time |
| **Economy** | Resource creation and consumption | Inventory, processing, currency, cooperatives, trade |
| **Persistence** | Save state and continuity | Save/load via browser storage |
| **UI** | Player-facing information displays | HUD, inventory, meeting UI |
| **Audio** | Sound and music systems | Music manager, SFX |
| **Meta** | Systems outside the core loop | City-stage research, exchange, tourism |

---

## Priority Tiers

| Tier | Definition | Target Milestone | Design Urgency |
|------|------------|------------------|----------------|
| **MVP** | Required for the Village-stage core loop to function | First playable web game | Design FIRST |
| **Vertical Slice** | Required for one complete, polished village area | Vertical slice / demo | Design SECOND |
| **Alpha** | All Town-stage features present in rough form | Alpha milestone | Design THIRD |
| **Full Vision** | City stage, polish, edge cases, content-complete | Beta / Release | Design as needed |

---

## Dependency Map

### Foundation Layer (no dependencies)

1. Web App & Scene Boot — Babylon engine, canvas, resize, scene setup; everything else runs inside it.

### Core Layer (depends on foundation)

1. Input System — depends on: Web App & Scene Boot.
2. Player Controller & Camera — depends on: Input System.
3. Time & Seasonal System — depends on: Web App & Scene Boot.

### Feature Layer (depends on core)

1. Farming System — depends on: Player Controller & Camera, Time & Seasonal System.
2. Inventory & Items — depends on: Farming System.
3. Processing & Supply Chain — depends on: Farming System, Inventory & Items.
4. Economy & Currency — depends on: Processing & Supply Chain.
5. Livestock System — depends on: Farming System, Economy & Currency.
6. Residents & Relationships — depends on: Farming System, Land Planning & Infrastructure (circular in play, designed after Farming).
7. Land Planning & Infrastructure — depends on: Economy & Currency.
8. Họp Làng (Village Meeting) — depends on: Residents & Relationships, Time & Seasonal System.
9. Green Balance & Pollution — depends on: Farming System, Land Planning & Infrastructure.

### Presentation Layer (depends on features)

1. UI / HUD — depends on: Inventory & Items, Economy & Currency.
2. Save & Persistence — depends on: Inventory & Items, Economy & Currency.
3. Audio — depends on: UI / HUD.

### Later Stages (not MVP)

1. Cooperatives & Workshops, Schools & Town Services, Rail & Inter-regional Trade — Town stage, after MVP systems.
2. City Stage: Research, Exchange, Tourism — Full Vision, after Town stage.

---

## Design Order (next steps)

1. Farming System — first gameplay system to design in full, because the
   prototype already proved the loop in miniature and every economy,
   resident and planning system consumes its outputs.
2. Processing & Supply Chain, then Economy & Currency.
3. Time & Seasonal System, then Residents & Relationships.
4. Land Planning & Infrastructure, Họp Làng, Green Balance.
5. UI / HUD, then Save & Persistence.

Note: the web prototype in `web/` is throwaway and does not count as
an implemented system. When a system is designed and built for
production, its code lives outside `web/main.js` prototype code and
outside `Assets/Prototype/`.
