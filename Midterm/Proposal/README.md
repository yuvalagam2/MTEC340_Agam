# Midterm Project Proposal

For my midterm project, I am aiming to create a brick-breaker style game. At its core, it is conceptually similar to the game Pong, which has a user-operated paddle and a ball that collides and bounces with the scene elements. A new game object `Brick` would be implemented. The prototype of this game could play through 2 to 3 different levels. In later level(s), variety could be introduced by increasing ball speed, collecting power-ups, and having bricks that require more than one hit to be eliminated.

<p>Outcomes:</p>
* Good– create one level that works from start to finish. Ball changes direction upon collision with paddle, walls, or bricks. Ball rebounds from paddle at a more horizontal angle, depending on how far from the center of the paddle the collision takes place. Paddle operated by L/R arrow keys. Implement basic state machine that ends the game after all lives are lost, or once all bricks are broken.
* Better– Multiple levels. Introduce "tough" bricks that require 2 or 3 hits to break. Mouse functionality for paddle operation.
* Best– Introduce power-ups (e.g. bigger/smaller paddle, bottom safety net, multiply balls, vertical projectiles).

<div style = "border-style: solid; border-color: #000000; border-width: 1px; padding: 0px 8px">
<h3>Gameplay</h3>
<p>A simpler brick breaker game, in which the player must use the ball the destroy the bricks, while preventing the ball from falling to the bottom.</p>
<h3>Interface</h3>
<p>Control scheme will use the L/R arrow keys to move the paddle. If implemented, space bar will be used to fire projectiles. Collection of power-up objects works off of collision with the paddle, and deterioration/destruction of bricks will work off of collision with the ball.</p>
<h3>Art Style</h3>
<p>Will use Unity's 2D primitives, i.e. circles, rectangles. Will use sprites if time allows.</p>
</div>
