# Herdsman

![Herdsmen](https://github.com/AntonioZhezhel/Herdsman/assets/42389663/46a959d7-3573-4aba-bc48-8731369e0e32)

## Description

Please create a simple 2D prototype of the mini-game where the player can collect animals using Main Hero and move them to the destination point (yard).

## AC:

    1. Player run the application and can see the game field (green area) with Main Hero (red circle).
    2. Player can see the random number of animals (white circles) located on the game field at random positions.
    3. Player can see the destination point: yard (yellow area).
    4. Player can see the score value at the Top UI.
    5. Player can click on the game filed and the Main Hero must move to the click position.
    6. If the Main Hero moves close to animal it will follow the Main Hero – create a group. The max number of the animals in the group is 5.
    7. If the animal reaches the yard the score counter increased.
    
## Additional (optional) AC:

    1. Create a spawn generator which will spawn animals in random time intervals at random positions.
    2. Create a patrol behaviour for the animals. During the patrol animals cannot move to the yard without Main Hero.

# MovementAI

The **MovementAI** script is responsible for the movement of animals outside the yard. It has the following features:
- Moves the animal towards a random position within the yard, if the path is clear.
- Sets a new target position when the animal reaches the current one.
- Avoids moving inside the yard if the animal is not currently inside.
- Uses pathfinding to ensure a valid path to the target position.

# SpawnAnimals

The **SpawnAnimals** script spawns animals in the game world. It:
- Spawns a set number of animals at the start of the game.
- Continues to spawn additional animals over time, with a random delay.
- Spawns animals at random positions outside the yard.
- Checks if the spawn position is inside the yard and selects a new position if so.

# SpawnPlayer

The **SpawnPlayer** script spawns the player character at a random position.

# AnimalManager

The **AnimalManager** script manages the animals that are following the player. It:
- Maintains a list of the animals currently following the player.
- Provides methods to add and remove animals from the list.
- Keeps track of the number of animals following the player.

# ScoreCounter

The **ScoreCounter** script keeps track of the player's score. It:
- Updates the score when an animal enters the player's collider.
- Displays the current score on the screen using a TextMeshProUGUI component.

# CheckAnimalTag

The **CheckAnimalTag** script detects when an animal enters the player's collider and updates the score accordingly.

# SpawnYard

The **SpawnYard** script spawns the yard in the game world. It:
- Spawns the yard prefab at a random position.
- Provides a reference to the spawned yard object.
- Raises an event when the yard is spawned.

# Movement

The **Movement** script handles the movement of the player character. It:
- Allows the player to move the character by clicking on the screen.
- Moves the character towards the clicked position using a **MoveTowards** function.

# AnimalMovement

The **AnimalMovement** script handles the movement of animals when they are following the player. It:
- Inherits from the **BaseMovement** script, which provides basic movement functionality.
- Allows animals to start and stop following the player.
- Sets the animal's target position to the player's position when following.

# AnimalBehavior

The **AnimalBehavior** script manages the behavior of animals in the game. It:
- Controls when an animal starts following the player and when it enters the yard.
- Enables and disables the **AnimalMovement** and **MovementAI** scripts based on the animal's state.
- Adds and removes animals from the **AnimalManager** list when they start and stop following the player.
