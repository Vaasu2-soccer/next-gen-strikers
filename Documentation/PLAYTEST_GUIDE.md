````markdown
# NEXT GEN STRIKERS: THE FUTURE OF FOOTBALL
## Complete Playtest Build Guide

---

# 🎮 QUICK START GUIDE

## Installation
1. Open the project in Unity 2022.3+
2. Import Photon 2 for networking (optional for local testing)
3. Open `Assets/Scenes/GameplayScene.unity`
4. Press Play

## First Time Setup

### Scene Requirements
- Main Camera positioned at (0, 5, -10)
- Directional Light for stadium lighting
- Plane for soccer field (scale: 10 x 1 x 7)
- Sphere for ball (scale: 0.25, position: 0, 1, 0)

---

# 🕹️ COMPLETE CONTROLS

| Action | Key | Notes |
|--------|-----|-------|
| **Pass** | M | Triggers pass to nearest teammate |
| **Shoot** | Left-Click | Hold to charge power (0-100%) |
| **Shoot Power** | Hold Left-Click | Power bar displays in UI |
| **Dribble** | Q | Can result in ankle breaker if timed |
| **Tackle** | E | Defensive action |
| **Sprint** | Left Shift | Increases movement speed |
| **Shift Lock** | Right Shift | Locks camera direction |
| **Awakening** | X | Activates character awakening (ultimate) |
| **Flow Activation** | F | Activates flow state (requires 35% bar) |
| **Move 1** | Z | Character-specific ability |
| **Move 2** | V | Character-specific ability |
| **Move 3** | B | Character-specific ability |
| **Move 4** | C | Character-specific ability |

---

# 👑 CHARACTER SYSTEM

## Character 1: VAASU JOHNSON
**Rarity:** ABSOLUTE SOVEREIGN
**Type:** Dribbler / Shooter / Playmaker
**Role:** CAM / CF / Winger

### Stats
- Speed: 100/100
- Dribbling: 100/100
- Shooting: 98/100
- Ball Control: 100/100
- Vision: 99/100
- Defense: 75/100

### Base Abilities (Normal Mode)
| Move | Key | Cooldown | Type |
|------|-----|----------|------|
| Royal Serpent | Z | 18s | Dribble → Shot |
| Monarch's Deception | V | 20s | Dribble → Lock-On Pass |
| Imperial Breaker | B | 22s | Speed Burst |
| King's Verdict | C | 25s | Decision Maker |

### Awakening: ABSOLUTE SOVEREIGN
- **Activation:** Press X
- **Duration:** 30 seconds
- **Dialogue:** "You mistake talent for authority..."
- **Cutscene:** Chessboard forms, reality cracks, throne emerges

### Awakened Abilities
| Move | Key | Cooldown | Type |
|------|-----|----------|------|
| Emperor's Labyrinth | Z | 30s | Dribbling Domination |
| Sovereign Impact | V | 35s | Long-range Curved Shot |
| Checkmate Protocol | B | 40s | Lock-on Pass to Best Teammate |
| King's End | C | 55s | Ultimate - Impossible Strike |

### Flow: KINGDOM OF THE ABSOLUTE SOVEREIGN
- **Type:** All-Round Dominator
- **Base Buff:** +35% to 4 random attributes
- **Stacking:** +2% per successful action (max +10%)
- **Maximum Total:** +45% per attribute
- **Attributes:** Speed, Dribbling, Vision, Passing, Shooting, etc.

---

## Character 2: AALOK
**Rarity:** ETERNAL APEX
**Type:** Genius Playmaker / Tempo Controller / Vision Core
**Role:** CM / CAM (Midfielder)

### Stats
- Vision: 100/100
- Passing: 100/100
- Ball Control: 98/100
- Dribbling: 94/100
- IQ: 100/100
- Speed: 86/100
- Shooting: 90/100

### Base Abilities (Normal Mode)
| Move | Key | Cooldown | Type |
|------|-----|----------|------|
| Celestial Thread | Z | 18s | Through Pass |
| Orbit Step | V | 20s | Circular Dribble |
| Quiet Command | B | 25s | Team Buff |

### Awakening: ETERNAL CONSTELLATION - ORIGIN CORE
- **Activation:** Press X
- **Duration:** 30 seconds
- **Dialogue:** "I don't need to force anything..."
- **Cutscene:** Starfield appears, constellation forms, future visible

### Awakened Abilities
| Move | Key | Cooldown | Type |
|------|-----|----------|------|
| Harmonic Playbook | Z | 30s | Auto Attacking Structure |
| Supernova Split | V | 38s | Curved Shot or Mega Pass |
| Eternal Apex | B | 60s | Ultimate - Time Slowdown |

### Flow: CONSTELLATION SYNC
- **Type:** Adaptive Clarity
- **Base Buff:** +25% to +32.5% to 3 random attributes
- **Stacking:** +2% passing effectiveness per pass (max +10%)
- **Vision Boost:** Increases with each successful pass
- **Attributes:** Vision, Passing, Dribbling, Ball Control, Speed, etc.

---

# 🔥 FLOW STATE SYSTEM

## How It Works
1. **Build Flow Bar:** Perform successful actions, maintain possession, complete skill moves
2. **Activation Threshold:** Bar reaches 35%
3. **Activate Flow:** Press F to activate
4. **Select Spin:** Wheel spins to select random attribute buffs
5. **Buff Duration:** 10-30 seconds with stacking potential

## Buff System

### Vaasu's Flow (Kingdom of Absolute Sovereign)
- **4 Random Attributes** selected
- **+35% Base Buff** to each
- **+2% Stack per action** (max +10%)
- **Total Max:** +45% per attribute

### Aalok's Flow (Constellation Sync)
- **3 Random Attributes** selected
- **+25% to +32.5% Base Buff** to each
- **+2% Stack per pass** (max +10%)
- **Vision Radius:** Increases temporarily

## Actions That Build Flow
- ✓ Successful pass
- ✓ Successful tackle/interception
- ✓ Skill move execution
- ✓ Maintaining possession
- ✓ Team play contribution

---

# 💰 RARITY SYSTEM

## 16 Rarities (Worst → Best)

| Rarity | Color | VFX | SFX | Odds |
|--------|-------|-----|-----|------|
| Common | Gray | Dust Particles | Soft Click | 40% |
| Uncommon | Green | Sparkles | Light Chime | 30% |
| Rare | Blue | Streaks | Crystal Ding | 20% |
| Epic | Purple | Aura | Magical Whoosh | 7% |
| Legendary | Gold | Flames | Triumphant Horn | 2% |
| Mythic | Crimson | Red Lightning | Deep Impact | 0.8% |
| Divine | White | Holy Rays | Angelic Choir | 0.15% |
| Godly | Cyan | Floating Runes | Heavenly Bell | 0.05% |
| Transcendent | Pink-Violet | Reality Distortion | Echoing Resonance | - |
| Secret | Black+Rainbow | Void Cracks | Dark Bass Pulse | - |
| Infinity | Deep Indigo | Infinite Symbols | Endless Echo | - |
| Celestial | Galaxy Blue | Constellations | Cosmic Choir | - |
| Omniversal | Rainbow | Universe Expansion | Multi-layered Cosmic | - |
| Best in History | Platinum | Historic Silhouettes | Stadium Roar | - |
| Eternal Apex | Black-Gold | Time-Stop Effect | Deep Celestial Hum | - |
| Absolute Sovereign | Pure White Rainbow | Reality Shatter | Ultimate Ascension | - |

---

# 📊 RANKING SYSTEM

## 12 Ranks (Progression)

| Rank | Stars Required | Wins Per Star |
|------|----------------|---------------|
| Rookie | 5 | 3 |
| Sophomore | 5 | 3 |
| Bronze | 5 | 3 |
| Silver | 5 | 3 |
| Gold | 5 | 3 |
| Platinum | 5 | 4 |
| Diamond | 5 | 5 |
| Champion | 5 | 10 |
| Grand Champion | 5 | 10 |
| Elite Baller | 5 | 10 |
| Street Ball Master | 5 | 10 |
| The God of Football | ∞ | - |

## How to Rank Up
1. Win ranked matches
2. Earn stars (based on wins required per rank)
3. Collect 5 stars to rank up
4. Progress through all 12 ranks
5. Final rank: "The God of Football" (no further progression)

---

# 🎮 GAMEPLAY FEATURES

## Ball Physics
- **Realistic acceleration/deceleration**
- **Friction-based movement**
- **Max speed clamping (30 units/sec)**
- **Kick/Pass/Shoot mechanics**
- **Gravity-affected trajectory**

## Player Movement
- **8-directional movement**
- **Base speed: 8 units/sec**
- **Sprint speed: 12 units/sec**
- **Smooth acceleration (15 units/sec²)**
- **Rotation-based direction facing**

## Combat System
- **Passing accuracy**
- **Shooting power/accuracy**
- **Tackles with timing windows**
- **Dribbling with skill moves**
- **Defensive positioning**

## Passive Systems
- **Vaasu: Sovereign's Vision** - Highlights lanes, grants speed boosts on defender beats
- **Aalok: Pattern Reading** - Maps player movements, suggests paths, reduces cooldowns on passes

---

# 🛠️ TECHNICAL ARCHITECTURE

## Scene Structure
```
GameplayScene
├── Camera (Main)
├── Lighting (Directional Light)
├── Stadium
│   ├── Field (Plane)
│   ├── Goals (2x)
│   └── Crowd Areas
├── Ball (Sphere with Rigidbody)
├── Players
│   ├── Player Controller (Local)
│   ├── AI Players (Teammates)
│   └── Opponents (AI)
├── GameManager (Singleton)
├── InputController
├── UIManager
└── AudioManager
```

## Core Systems

### 1. InputController.cs
Handles all user inputs and maps to game actions

### 2. PlayerController.cs
Manages player movement, animation, and physics

### 3. BallPhysics.cs
Handles ball dynamics, kicks, passes, shoots

### 4. GameManager.cs
Orchestrates all systems, manages game state

### 5. UIManager.cs
Displays debug info, power bar, flow bar, stats

### 6. VaasuJohnsonStyle.cs
Complete Vaasu character system with abilities

### 7. AalokStyle.cs
Complete Aalok character system with abilities

### 8. KingdomAbsoluteSovereignFlow.cs
Vaasu's flow system with 4-attribute buffs

### 9. ConstellationSyncFlow.cs
Aalok's flow system with 3-attribute buffs

### 10. RaritySystem.cs
16-tier rarity system with colors, VFX, SFX

### 11. SpinSystem.cs
Gacha spin mechanics (Standard, Lucky, Ultra, Infinity)

### 12. RankingSystem.cs
12-rank progression system

---

# 📋 PLAYTEST CHECKLIST

## Input System ✓
- [ ] Pass (M) triggers correctly
- [ ] Shoot (Left-Click) charges power
- [ ] Power bar fills 0-100%
- [ ] Release triggers shot with correct force
- [ ] Dribble (Q) activates ability
- [ ] Tackle (E) works as intended
- [ ] Sprint (Left Shift) increases speed
- [ ] Shift Lock (Right Shift) locks camera
- [ ] Awakening (X) activates ability
- [ ] Flow (F) activates when ready
- [ ] Moves 1-4 (Z/V/B/C) trigger correctly

## Character System ✓
- [ ] Vaasu loads with correct stats
- [ ] Aalok loads with correct stats
- [ ] Base abilities trigger with correct cooldowns
- [ ] Awakening cutscene plays
- [ ] Awakened abilities have different cooldowns
- [ ] Dialogue displays correctly
- [ ] VFX particles spawn

## Ball Physics ✓
- [ ] Ball responds to kicks
- [ ] Friction slows ball naturally
- [ ] Max speed enforced
- [ ] Passes work with lock-on
- [ ] Shots bend around defenders
- [ ] Ball stops on goal/out of bounds

## Flow System ✓
- [ ] Flow bar builds on actions
- [ ] Activation threshold (35%) triggers
- [ ] Random attributes selected
- [ ] Buffs apply to player stats
- [ ] Stacking bonus increases on actions
- [ ] Flow duration times out

## UI ✓
- [ ] Debug info displays
- [ ] Power bar shows
- [ ] Flow bar shows
- [ ] Character name displays
- [ ] Stats visible
- [ ] Ability cooldowns visible

## Performance ✓
- [ ] Game runs at 60 FPS
- [ ] No memory leaks
- [ ] Smooth animations
- [ ] Responsive controls
- [ ] No stuttering

---

# 🐛 KNOWN ISSUES & NOTES

## Current Limitations
1. **No multiplayer yet** - Local-only testing
2. **AI not fully implemented** - Placeholder teammates
3. **No stadium visuals** - Basic geometry only
4. **No crowd system** - Audio/VFX placeholders only
5. **Physics simplified** - Not realistic ball spin/curve yet
6. **UI minimal** - Debug-focused only

## TODO for Full Release
- [ ] Implement full multiplayer with Photon 2
- [ ] Add AI opponent system
- [ ] Create stadium environments
- [ ] Implement crowd reaction system
- [ ] Add cinematic replays
- [ ] Polish animations
- [ ] Add sound effects and music
- [ ] Create cosmetic shop
- [ ] Implement ranked matchmaking
- [ ] Add seasonal content

---

# 📚 FILE STRUCTURE

```
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── GameManager.cs
│   │   └── InputController.cs
│   ├── Gameplay/
│   │   ├── BallPhysics.cs
│   │   ├── PlayerController.cs
│   │   └── CinematicReplay.cs
│   ├── Styles/
│   │   ├── VaasuJohnsonStyle.cs
│   │   └── AalokStyle.cs
│   ├── Systems/
│   │   ├── RaritySystem.cs
│   │   ├── SpinSystem.cs
│   │   ├── RankingSystem.cs
│   │   ├── FlowStateSystem.cs
│   │   ├── KingdomAbsoluteSovereignFlow.cs
│   │   └── ConstellationSyncFlow.cs
│   ├── Progression/
│   │   ├── PlayerInventory.cs
│   │   ├── StyleManager.cs
│   │   └── FlowManager.cs
│   ├── UI/
│   │   ├── UIManager.cs
│   │   ├── HomeMenuUI.cs
│   │   └── GameModeSelector.cs
│   └── Network/
│       └── MultiplayerManager.cs
├── Configuration/
│   ├── RaritySystem.cs
│   ├── GameSettings.json
│   └── SpinSystem.cs
├── Scenes/
│   ├── HomeMenu.unity
│   ├── GameplayScene.unity
│   └── CharacterSelect.unity
└── Documentation/
    ├── GameDesign.md
    ├── Styles_and_Flows_Reference.md
    └── PLAYTEST_GUIDE.md
```

---

# 🎯 TESTING FOCUS AREAS

## Priority 1: Core Gameplay
1. Test all input controls work smoothly
2. Verify ball physics feel right
3. Check ability cooldowns work
4. Confirm flow system builds correctly

## Priority 2: Character Balance
1. Compare Vaasu vs Aalok gameplay feel
2. Test both flow systems
3. Check ability balance
4. Verify stats differences matter

## Priority 3: User Experience
1. Test UI clarity
2. Check debug info helpful
3. Verify controls intuitive
4. Test responsiveness

## Priority 4: Performance
1. Monitor FPS stability
2. Check memory usage
3. Test CPU usage
4. Verify no stuttering

---

# 💬 FEEDBACK FORM

When testing, note:
- **Enjoyable Controls?** (1-10)
- **Feel of Ball Physics?** (1-10)
- **Ability Balance?** (1-10)
- **Flow System Fun?** (1-10)
- **Character Feel Different?** (Yes/No)
- **Any Bugs Found?** (List)
- **Performance Issues?** (List)
- **Suggestions?** (List)

---

# 📞 SUPPORT

For questions or issues:
1. Check debug console for error messages
2. Review Git commit history
3. Check Documentation folder
4. Test individual systems in isolation

**Project Repository:** https://github.com/Vaasu2-soccer/next-gen-strikers

---

Generated: 2026-06-04
Version: Playtest Build 1.0
````
