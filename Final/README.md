# Final Project

### Tanks game

<h4>Action items:</h4>
Tasks:
Enemy tank:
	Patrol state:
		Approach environment layer in straight line, choose random turn direction
	Pursuit state:
		Hone on player up to minimun distance if raycast to player is true, shoot every "shootInterval" seconds, return to patrol state when player exits trigger<br>
		
Rigid barrier: can't be destroyed or fire through
Weak barrier: can't be fired through until destroyed
Holes: can't be destroyed but can be fired over
Floor should be matrix of square cells, to allow holes

UI: Score, HP, map (icons? birds-eye camera?)

Audio! (FMOD?)


<h4>If time allows:</h4>
Camera orbit:
	Option 1: When camera collides with environment, push linearly along its Vector relative to player
	Option 2: When camera collides with environment, push upwards to remain constant distance from player, keep looking at player (use Slerp!!!)

Landmine: Drop entity, implement coroutine to flash and detonate, use Physics.OverlapSphere to destroy all weak barriers and enemies within radius of "DetonationRadius"