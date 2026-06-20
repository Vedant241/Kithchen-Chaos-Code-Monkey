# 🍔 Kitchen Chaos

> A complete 3D kitchen simulation game built in **Unity 6 (6000.3.9f1)** following the [Code Monkey](https://www.youtube.com/c/CodeMonkeyUnity) tutorial series. Cook, cut, fry, plate, and deliver orders before time runs out!

---

## 📖 Table of Contents

- [About The Game](#-about-the-game)
- [Features](#-features)
- [Gameplay](#-gameplay)
- [Screenshots](#-screenshots)
- [Tech Stack](#-tech-stack)
- [Project Architecture](#-project-architecture)
- [Code Structure](#-code-structure)
- [Design Patterns & Concepts Learned](#-design-patterns--concepts-learned)
- [Skills Learned](#-skills-learned)
- [How to Run](#-how-to-run)
- [Recipes](#-recipes)
- [Acknowledgments](#-acknowledgments)

---

## 🎮 About The Game

**Kitchen Chaos** is a fast-paced 3D cooking simulation where you play as a chef who must prepare and deliver food orders within a time limit. Pick up ingredients, chop them, fry patties on the stove, assemble plates, and deliver completed recipes to earn points. But watch out — leave food on the stove too long and it'll burn!

The project was built as a complete learning exercise covering essential Unity game development concepts from scratch, including player movement, input handling, state machines, event-driven architecture, UI systems, audio, animations, and more.

---

## ✨ Features

- 🎯 **Complete Gameplay Loop** — Main menu → Tutorial → Countdown → Gameplay → Game Over
- 🧑‍🍳 **Player Movement & Interaction** — Smooth grid-based player movement with counter interaction via raycasting
- 🔪 **Multiple Kitchen Stations** — 7 different counter types (Clear, Container, Cutting, Stove, Plates, Delivery, Trash)
- 🍳 **Cooking Mechanics** — Cutting, frying, burning, and plating systems with progress bars
- 📋 **Recipe & Delivery System** — Dynamic recipe generation with visual order tracking
- ⏱️ **Timer-Based Gameplay** — Countdown timer with game state management
- 🎵 **Full Audio System** — SFX for chopping, frying, walking, warnings, success/failure + background music
- ⚙️ **Options Menu** — Sound effects volume, music volume, and key rebinding
- 🎨 **Shader Graph** — Custom visual shader for moving counter visual effects
- 💡 **Post-Processing** — URP-based global volume with post-processing effects
- ⏸️ **Pause System** — Full pause/resume with Time.timeScale control
- 📖 **Tutorial System** — In-game tutorial showing control bindings (keyboard + gamepad)
- 🔄 **Scene Management** — Main Menu → Loading Scene → Game Scene flow
- 🎮 **Gamepad Support** — Full controller support via Unity's New Input System

---

## 🕹️ Gameplay

1. **Start** — Launch the game and press Play on the Main Menu
2. **Tutorial** — Learn the controls (Move, Interact, Alternate Interact, Pause)
3. **Countdown** — A 3-2-1 countdown initiates the round
4. **Cook** — Pick up ingredients from Container Counters
5. **Prepare** — Cut vegetables at the Cutting Counter, fry patties on the Stove
6. **Plate** — Pick up a plate from the Plates Counter and add ingredients
7. **Deliver** — Bring the completed plate to the Delivery Counter
8. **Score** — Earn points for each successfully delivered recipe
9. **Game Over** — When time runs out, see your total deliveries

### Controls

| Action              | Keyboard         | Gamepad           |
| ------------------- | ---------------- | ----------------- |
| Move                | WASD             | Left Stick        |
| Interact            | E                | A (Xbox) / X (PS) |
| Alternate Interact  | F                | B (Xbox) / ○ (PS) |
| Pause               | Escape           | Start             |

---

## 🛠️ Tech Stack

| Technology                     | Version    | Purpose                               |
| ------------------------------ | ---------- | ------------------------------------- |
| **Unity**                      | 6000.3.9f1 | Game Engine (Unity 6)                 |
| **C#**                         | —          | Programming Language                  |
| **Universal Render Pipeline**  | 17.3.0     | Rendering Pipeline                    |
| **Input System**               | 1.18.0     | New Input System (keyboard + gamepad) |
| **Cinemachine**                | 2.10.5     | Camera System                         |
| **TextMesh Pro**               | —          | Advanced Text Rendering               |
| **Shader Graph**               | —          | Visual Shader Authoring               |
| **Timeline**                   | 1.8.10     | Cinematic Sequencing                  |

---

## 🏗️ Project Architecture

```
Kitchen Chaos(Code Monkey)/
├── Assets/
│   ├── Animations/                    # Player Idle & Walk animations + Animator Controller
│   │   ├── Idle.anim
│   │   ├── Walk.anim
│   │   └── MyPlayerAnimator.controller
│   │
│   ├── PlayerInputActions.inputactions # Input Action Asset (Move, Interact, AltInteract, Pause)
│   ├── PlayerInputActions.cs           # Auto-generated C# wrapper for Input Actions
│   │
│   ├── Prefabs/
│   │   ├── Counters/                  # 13 counter prefabs (Clear, Container×5 variants, Cutting, etc.)
│   │   │   ├── _BaseCounnter.prefab
│   │   │   ├── ClearCounter.prefab
│   │   │   ├── ContainerCounter.prefab
│   │   │   ├── ContainerCounter_Bread.prefab
│   │   │   ├── ContainerCounter_Cabbage.prefab
│   │   │   ├── ContainerCounter_CheeseBlock.prefab
│   │   │   ├── ContainerCounter_PattyUncooked.prefab
│   │   │   ├── ContainerCounter_Tomato.prefab
│   │   │   ├── CuttingCounter.prefab
│   │   │   ├── DeliveryCounter.prefab
│   │   │   ├── PlatesCounter.prefab
│   │   │   ├── StoveCounter.prefab
│   │   │   └── TrashCounter.prefab
│   │   │
│   │   ├── KitchenObjects/            # 11 kitchen object prefabs
│   │   │   ├── Bread.prefab
│   │   │   ├── Cabbage.prefab
│   │   │   ├── CabbageSlices.prefab
│   │   │   ├── CheeseBlock.prefab
│   │   │   ├── CheeseSlices.prefab
│   │   │   ├── PattyUncooked.prefab
│   │   │   ├── PattyCooked.prefab
│   │   │   ├── PattyBurned.prefab
│   │   │   ├── Plates.prefab
│   │   │   ├── Tomato.prefab
│   │   │   └── TomatoSlices.prefab
│   │   │
│   │   └── ProgressBarUI.prefab       # Reusable progress bar prefab
│   │
│   ├── Scenes/
│   │   ├── MainMenuScene.unity        # Main menu with Play button
│   │   ├── LoadingScene.unity         # Loading transition scene
│   │   ├── GameScene.unity            # Core gameplay scene
│   │   └── GameScene/
│   │       └── Global Volume Profile.asset  # Post-processing settings
│   │
│   ├── Scripts/                       # 🧠 53 C# Scripts (see Code Structure below)
│   │   ├── Counters/                  # 12 counter scripts
│   │   ├── ScriptableObjects/         # 7 ScriptableObject definitions
│   │   └── UI/                        # 15 UI scripts
│   │
│   ├── ScriptableObjects/             # ScriptableObject data assets
│   │   ├── AudioClipRefsSO.asset
│   │   ├── KitchenObjectsSO/          # 11 kitchen object definitions
│   │   ├── CuttingRecipeSO/           # 3 cutting recipes
│   │   ├── FryingRecipeSO/            # 1 frying recipe
│   │   ├── BurningRecipeSO/           # 1 burning recipe
│   │   └── RecipeSO/                  # 4 delivery recipes + RecipeList
│   │
│   ├── Settings/                      # URP renderer & pipeline settings
│   ├── Shaders/
│   │   └── MovingVisual.shadergraph   # Custom shader for counter visuals
│   │
│   ├── _Assets/                       # Provided course assets
│   │   ├── Animations/                # Pre-made animations
│   │   ├── Materials/                 # Materials & textures
│   │   ├── Meshes/                    # 3D models (counters, kitchen objects, player)
│   │   ├── PrefabsVisuals/            # Visual-only prefab variants
│   │   ├── Sounds/
│   │   │   ├── Music/                 # Background music tracks
│   │   │   └── SFX/                   # Sound effects (chop, sizzle, trash, etc.)
│   │   └── Textures/                  # UI textures and sprites
│   │
│   └── TextMesh Pro/                  # TMP essentials
│
├── Packages/                          # Unity Package Manager dependencies
├── ProjectSettings/                   # Unity project-level settings
└── README.md                          # This file
```

---

## 📝 Code Structure

The project contains **53 C# scripts** organized across **4 systems**:

### 🎮 Core Systems (19 scripts)

| Script | Description |
| ------ | ----------- |
| [Player.cs](Assets/Scripts/Player.cs) | **Main player controller** — handles movement (WASD/gamepad), counter selection via raycasting, interaction with counters, and implements `IKitchenObjectParents`. Uses `Singleton` pattern with `Player.Instance`. |
| [GameInput.cs](Assets/Scripts/GameInput.cs) | **Input manager** — wraps Unity's New Input System, fires C# events (`OnInteractAction`, `OnInteractAlternateAction`, `OnPauseAction`). Handles key rebinding with `PlayerPrefs` persistence. Singleton pattern. |
| [GameManager.cs](Assets/Scripts/GameManager.cs) | **Game state machine** — manages states: `WaitingToStart` → `CountDownToStart` → `GamePlaying` → `GameOver`. Controls game timer and pause via `Time.timeScale`. Singleton pattern. |
| [KitchenObject.cs](Assets/Scripts/KitchenObject.cs) | **Base class for all kitchen objects** — manages parent-child relationships via `IKitchenObjectParents`, handles spawning (`SpawnKitchenObject` static method), self-destruction, and ScriptableObject reference. |
| [DeliveryManager.cs](Assets/Scripts/DeliveryManager.cs) | **Order management** — spawns random recipe orders on a timer, validates delivered plates against waiting recipes, fires success/failure events. Singleton pattern. |
| [PlateKitchenObject.cs](Assets/Scripts/PlateKitchenObject.cs) | **Plate with ingredients** — extends `KitchenObject`, tracks added ingredients via `KitchenObjectsSO` list, validates ingredient combinations, fires `OnIngredientAdded` event. |
| [PlateCompleteVisual.cs](Assets/Scripts/PlateCompleteVisual.cs) | **Plate visual representation** — shows/hides ingredient GameObjects on the plate based on what's been added. |
| [IKitchenObjectParents.cs](Assets/Scripts/IKitchenObjectParents.cs) | **Interface** — defines contract for anything that can hold a kitchen object (`GetKitchenObjectFollowTransform()`, `SetKitchenObject()`, `GetKitchenObject()`, `ClearKitchenObject()`, `HasKitchenObject()`). |
| [IHasProgress.cs](Assets/Scripts/IHasProgress.cs) | **Interface** — defines `OnProgressChanged` event for counters that show progress bars (cutting, frying). |
| [LookAtCamera.cs](Assets/Scripts/LookAtCamera.cs) | **Billboard utility** — makes UI elements (progress bars, plate icons) always face the camera. Supports multiple modes: `LookAt`, `LookAtInverted`, `CameraForward`, `CameraForwardInverted`. |
| [SoundManager.cs](Assets/Scripts/SoundManager.cs) | **SFX manager** — plays positional audio clips for all game actions (chop, delivery success/fail, pickup, drop, trash, footsteps, warnings). Volume control saved to `PlayerPrefs`. Singleton. |
| [MusicManager.cs](Assets/Scripts/MusicManager.cs) | **Music manager** — controls background music volume via `AudioSource`. Volume saved to `PlayerPrefs`. Singleton. |
| [PlayerAnimator.cs](Assets/Scripts/PlayerAnimator.cs) | **Player animation controller** — sets `IsWalking` Animator parameter based on `Player.IsWalking` state. |
| [PlayerSounds.cs](Assets/Scripts/PlayerSounds.cs) | **Footstep sounds** — plays walking SFX at timed intervals when the player is moving. |
| [SelectedCounterVisuals.cs](Assets/Scripts/SelectedCounterVisuals.cs) | **Counter highlight** — shows/hides visual selection indicator when a counter is selected by the player. |
| [StoveCounterSound.cs](Assets/Scripts/StoveCounterSound.cs) | **Stove audio** — plays/stops sizzling sound based on stove frying/burning state, with pitch randomization warning effect. |
| [Loader.cs](Assets/Scripts/Loader.cs) | **Scene loader** — static utility for async scene loading via a loading scene intermediate (`MainMenu` → `Loading` → `Game`). |
| [LoaderCallback.cs](Assets/Scripts/LoaderCallback.cs) | **Loading callback** — triggers the actual target scene load after the loading scene renders one frame. |
| [ResetStaticDataManager.cs](Assets/Scripts/ResetStaticDataManager.cs) | **Static data cleanup** — resets all static event references on scene load to prevent memory leaks. |

---

### 🧱 Counter System (12 scripts)

All counters inherit from `BaseCounter`, which implements `IKitchenObjectParents`.

```
BaseCounter (abstract base)
├── ClearCounter          — Simple surface to place/swap objects
├── ContainerCounter      — Spawns a specific ingredient (Bread, Tomato, etc.)
├── CuttingCounter        — Cuts ingredients with progress (implements IHasProgress)
├── StoveCounter          — Fries/burns patties with state machine (implements IHasProgress)
├── PlatesCounter         — Auto-spawns plates on a timer
├── DeliveryCounter       — Validates and delivers completed plates
└── TrashCounter          — Destroys held kitchen objects
```

| Script | Description |
| ------ | ----------- |
| [BaseCounter.cs](Assets/Scripts/Counters/BaseCounter.cs) | **Abstract base class** — implements `IKitchenObjectParents`, provides virtual `Interact()` and `InteractAlternate()` methods, holds static `OnAnyObjectPlacedHere` event. |
| [ClearCounter.cs](Assets/Scripts/Counters/ClearCounter.cs) | **Storage surface** — place items down, pick them up, or swap between player and counter. Handles plate-ingredient combining logic. |
| [ContainerCounter.cs](Assets/Scripts/Counters/ContainerCounter.cs) | **Ingredient dispenser** — spawns a configured `KitchenObjectsSO` when interacted with (only if player's hands are empty). Fires `OnPlayerGrabbedObject` event. |
| [ContainerCounterVisual.cs](Assets/Scripts/Counters/ContainerCounterVisual.cs) | **Container animation** — plays open/close Animator trigger on grab interaction. |
| [CuttingCounter.cs](Assets/Scripts/Counters/CuttingCounter.cs) | **Cutting station** — places objects, alternate interact chops them with `cuttingProgress` tracking. Uses `CuttingRecipeSO[]` to define input→output mappings. Implements `IHasProgress` for UI. Fires `OnAnyCut` static event for SFX. |
| [CuttingCounterVisual.cs](Assets/Scripts/Counters/CuttingCounterVisual.cs) | **Cutting animation** — plays "Cut" Animator trigger on each chop action. |
| [DeliveryCounter.cs](Assets/Scripts/Counters/DeliveryCounter.cs) | **Order delivery** — accepts only plates (`PlateKitchenObject`), passes to `DeliveryManager` for recipe validation. |
| [PlatesCounter.cs](Assets/Scripts/Counters/PlatesCounter.cs) | **Plate spawner** — auto-spawns plates on a timer (up to a max count), fires `OnPlateSpawned`/`OnPlateRemoved` events. |
| [PlatesCounterVisual.cs](Assets/Scripts/Counters/PlatesCounterVisual.cs) | **Plate stack visual** — instantiates/destroys visual plate GameObjects that stack on top of each other. |
| [StoveCounter.cs](Assets/Scripts/Counters/StoveCounter.cs) | **Frying station** — uses a **4-state state machine** (`Idle` → `Frying` → `Fried` → `Burned`). Uses `FryingRecipeSO` and `BurningRecipeSO` for cooking timers. Implements `IHasProgress` with separate progress tracking for frying and burning. |
| [StoveCounterVisual.cs](Assets/Scripts/Counters/StoveCounterVisual.cs) | **Stove visuals** — shows/hides `stoveOnGameObject` and `particlesGameObject` based on frying state. |
| [TrashCounter.cs](Assets/Scripts/Counters/TrashCounter.cs) | **Trash can** — destroys the player's held kitchen object on interact. Fires `OnAnyObjectTrashed` static event. |

---

### 🎨 UI System (15 scripts)

| Script | Description |
| ------ | ----------- |
| [MainMenuUI.cs](Assets/Scripts/UI/MainMenuUI.cs) | Main menu — Play button triggers `Loader.Load(GameScene)`, Quit button exits application. |
| [TutorialUI.cs](Assets/Scripts/UI/TutorialUI.cs) | Tutorial overlay — displays all control bindings (keyboard + gamepad), auto-hides when countdown starts. Updates on key rebind. |
| [GameStartCountDownUI.cs](Assets/Scripts/UI/GameStartCountDownUI.cs) | Countdown display — shows 3, 2, 1 numbers with pop-up animation (`NumberPopup` Animator trigger) and SFX. |
| [GamePlayingClockUI.cs](Assets/Scripts/UI/GamePlayingClockUI.cs) | Timer clock — displays game timer as a fill-amount image (circular countdown). |
| [GamePauseUI.cs](Assets/Scripts/UI/GamePauseUI.cs) | Pause menu — Resume, Options, and Main Menu buttons. Shows/hides based on `GameManager` pause state. |
| [OptionsUI.cs](Assets/Scripts/UI/OptionsUI.cs) | Options menu — SFX/music volume controls, key rebinding for all actions (Move Up/Down/Left/Right, Interact, Alt Interact, Pause + Gamepad equivalents). Shows a rebind overlay during rebinding. |
| [GameOverUI.cs](Assets/Scripts/UI/GameOverUI.cs) | Game over screen — shows total successful deliveries count from `DeliveryManager`. |
| [DeliveryManagerUI.cs](Assets/Scripts/UI/DeliveryManagerUI.cs) | Recipe order list — dynamically creates/destroys recipe order UI entries as orders spawn/complete. |
| [DeliveryManagerSingleUI.cs](Assets/Scripts/UI/DeliveryManagerSingleUI.cs) | Single recipe card — displays recipe name and ingredient icons for one pending order. |
| [DeliveryResultUI.cs](Assets/Scripts/UI/DeliveryResultUI.cs) | Delivery feedback — shows "Delivered!" (green) or "Failed!" (red) popup with icon and animation. |
| [PlateIconsUI.cs](Assets/Scripts/UI/PlateIconsUI.cs) | Plate ingredient icons — spawns small ingredient icons on the plate's world-space UI as ingredients are added. |
| [PlateIconsSingleUI.cs](Assets/Scripts/UI/PlateIconsSingleUI.cs) | Single plate icon — displays one ingredient sprite on the plate icon strip. |
| [ProgressBarUI.cs](Assets/Scripts/UI/ProgressBarUI.cs) | Generic progress bar — subscribes to any `IHasProgress` implementor, shows/hides based on progress value. |
| [StoveBurnWarningUI.cs](Assets/Scripts/UI/StoveBurnWarningUI.cs) | Burn warning overlay — shows a warning icon when food is close to burning (>50% burn progress). |
| [StoveBurnFlashingBarUI.cs](Assets/Scripts/UI/StoveBurnFlashingBarUI.cs) | Flashing burn bar — flashes the progress bar red using Animator when food is about to burn. |

---

### 📦 ScriptableObject Definitions (7 scripts)

| Script | Description |
| ------ | ----------- |
| [KitchenObjectsSO.cs](Assets/Scripts/ScriptableObjects/KitchenObjectsSO.cs) | Defines a kitchen object — stores `prefab`, `sprite`, and `objectName`. |
| [RecipeSO.cs](Assets/Scripts/ScriptableObjects/RecipeSO.cs) | Defines a recipe — stores `recipeName` and a `List<KitchenObjectsSO>` of required ingredients. |
| [RecipeListSO.cs](Assets/Scripts/ScriptableObjects/RecipeListSO.cs) | Stores all available recipes — `List<RecipeSO>` used by `DeliveryManager`. |
| [CuttingRecipeSO.cs](Assets/Scripts/ScriptableObjects/CuttingRecipeSO.cs) | Cutting recipe data — defines `input` KitchenObjectsSO, `output` KitchenObjectsSO, and `cuttingProgressMax`. |
| [FryingRecipeSO.cs](Assets/Scripts/ScriptableObjects/FryingRecipeSO.cs) | Frying recipe data — defines `input`, `output`, and `fryingTimerMax`. |
| [BurningRecipeSO.cs](Assets/Scripts/ScriptableObjects/BurningRecipeSO.cs) | Burning recipe data — defines `input`, `output`, and `burningTimerMax`. |
| [AudioClipRefsSO.cs](Assets/Scripts/ScriptableObjects/AudioClipRefsSO.cs) | Audio clip references — stores arrays of `AudioClip[]` for chop, delivery success/fail, footsteps, object pickup/drop, stove sizzle, trash, and warning sounds. |

---

### 🍽️ ScriptableObject Data Assets

| Category | Assets |
| -------- | ------ |
| **Kitchen Objects** (11) | Bread, Cabbage, CabbageSlices, CheeseBlock, CheeseSlices, PattyUncooked, PattyCooked, PattyBurned, Plate, Tomato, TomatoSlices |
| **Cutting Recipes** (3) | Cabbage → CabbageSlices, CheeseBlock → CheeseSlices, Tomato → TomatoSlices |
| **Frying Recipes** (1) | PattyUncooked → PattyCooked |
| **Burning Recipes** (1) | PattyCooked → PattyBurned |
| **Delivery Recipes** (4) | Burger, CheeseBurger, MegaBurger, Salad |

---

## 🧠 Design Patterns & Concepts Learned

### Design Patterns

| Pattern | Where Used | What It Does |
| ------- | ---------- | ------------ |
| **Singleton** | `Player`, `GameInput`, `GameManager`, `DeliveryManager`, `SoundManager`, `MusicManager` | Ensures only one instance exists, accessible globally via `.Instance` |
| **Observer / Event-Driven** | Throughout the entire project | C# `event`s and `EventHandler` delegate system for loose coupling between systems |
| **State Machine** | `GameManager` (game states), `StoveCounter` (cooking states) | Enum-based finite state machines controlling behavior transitions |
| **Strategy / Data-Driven** | `ScriptableObject` recipe system | Recipes defined as data assets, not hardcoded — easily extensible |
| **Interface Segregation** | `IKitchenObjectParents`, `IHasProgress` | Clean contracts for kitchen object parenting and progress tracking |
| **Template Method** | `BaseCounter` with virtual methods | Base class defines structure, subclasses override specific behavior |
| **Factory Method** | `KitchenObject.SpawnKitchenObject()` | Static method encapsulates object instantiation logic |
| **Component Pattern** | Visual + Logic separation (e.g., `StoveCounter` + `StoveCounterVisual`) | Separating game logic from visual representation |

### Architecture Principles

- **Event-Driven Architecture** — Systems communicate via C# events, minimizing direct dependencies
- **Static Events** — `OnAnyObjectPlacedHere`, `OnAnyCut`, `OnAnyObjectTrashed` enable global listeners (like `SoundManager`) without tight coupling
- **Separation of Concerns** — Logic scripts separated from Visual scripts (e.g., `CuttingCounter.cs` vs `CuttingCounterVisual.cs`)
- **Data-Driven Design** — All recipes, ingredients, and audio clips configured via ScriptableObjects
- **Scene Management** — Multi-scene architecture with loading screen transition
- **PlayerPrefs Persistence** — Audio volumes and key bindings saved between sessions
- **Static Data Reset** — `ResetStaticDataManager` clears static event subscribers on scene reload to prevent memory leaks

---

## 📚 Skills Learned

### Unity Engine
- ✅ Unity 6 (URP) project setup and configuration
- ✅ Universal Render Pipeline (URP) with post-processing
- ✅ Scene management (multi-scene loading with intermediate loading scene)
- ✅ Prefab system (nested prefabs, prefab variants)
- ✅ Animator Controller with states and transitions
- ✅ Shader Graph (custom `MovingVisual` shader)
- ✅ Cinemachine camera system
- ✅ TextMesh Pro for UI text rendering
- ✅ Audio system (AudioSource, AudioListener, positional audio, volume control)

### C# Programming
- ✅ Object-Oriented Programming (inheritance, polymorphism, abstraction)
- ✅ Interfaces (`IKitchenObjectParents`, `IHasProgress`)
- ✅ C# Events and Delegates (`EventHandler`, `EventHandler<T>`, custom EventArgs)
- ✅ Static methods and events
- ✅ Enums and state management
- ✅ Generics and Lists
- ✅ Singleton pattern implementation
- ✅ String-based serialization for key bindings
- ✅ Null-safety patterns and conditional logic

### Game Development
- ✅ Player movement with physics-based collision (capsule-based collision detection)
- ✅ Raycasting for object/counter selection
- ✅ New Input System (action maps, key rebinding, multi-device support)
- ✅ Finite State Machines (game flow, cooking states)
- ✅ Spawning systems (ingredients, plates, recipes)
- ✅ Timer-based mechanics (cooking timers, game timer, spawn intervals)
- ✅ Object interaction and pickup/drop mechanics
- ✅ Recipe validation system
- ✅ Progress bar system (generic, reusable)
- ✅ Score tracking and delivery management

### UI Development
- ✅ Canvas-based UI (Screen Space, World Space)
- ✅ Dynamic UI generation (spawning/destroying UI elements at runtime)
- ✅ Popup animations and visual feedback
- ✅ Billboard UI (world-space elements facing camera)
- ✅ Options menu with volume sliders
- ✅ Key rebinding UI with interactive overlay
- ✅ Game state-driven UI visibility (show/hide based on game state)

### Software Engineering
- ✅ Event-driven architecture for decoupled systems
- ✅ Separation of concerns (logic vs visual components)
- ✅ Data-driven design with ScriptableObjects
- ✅ Preventing memory leaks (static event cleanup)
- ✅ PlayerPrefs for persistent settings
- ✅ Clean code organization (folders by feature)
- ✅ Version control with Git

---

## 🚀 How to Run

### Prerequisites
- **Unity Hub** installed
- **Unity 6 (6000.3.9f1)** or compatible version

### Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/Vedant241/Kithchen-Chaos-Code-Monkey.git
   ```

2. **Open in Unity Hub**
   - Click "Open" → navigate to the cloned folder
   - Unity Hub will detect the required version

3. **Open the Main Menu scene**
   - Navigate to `Assets/Scenes/MainMenuScene.unity`

4. **Press Play** ▶️
   - Enjoy the game!

---

## 🍔 Recipes

| Recipe | Ingredients |
| ------ | ----------- |
| 🍔 **Burger** | Bread + Cooked Patty |
| 🧀 **Cheese Burger** | Bread + Cooked Patty + Cheese Slices |
| 🍔 **Mega Burger** | Bread + Cooked Patty + Cheese Slices + Tomato Slices + Cabbage Slices |
| 🥗 **Salad** | Tomato Slices + Cabbage Slices |

---

## 🙏 Acknowledgments

- **[Code Monkey](https://www.youtube.com/c/CodeMonkeyUnity)** — Tutorial series creator and instructor
- **Unity Technologies** — Game engine and tools
- Course assets (3D models, textures, sounds, materials) provided as part of the [Kitchen Chaos Complete Project](https://unitycodemonkey.com/kitchenchaoscourse.php)

---

## 📄 License

This project was built for educational purposes following the Code Monkey tutorial series. All course-provided assets belong to their respective owners.

---

<div align="center">

**Built with ❤️ in Unity 6 | Learning Game Development One Recipe at a Time 🍳**

</div>
