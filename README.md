# Slot Machine Game
A complete slot machine game built in Unity as part of the Rural Games internship assignment.

## Project Overview
A 2D slot machine game featuring 3 reels, 4 symbols, win detection, balance management, 
bet system, sound effects, and a win popup. Built using Unity with clean OOP architecture 
and ScriptableObjects for data management.

## Gameplay Features
- 3 spinning reels with smooth scroll animation
- 4 symbols: Lucky 7, BAR, Bell, Cherry
- Adjustable bet system: 10 / 25 / 50 / 100
- Player balance tracking

## Win Conditions
All 3 reels must show the same symbol on the center row:
- Lucky 7 x3 = 100x bet
- BAR x3 = 50x bet
- Bell x3 = 25x bet
- Cherry x3 = 10x bet

## How To Run Project
1. Clone the repository
2. Open Unity Hub → Add → select the cloned folder
3. Open in Unity 6
4. Open Assets/Scenes/SampleScene
5. Press Play

## How To Run WebGL Build
1. Navigate to Build/WebGL/
2. Open index.html in a browser
   (Note: use a local server if browser blocks local file access.
   Use VS Code Live Server extension or run: python -m http.server)

## Development Approach
Built phase by phase:
1. ScriptableObject data layer for symbols and payouts
2. ReelController with coroutine-based scroll animation
3. RNG system generating independent results per reel
4. Win detection comparing all reel center results
5. Balance and bet management with Observer Pattern events
6. UI wired via event subscription, no direct polling
7. Audio managed through dedicated AudioManager

## Architecture Overview
| Script | Responsibility |
|---|---|
| SlotMachineManager | Orchestrates game flow |
| ReelController | Per-reel spin and stop animation |
| RNGSystem | Independent random result per reel |
| WinChecker | Evaluates results against win conditions |
| BalanceManager | Tracks balance and bet, fires change events |
| UIManager | Subscribes to events, updates all UI |
| AudioManager | Plays sounds at correct game moments |
| SymbolData | ScriptableObject — symbol name, sprite, payout |
| SymbolDatabase | ScriptableObject — holds all symbols as array |
