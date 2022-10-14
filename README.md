# Project

The game will be a farmer running down a road, jumping over obstacles. If the obstacles hit the farmer, the game is over. Score is measured in time.

# Plan

From some provided visual assets, create a farmer running statically with the scene rushing past them. The background is a 2D mural behind the farmer. The farmer has a running animation, a jumping animation, and a death animation.

# Components

## Camera Manager

The camera manager is responsible for keeping the camera close to the player.

## Obstacle Manager

The obstacle manager is responsible for instantiating the obstacles the player will face. This instantiation takes place through an Obstacle Factory

### Obstacle factory

Responsible for instantiating obstacles

### Move Obstacle

Responsible for moving the instantiated obstacle along the track towards the player

## Score Manager

The score manager is responsible for incrementing the player's score while the game isn't over, and for delivering that information to the UI manager.

## Audio manager

Responsible for playing the correct audio given the game state

## Player input manager

Responsible for correctly processing player input given the game state.

### While the game is not over

The player is able to hop with the spacebar, this propels the farmer upward into the air.

## UI Manager

Responsible for displaying the player's score at the end of the game, and telling them to press space to restart

## Game Manager

The Game Manager is responsible for starting, restarting the game, and for knowing when the game is over.
The GameManager will be notified by another component when the game is over, and will notify other components of that fact, notably:

- The UI manager to display the player's score
- The audio manager to change the music
- the obstacle manager to tell all obstacles to stop, and to stop making new obstacles
- the input manager to stop waiting for player input to move the cube, and to start waiting for spacebar input to reload the scene

When the game is reset, the game scene is reloaded.

# References

- [Project figma](https://www.figma.com/file/lNFpOpDKt4RBl4P19Qvl8f/FarmerRun.Unity?node-id=0%3A1)

# Hosted project

[Here](https://play.unity.com/mg/other/webgl-builds-258950)
