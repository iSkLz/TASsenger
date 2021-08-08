
# TASsenger
This repository holds the source code for TASsenger, a WÏP TASing mod for The Messenger.

# User Installation
For convenience TASsenger is written using the uModFramework, so you need to install it first from the [official website](https://umodframework.com/download).
Then download the mod's file from the [releases section](https://github.com/iSkLz/TASsenger/releases) and double click it, UMF will automatically install it.
UMF doesn't conflict with the trainer mod so you can use both the trainer and TASsenger at the same time.
Once installed, press L to play the inputs, read the following section for intel on using the mod.

# Inputs
The inputs are written in a file called MT.tas located in the same folder as the game's executable. The mod does not create it by default, you need to do that yourself for the first time. Other than the fancy extension it's a regular text file that you can edit with Notepad or what have you.

Inputs are specified in lines in the following format:
`(frames), (inputs)`
Where frames is the amount of frames to hold the inputs for, example:
```
27, R, J
4
7, R
```
The inputs above will hold jump+right for 27 frames, wait 4 frames then hold right for 7 frames.

The following are acceptable inputs:
Movement: U (up), L (left), D (down), R (right)
Actions: A (slash), J (jump), r (rope dart), S (shuriken), T (lightfoot tabi)
Menus: s (start), e (interact), b (back), c (cancel), y (confirm), i (inventory), m (map)

You can create a comment by appending a hash # to the beginning of a line, blank lines are ignored too and it's encouraged to leave a blank line between each room's inputs and put a comment above each one specifying the room ID.

The mod includes a macro for spamming inputs with one frame of waiting inbetween as syntactic sugar, specified as the following:
`(frames), +(spam count), (inputs)`
For instance, the following:
```
1, +4, R
```
Has the same effect as the following:
```
1, R
1
1, R
1
1, R
1
```

For TASing convenience the mod will force every breakable block to regenerate on screen transition so you don't have to exit and re-enter the game every time.

# Known Issues
Inputs desync by one frame every few seconds.
Inputs are blocked when playing inputs but TM.tas doesn't exist.
Inputs don't run if there's one mistake in the TAS file.
