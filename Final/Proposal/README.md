#Final Project Proposal

My goal for my MTEC-340 final project is to implement a game inspired by the "Tanks" minigame from Wii Play. In this game, the player controls a tank that shoots projectiles to destroy AI-based enemy tanks. Some power-ups will be available in the game which, for example increase the speed of the tank, or the speed/damage stat of the projectiles. The next level is loaded once all the tanks in the current level are destroyed. A metric for lives and for score are displayed in the UI throughout each level.

The environment from level to level will contain <code>Wall</code> type barriers which are rigid and cannot be driven or fired over. In addition, there will be <code>Pothole</code> types, which can be shot over but not driven over, as well as <code>BrittleWall</code> types, which cannot be driven through, but are destroyed when they are shot at. Additional game objects will include <code>Floor</code>, <code>Tank</code> prefab + prefab variants, <code>Projectile</code> prefab + prefab variants, and <code>Landmine</code>.

Outcomes:

- Good- At least 1 level is built and functional, with minimal barriers. Player tank is implemented and functional. At least one enemy tank prefab is fully implemented, and correctly uses a NavMeshAgent to navigate the environment.
- Better- All barrier types are properly implemented, and used across multiple levels for variation. Player tank can drop landmines, which run on a timer and affects anything within a certain radius. Multiple enemy tank types exist, with variations in speed and projectile speed. A shield power up, dropped by chance upon destroying an enemy tank, grants temporary invisibility to the player.
- Best- Simple particle systems are used to give life and animation to interactions between game objects. 

<div style = "border-style: solid; border-color: #000000; border-width: 1px; padding: 0px 8px">
<h3 style = "padding-top: 4px; margin-top: 0">Gameplay</h3>
<p>A game in which the player controls a tank and attempts to clear as many levels as possible by killing all enemy tanks. </p>
<h3>Interface</h3>
<p>Control scheme will use the keyboard and mouse to manipulate the camera, move the player, and fire projectiles (i.e. mouse L/R to pan camera, left click to fire projectiles, WASD to move the tank, space to drop landmine, P to pause).</p>
<h3>Art Style</h3>
<p>Will use Unity's 3D primitives. May incorporate more complex materials/animation if time allows.</p>
</div>
