# **Geospatial Augmented Reality Based Game**

## **Table of Contents**

1. Introduction
2. Project Description
3. Key Features
4. Technologies Used
5. Installation
6. How to Play
7. Contributors

**Introduction**

The project is an implementation of GeoAR in Unity and is intended for submission in the Takneek’24 Problem statement “GeoMatrix”. This project is intended for Android devices only.

**Project Description**

The GeoAR implemented game makes use of the player's location accessed via GPS along with the visual data accessed through the camera to accurately place game elements and/or objects at the exact geographic location intended. Lightship’s World Positioning System (WPS) and Visual Positioning System (VPS) are utilized to make GeoAR experience possible.

Game mechanics is a basic implementation of shooting mechanics, through which the player can interact with the objects. No additional mechanics of reloading ammos, etc is implemented. To tackle the problem of object tunneling, 3d raycast was used instead to execute the mechanics in place of spawning a projectile object.

**Key Features**

- Geospatial AR implementation: making the game accessible to certain specific locations only
- Shooting Mechanics: interaction with game objects using a camera-attached Gun
- Randomized spawning: Enemies/targets are spawned in the location randomly, this is implemented using 4 different waves of attacks one after another
- Health System: A simple Health system for player is also incorporated

**Technologies Used**

- AR Foundation: Unity package to implement Augmented reality features
- Niantic Lightship’s ARDK package: to implement Geospatial AR
- Niantic Wayfarer App: to make the campus location VPS activated
- Blender for making enemy assets
- Photoshop for User Interface elements
- Unity Asset store for importing the gun asset

**Installations**

To execute the source code of this project on your device, some additional package installations are needed:

- Installation of xr-simulator environment (v-1.0.0): This can be installed from the tarball available in [this link](https://github.com/Unity-Technologies/com.unity.xr-content.xr-sim-environments/releases)

**How to Play**

- Location: Make sure you are present at one of the locations specified in the instruction section of the game menu
- Aiming: Move your mobile device to aim at specific points in your surroundings. The game uses your device's camera to integrate with the real world, so look around and find your targets.
- Shooting: Once you've aimed at your target, tap on the screen to shoot. Be quick and accurate!

**Contributors**

1. A
2. A
3. A
4. A
5. A
6. A
