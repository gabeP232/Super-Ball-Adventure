# Super-Ball-Adventure
 
Super Ball Adventure is a Casual Platforming and Puzzle game inspired by Super Monkey Ball and The Rise of Fox Hero.
The player's goal is to reach the end of the level while collecting coins, dodging traps, and solving puzzles. 
The following explains the technical requirements we used in our game:
* **Audio** - In our project, we used an audio asset pack called **8-bit Platformer Music**; each level (title screen, level 1, level 2) has a different soundtrack from this asset pack.
In our levels, we used audio reverb zones when needed and added a volume controller in the settings UI that is persistent between scenes. We also added sounds to collectibles such as coin pick-ups.
* **VFX** - Some cases where we used VFX include when the player breaks boxes, picks up coins, or dies. Each element has a different particle and FX.
* **UI** - We used a complete UI settings interface that saves player preferences throughout entire scenes. We also implemented UI for Win and Death conditions.
The Settings UI consists of level switching, the ability to change the material of the player, and volume control. The Win UI appears when the player collects enough coins and finishes the level,
prompting them to either go to the next level or return to the title screen. The death UI prompts the player to try again and resets the scene. We also used an asset called **Thaleah Pixel Font**
for fonts and button PNGs.
* **Animations** - For our animations, we animated our coin prefabs, our various traps, and occasional puzzles/platforms that the player interacts with. We used traps from an asset pack called
**Poly Style - Platformer Starter Pack**. We were able to animate various spinning traps as well as moving platforms that the player interacts with.
We also implemented an AI enemy that rolls towards the player when they are in a certain area, and any contact with the enemy kills the player.
* **Shaders and Materials** - From the Poly Style - Platformer Starter Pack we mentioned previously, we used their platforms, decorations, and trap materials to build out much of the environment and puzzles of each level.
We were also able to create our own materials for things like changing different player skins.
* **Lighting** - For our project, we used real-time lighting. In our levels, we used a skybox material from the Poly Style asset pack to create much of the lighting we wanted.
In our second level, we adjusted the environmental lighting and added fog to mimic a nighttime level.
 

 
