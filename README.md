# Input System Controller
This is a package that adds support for the following controllers:
- GameCube (through zadig on Windows)
- HORIPAD for Nintendo Switch (Windows)

# Requirements
- Git
- Unity's Input System package

# Installation
Then add the following line to your `manifest.json` file or use the + in Unity's package manager with the following URL:
```json
"com.popcron.input-system-controllers": "https://github.com/popcron/input-system-controllers.git"
```

# GameCube Controllers
First, ensure that you have the drivers installed for GC controllers (explained [here](https://wiki.dolphin-emu.org/index.php?title=How_to_use_the_Official_GameCube_Controller_Adapter_for_Wii_U_in_Dolphin#Windows)).

### Trigger Deadzones
The left and right triggers are a value that is a range from about 0.18 to 0.8, they are never zero if the controller is *real*. On both sticks which might have some drift, a healthy dead-zone is about 0.21

### Adapters
If youre using an adapter that allows for 4 controllers to be plugged in, the system will register 4 controllers even if you have only 1 plugged in. To work around this, you can check if the controller is real or not by using the `isReal` variable on the device. The check is done by checking if either left or right triggers have a value greater than 0.01. It works because the triggers can never be this low unless the controller has no signal and thus, isnt connected.
