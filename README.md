
# Task 2: [Pattern Name] Implementation

## Student Info
- Name: Samantha Santasiero
- ID: ssant017

## Pattern: Singleton
### Implementation
In this project, I implemented the Singleton Pattern by creating a GameManager class that ensures only one instance exists throughout the game. I used a static Instance property and checked in Awake() whether another instance already exists, destroying duplicates if necessary. The DontDestroyOnLoad method keeps the single instance alive across scene changes. This approach centralizes game data like score, lives, and enemy counts, making it accessible from any script. It also provides a single point to manage game states such as pausing, restarting, and ending the game, keeping the project organized and preventing conflicting updates.

### Game Integration
The Singleton Pattern is used as the core controller of the game, allowing multiple scripts, including the player, enemies, and collectibles, to communicate with a single, consistent GameManager instance. This setup ensures that score, lives, and enemy tracking remain synchronized, even across scene reloads. For example, when the player collects items or defeats enemies, scripts call the GameManager instance to update points or handle deaths. The game over panel and replay functionality also rely on this singleton, allowing any component to trigger the game-ending sequence without creating multiple managers, simplifying both logic and debugging during development.

## Game Description
- Title: Shoots and Splatters
- Controls: Move with Arrow keys or WASD. Left mouse button for Shoot.
- Objective: The goal of the game is to survive as long as possible while defeating enemies and collecting items to earn points. Players must avoid losing all their lives; the game ends when lives reach zero. High scores are tracked, and defeating enemies increases both your score and game difficulty. The objective is to maximize your score before the game ends.

## Repository Stats
- Total Commits: 23
- Development Time: 10 hours