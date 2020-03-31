# GameCube Controller
Wanna add support for GameCube controllers to your unity game? Here you go then.

# Requirements
- Git

# Installation
First, ensure that you have the drivers installed for GC controllers (explained [here](https://wiki.dolphin-emu.org/index.php?title=How_to_use_the_Official_GameCube_Controller_Adapter_for_Wii_U_in_Dolphin#Windows)).

Then add the following line to your `manifest.json` file:
```json
"com.popcron.inputdevices.gamecube": "https://github.com/popcron/gameCubeController.git"
```

# Controls
| Name | Path | Description |
| --- | --- | --- |
| leftStick | `/joystick` | This is the generic joystick that is on the left side |
| rightStick | `/cStick` | This is the C-Stick that is situated on the right side |
| leftTrigger | `/leftTrigger` | Left trigger |
| rightTrigger | `/rightTrigger` | Right trigger |
| leftButton | `/leftButton` | The button that at the end of the left trigger |
| rightButton | `/rightButton` | The button that at the end of the right trigger |
| dpad | `/dpad` | Duh |
| aButton | `/aButton` | The big green A button |
| bButton | `/bButton` | The tiny red B button under the A button |
| xButton | `/xButton` | The small X button on the right of the A button |
| yButton | `/yButton` | The tiny Y button above the A button |
| zButton | `/zButton` | The purple Z button |
| startButton | `/startButton` | The button in the middle of the controller |
| selectButton | `/selectButton` | Same as above |

Every other control that is inherited from the `Gamepad` class, such as the dual shock buttons and stick buttons are marked as obsolete and the IDE will yell at you for using them, because these controls don't exist on the GameCube controller.

# Notes
### Deadzones
The left and right triggers are a value that is a range from about 0.18 to 0.8, they are never zero if the controller is *real*. On both sticks which might have some drift, a healthy dead-zone is about 0.21

### Adapters
If youre using an adapter that allows for 4 controllers to be plugged in, the system will register 4 controllers even if you have only 1 plugged in. To work around this, you can check if the controller is real or not by using the `isReal` variable on the device. The check is done by checking if either left or right triggers have a value greater than 0.01. It works because the triggers can never be this low unless the controller has no signal and thus, isnt connected.
