# AR Walk

_Unity Engine version_:  2020.3.16f1 <br/>
_Mixed Reality Toolkit version_: 2.7.2.0 <br/>
_Photon API version_: 2.39 <br/>
_Device tested_:  Microsoft HoloLens 2 <br/>
_Tested on platforms_:  Universal Windows Platform (UWP)

# Introduction

This prototype has been developed as part of [Next level Sports](https://hci.w-hs.de/research/projects/nextlevelsports/) project. The goal of this prototype is to develop  a shared location-independent walk in Augmented Reality (AR) using Microsoft HoloLens 2 Mixed-Reality glasses. The aim is to make it possible to walk with other people despite distance or health restrictions and to motivate the users to exercise more. The project is intended to promote creativity and movement at the same time. Especially due to the pandemic and related circumstances such as home office, many people do not move enough, but they can integrate the project into their daily work routine instead of video conferences with colleagues at their desks. 

## Features

The users can walk and talk with their partner despite the physical distance. Following are some of the features implemented:

- Voice transmission: This is done via Photon Unity Networking Voice API.
- Avatar appearance: The partner avatar is visible to the walker on the side and does not have legs. Selection of male, female and neutral avatar is provided.
- Avatar position & rotation: The avatar is positioned to the walker's field of view on the side even when the views are different. The head rotation is synced according to the walker's head movement.
- Walking speed: Avatar walks at the same speed as the walker. For example, if the walker stops at a traffic light, the avatar is also stopped, even though the partner may still be walking at the moment.
- Collision detection: Obstacles such as vehicles or trees are recognized in good time by the HoloLens. When a collision of the avatar with an object occurs, the colliding body parts of the avatar is made transparent temporarily and thereby hidden. It also shows a warning triangle.

## Photon Unity Networking API

The PUN settings are shown below. In case, the project does not compile and give library errors, the PUN 2 - Free package can be downloaded from **Windows -> Package Manager**. Moreover, the PUN App ID and Voice ID can also be changed accordingly after creating the account on https://www.photonengine.com/

The application has used following PUN Server settings.

![image](https://user-images.githubusercontent.com/104509917/172372675-fa0cc6f9-6d54-45c1-b242-89be3026495c.png)

# Build configuration

The project has been built for UWP platform and tested on Microsoft HoloLens 2. The configuration is given below.

![image](https://user-images.githubusercontent.com/104509917/172388872-929c05fe-9947-4ec5-84bc-9e32a2b7ce8e.png)

# Credits

### Assets: <br/>
Avatar: Make Human, Mixamo <br/>
Avatar editing: Blender <br/>
PUN API (Unity Asset Store): https://assetstore.unity.com/packages/tools/network/pun-2-free-119922#description <br/>

To compile the project successfully, simply clone the git repository. It includes both PUN and MRTK libraries.

### Developers: <br/>

Tim Jahre, Katrin Knoke <br/>




