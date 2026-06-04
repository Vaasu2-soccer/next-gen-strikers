````markdown
# NEXT GEN STRIKERS: Complete Code Reference

## Quick Links to All Systems

### Core Systems
- [GameManager.cs](#gamemanagercs) - Main game orchestrator
- [InputController.cs](#inputcontrollercs) - Input handling
- [UIManager.cs](#uimanagercs) - UI display system
- [PlayerController.cs](#playercontrollercs) - Player movement & physics
- [BallPhysics.cs](#ballphysicscs) - Ball dynamics

### Character Systems
- [VaasuJohnsonStyle.cs](#vaasujournsonstylecs) - Vaasu complete implementation
- [AalokStyle.cs](#aalokstylecs) - Aalok complete implementation

### Flow Systems
- [KingdomAbsoluteSovereignFlow.cs](#kingdomabsolutesovereignflowcs) - Vaasu's flow
- [ConstellationSyncFlow.cs](#constellationsyncflowcs) - Aalok's flow

### Support Systems
- [RaritySystem.cs](#raritysystemcs) - 16-tier rarity system
- [SpinSystem.cs](#spinsystemcs) - Gacha spin mechanics
- [RankingSystem.cs](#rankingsystemcs) - 12-rank progression
- [FlowStateSystem.cs](#flowstatesystemcs) - Base flow mechanics

---

## System Descriptions

### GameManager.cs
```csharp
// Singleton pattern - access anywhere with GameManager.Instance
// Responsibilities:
// - Initialize all game systems
// - Manage game state (Menu, CharacterSelect, InGame, etc.)
// - Handle character selection
// - Orchestrate transitions between states
// - Maintain global game settings

Key Methods:
- SetGameState(GameState) - Change game state
- SelectCharacter(PlayerCharacter) - Switch active character
- GetGameState() - Query current state
- GetSelectedCharacter() - Get active character

Game States:
- Menu - Main menu
- CharacterSelect - Character selection screen
- Loading - Loading screen
- InGame - Active gameplay
- Paused - Game paused
- GameOver - Match ended
```

### InputController.cs
```csharp
// Handles ALL user input and maps to game actions

Keybindings (14 total):
M - Pass
Left-Click - Shoot (with power charging)
Hold Left-Click - Increase shot power
Q - Dribble
E - Tackle
Left Shift - Sprint
Right Shift - Shift Lock
X - Awakening
F - Flow Activation
Z - Move 1
V - Move 2
B - Move 3
C - Move 4

Features:
- Power bar charging (0-100%)
- Shoot power scaling
- Input validation
- Cooldown checking
- Flow state conditional logic
```

### UIManager.cs
```csharp
// Displays all UI elements

Displays:
- Debug info (game state, character, controls)
- Power bar (during shot charging)
- Flow bar (flow state progress)
- Character stats
- Ability cooldowns
- FPS counter
- Real-time info updates

Features:
- Auto-generate UI if not assigned
- Update every frame
- Responsive to input state
- Clean debug display
```

### PlayerController.cs
```csharp
// Core player movement and physics

Movement:
- 8-directional movement (WASD)
- Base speed: 8 units/sec
- Sprint speed: 12 units/sec
- Smooth acceleration (15 units/sec²)
- Rotation-based direction facing

Features:
- Collision detection
- Rigidbody physics integration
- Animation state management
- Sprint state tracking
- Shift lock camera system
- Speed boost application
- Flow boost multipliers

Methods:
- ApplyFlowSpeedBoost(float multiplier) - Temp speed increase
- EnableSprint(bool) - Toggle sprint
- EnableShiftLock(bool) - Toggle camera lock
- ResetFlowBoosts() - Clear flow buffs
- GetCurrentSpeed() - Query current speed
```

### BallPhysics.cs
```csharp
// Ball dynamics and interactions

Physics:
- Velocity-based movement
- Friction application
- Max speed clamping (30 units/sec)
- Gravity simulation
- Bounce mechanics
- Out-of-bounds detection

Ball Actions:
- Kick(Vector3 direction, float force) - Kick ball
- Pass(Vector3 targetPos, float accuracy) - Pass with accuracy
- ShootBall(Vector3 direction, float power) - Shoot at goal
- Reset() - Return ball to center

Features:
- Realistic deceleration
- Collision response
- Force application
- Direction control
- Power scaling
```

### VaasuJohnsonStyle.cs
```csharp
// ABSOLUTE SOVEREIGN - Complete Implementation

Character Profile:
- Rarity: ABSOLUTE SOVEREIGN
- Role: Dribbler/Shooter/Playmaker
- Stats: All 100+ except Defense (75)
- Playstyle: Elite dribbling, fastest movement

Base Abilities (4):
1. Royal Serpent (18s) - Zigzag dribble + recastable shot
2. Monarch's Deception (20s) - Fake cut + lock-on pass
3. Imperial Breaker (22s) - Speed burst + afterimages
4. King's Verdict (25s) - Decision maker (shoot/pass/dribble)

Awakening: ABSOLUTE SOVEREIGN (30s)
- Activates: Press X
- Cutscene: Chessboard forms, reality cracks, throne emerges
- Dialogue: 5 power lines about authority

Awakened Abilities (4):
1. Emperor's Labyrinth (30s) - Dribbling domination
2. Sovereign Impact (35s) - Long-range curved shot
3. Checkmate Protocol (40s) - Lock-on best teammate
4. King's End (55s) - Ultimate impossible strike

Passive: Sovereign's Vision
- Highlights passing/shooting/defensive lanes
- Speed boost on defender defeats
- VFX: Platinum glow, constellation lines

Flow: Kingdom of Absolute Sovereign
- Base Buff: +35% to 4 random attributes
- Stacking: +2% per action (max +10%)
- Total Max: +45% per attribute
```

### AalokStyle.cs
```csharp
// ETERNAL APEX - Complete Implementation

Character Profile:
- Rarity: ETERNAL APEX
- Role: Genius Playmaker/Vision Core
- Stats: Vision/Passing/IQ all 100
- Playstyle: Team coordination, pattern reading

Base Abilities (3):
1. Celestial Thread (18s) - Pinpoint through pass
2. Orbit Step (20s) - Circular dribble escape
3. Quiet Command (25s) - Team buff + field control

Awakening: ETERNAL CONSTELLATION (30s)
- Activates: Press X
- Cutscene: Starfield appears, future visible
- Dialogue: 3 calm lines about listening

Awakened Abilities (3):
1. Harmonic Playbook (30s) - Auto-attacking structure
2. Supernova Split (38s) - Curved shot or mega pass
3. Eternal Apex (60s) - Ultimate with time slowdown

Passive: Pattern Reading
- Maps player movement patterns
- Teammate path suggestions
- Cooldown reduction on passes
- VFX: Constellation lines, predictive trails

Flow: Constellation Sync
- Base Buff: +25-32.5% to 3 random attributes
- Stacking: +2% per pass (max +10%)
- Vision Radius: Increases with passes
- Total Max: +35-42.5% per attribute
```

### KingdomAbsoluteSovereignFlow.cs
```csharp
// VAASU'S FLOW SYSTEM

Flow Type: All-Round Dominator

Activation:
- Requires: 35% flow bar
- Press: F key
- Duration: 15 seconds

Buff System:
- Select: 4 random attributes
- Base: +35% each
- Stacking: +2% per successful action
- Max Stack: +10%
- Total Max: +45% per attribute

Attributes Available (12):
Speed, Acceleration, Dribbling, BallControl
ShootingPower, ShootingAccuracy, Passing, Vision
ReactionSpeed, Stamina, Interceptions, Curve

VFX:
- Stadium darkens
- Golden chessboard spreads
- Platinum light erupts
- Golden chess pieces orbit
- Shattered-space footprints

SFX:
- Activation: Bass shockwave, choir, chess impact
- Active: Ticking clock, echoing footsteps, cosmic hum
- Max Stacks: Throne cracking, ascension effect

Dialogue:
- Activation: "You've all been playing football..."
- End: "Checkmate" or variations

Stacking Triggers:
- Defeat defender
- Complete pass
- Land shot
```

### ConstellationSyncFlow.cs
```csharp
// AALOK'S FLOW SYSTEM

Flow Type: Adaptive Clarity

Activation:
- Requires: 35% flow bar
- Press: F key
- Duration: 20 seconds

Buff System:
- Select: 3 random attributes
- Base: +25% to +32.5% each (random)
- Stacking: +2% per successful pass
- Max Stack: +10%
- Total Max: +35-42.5% per attribute

Attributes Available (9):
Vision, Passing, Dribbling, BallControl, Speed
Acceleration, ShootingAccuracy, ReactionSpeed, Stamina

VFX:
- Field dims into star map
- Players gain trajectory lines
- Ball orbits with particles
- Aalok highlights 3 optimal actions

SFX:
- Activation: Cosmic resonance, harmonic tones
- Active: Subtle cosmic hum, orchestral pattern
- End: Gentle celestial effect

Dialogue:
- Activation: "Let's make this simple..."
- End: "The structure is there..."

Stacking Triggers:
- Successful pass (primary)
- Vision radius temporary boost
- Each pass increases effectiveness
```

### RaritySystem.cs
```csharp
// 16-TIER RARITY SYSTEM

Rarities (Worst → Best):
1. Common (40%) - Gray, dust particles
2. Uncommon (30%) - Green, sparkles
3. Rare (20%) - Blue, streaks
4. Epic (7%) - Purple, aura
5. Legendary (2%) - Gold, flames
6. Mythic (0.8%) - Crimson, red lightning
7. Divine (0.15%) - White, holy rays
8. Godly (0.05%) - Cyan, floating runes
9. Transcendent - Pink-Violet, reality distortion
10. Secret - Black+Rainbow, void cracks
11. Infinity - Deep Indigo, infinite symbols
12. Celestial - Galaxy Blue, constellations
13. Omniversal - Rainbow, universe expansion
14. Best in History - Platinum, historic silhouettes
15. Eternal Apex - Black-Gold, time-stop effect
16. Absolute Sovereign - Pure White+Rainbow, reality shatter

Features:
- Color assignment per rarity
- Unique VFX per tier
- Unique SFX per tier
- Pull odds scaling
- Cumulative probability
```

### SpinSystem.cs
```csharp
// GACHA SPIN MECHANICS

Spin Types:
1. Standard Spin
   - 10 pulls guaranteed
   - Odds: 50% Common, 35% Uncommon, 15% Rare+
   - Cost: 100 coins

2. Lucky Spin
   - 3 lucky pulls
   - Odds: 0% Common, 30% Uncommon, 50% Rare, 20% Epic+
   - Cost: 300 coins

3. Ultra Spin
   - 5 ultra pulls
   - Odds: 0% Uncommon-, 5% Uncommon, 40% Rare, 40% Epic, 15% Legendary+
   - Cost: 500 coins

4. Infinity Spin
   - 1 guaranteed Infinity+
   - Guaranteed: Infinity, Omniversal, or higher
   - Cost: 5000 coins

Features:
- Probability calculation
- Pity system (guaranteed after X pulls)
- Currency management
- Pull history
- Duplicate handling
```

### RankingSystem.cs
```csharp
// 12-RANK PROGRESSION

Ranks (Progression):
1. Rookie - 5 stars × 3 wins = 15 total
2. Sophomore - 5 stars × 3 wins = 15 total
3. Bronze - 5 stars × 3 wins = 15 total
4. Silver - 5 stars × 3 wins = 15 total
5. Gold - 5 stars × 3 wins = 15 total
6. Platinum - 5 stars × 4 wins = 20 total
7. Diamond - 5 stars × 5 wins = 25 total
8. Champion - 5 stars × 10 wins = 50 total
9. Grand Champion - 5 stars × 10 wins = 50 total
10. Elite Baller - 5 stars × 10 wins = 50 total
11. Street Ball Master - 5 stars × 10 wins = 50 total
12. The God of Football - ∞ (final rank)

Rank Up Requirements:
- Collect 5 stars
- Each star = required wins for rank
- Win ranked matches
- Progress linear to final rank

Features:
- Star tracking
- Win counting
- Rank persistence
- Leaderboard integration (future)
- Season resets (future)
```

### FlowStateSystem.cs
```csharp
// BASE FLOW MECHANICS

Flow Bar:
- Builds from 0-100%
- Activation threshold: 35%
- Depletes over time or uses

Flow Triggers:
- Successful passes
- Tackles/interceptions
- Skill moves
- Possession maintenance
- Team contributions

Flow Duration:
- Standard: 10-15 seconds
- With stacks: 15-30 seconds
- Depletes: 1 unit/sec base

Stacking System:
- +2% per successful action
- Maximum: +10% bonus
- Total multiplier: Base + Stack
- Resets on flow end

Features:
- Smooth bar animation
- Buff application
- Cooldown tracking
- Duration management
- State persistence

---

## Code Organization

### Folder Structure
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
└── Configuration/
    ├── GameSettings.json
    └── SpinOdds.json
```

### Dependencies Map

```
GameManager (root)
├── InputController
│   └── PlayerController
│       ├── BallPhysics
│       ├── VaasuJohnsonStyle
│       ├── AalokStyle
│       ├── KingdomAbsoluteSovereignFlow
│       └── ConstellationSyncFlow
├── UIManager
│   └── GameManager (feedback loop)
├── RaritySystem
├── SpinSystem
│   └── RaritySystem
├── RankingSystem
├── FlowStateSystem
└── RoomManager (Network)
```

---

## Common Tasks

### How to Add a New Character

1. Create new file: `Assets/Scripts/Styles/NewCharacterStyle.cs`
2. Inherit from MonoBehaviour
3. Implement base abilities (Z/V/B/C keys)
4. Implement awakening (X key)
5. Create corresponding flow: `Assets/Scripts/Systems/NewCharacterFlow.cs`
6. Register in `StyleManager.cs`
7. Register flow in `FlowManager.cs`
8. Test in `InputController.cs`

### How to Add a New Ability

1. Create Ability struct with name, cooldown, key
2. Implement Execute method in character script
3. Add cooldown tracking in Update()
4. Add input handling in HandleInput()
5. Add VFX/SFX calls
6. Register in character initialization

### How to Add a New Flow Attribute

1. Add to AttributeType enum in flow script
2. Add to attribute buff dictionary
3. Implement buff application in ApplySpecificBuff()
4. Add to selectable attributes list
5. Test with random selection

---

## Testing Commands

### Console Debug Commands

```csharp
// Character switching
GameManager.Instance.SelectCharacter(GameManager.PlayerCharacter.VaasuJohnson);
GameManager.Instance.SelectCharacter(GameManager.PlayerCharacter.Aalok);

// Flow activation
flowSystem.ActivateFlow();

// Ability triggering
vaasuStyle.ExecuteRoyalSerpent();
aalokStyle.ExecuteCelestialThread();

// Stat checking
Debug.Log(vaasuStyle.GetSpeed());
Debug.Log(aalokStyle.GetVision());

// Flow checking
Debug.Log(flow.GetFlowDuration());
Debug.Log(flow.GetStackBonus());
```

---

Generated: 2026-06-04
Version: 1.0 Complete Reference
````
