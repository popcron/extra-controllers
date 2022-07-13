# Extra Controllers
This is a package that adds support for the following controllers via Unity's Input System:
- GameCube
- HORIPAD for Nintendo Switch

# Requirements
- Git
- Input System 1.3.0

# Installation
Then add the following line to your `manifest.json` file or use the + in Unity's package manager with the following URL:
```json
"com.popcron.extra-controllers": "https://github.com/popcron/extra-controllers.git"
```

### Adapters
If youre using an adapter that allows for 4 controllers to be plugged in, the system will register 4 controllers even if you have only 1 plugged in.
