# Asteroids

A retro-styled 8-bit space shooter developed in **Unity**. This project is an Asteroids clone that focuses on clean C# implementation, physics-based movement, and classic arcade game loops.

## 🚀 Features

* **Physics-Based Movement:** Smooth ship handling with inertia, thrust, and rotation using `Rigidbody2D`.
* **Dynamic Asteroid Splitting:** Large asteroids break into smaller fragments when hit, utilizing procedural offsets to prevent overlapping.
* **8-Bit Aesthetic:** Pixel-perfect rendering with point-filter textures and a custom square-particle starfield.
* **Audio Management:** Centralized `SoundManager` for handling overlapping SFX (lasers, explosions, hits) with optimized memory loading.
* **Interactive UI:** Heart-based health system that dynamically updates.
* **Parallax Background:** Immersive deep-space feel using a custom Particle System.

## 🛠 Tech Stack

* **Engine:** Unity 2022.3+ (LTS)
* **Scripting:** C# (Standard English naming conventions)
* **Version Control:** Git / GitHub
* **Editor:** VS Code

## 🔧 Installation & Setup

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/joaohdib/asteroids.git](https://github.com/joaohdib/asteroids.git)
    ```
2.  **Open in Unity:**
    * Open Unity Hub.
    * Click `Add` and select the cloned folder.
    * Ensure you are using the correct Unity version.
3.  **Play:**
    * Open `Assets/Scenes/Menu.unity`.
    * Press the **Play** button.

## 📜 Key Scripts

* `PlayerScript.cs`: Handles input, physics-based thrust/rotation, and shooting logic.
* `Asteroid.cs`: Manages collision detection and the recursive splitting mechanic.
* `SoundManager.cs`: Singleton pattern implementation for global audio access.
* `HealthUI.cs`: Manages the visual state of the player's life icons.

## 🕹 Controls

| Action | Key |
| :--- | :--- |
| **Thrust** | `W` or `Up Arrow` |
| **Rotate** | `A / D` or `Left / Right` |
| **Shoot** | `Space` |

---

## 👨‍💻 Author

Developed by **joaohdib**. 

---
