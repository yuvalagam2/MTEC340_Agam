<div>
<p style = "position: absolute; right: 4%;">Yuval Agam</p>
<h1>Working with FMOD</h1>
</div>
<h3>About FMOD</h3>
FMOD is an adaptive audio plugin for Unity. It allows the user to parametrize and manipulate game audio in real time.

<h3>Installation and setup</h3>
To use FMOD in Unity, you must download FMOD studio and FMOD Unity package.

For FMOD studio, [download FMOD Studio](https://www.fmod.com/download) by selecting the most recent version from the "FMOD Studio" dropdown. Create a new project in FMOD Studio to be used with Unity, and save it anywhere outside your Unity project.

FMOD Unity should be installed from Unity's package manager. Go to [https://assetstore.unity.com/packages/tools/audio/fmod-for-unity-161631](https://assetstore.unity.com/packages/tools/audio/fmod-for-unity-161631) and click "add to my assets." In your Unity project, open Package Manager -> My Assets, then download and import FMOD for Unity. You should see the FMOD Setup Wizard open. For each of the following steps in the FMOD Setup Wizard:

* Linking: Select "FMOD Studio Project" -> select project in file system
* Listener: Select "Replace Unity Listener with FMOD Audio Listener"
* Unity Audio: Select "Disable built in audio"
* Source Control: Paste the text into your repository's gitignore file.

FMOD docs: [https://fmod.com/docs/2.03/studio/](https://fmod.com/docs/2.03/studio/)

<h3>Interaction between Unity and FMOD Studio</h3>
Unity is able to access your programmed FMOD events using the <code>EventReference</code> keyword. To implement this at the most basic level, we can program the Audio Manager (singleton class) to play a one-shot sound effect. When creating a one-shot sound, such as "coin collect," <code>EventReference</code> must be called from the namespace FMODUnity. <code>PlayOneShot()</code>, in the Audio Manager singleton class, plays the specified event once, at the specified world position.

<h3>Event Instances</h3>
Events instances are used for more advanced logic than event references. When looping audio, event instances lend themselves to extended routines since they have a stored playback state that can be programatically changed. In this example, I have used an event instance to shuffle several "step" audio clips when the player moves along the ground. To implement this, you can ue <code>getPlaybackState()</code> to get the state of an event instance, and ue <code>start()</code> and <code>stop()</code> to change its <code>PLAYBACK_STATE</code> variable.

<h3>Event Emitters</h3>
Event emitters can be used for distance-dependent events. They can be added to game objects as components from the Unity inspector. In this example, I used it to play ambience when the player approaches a coin. The previous two examples are implemented with the assumption that the game object in the Studio Listener component of the main camera is set to the player. For this implementation, the emitter is played with <code>play()</code>, and gets louder the closer the attentuation object gets. When the coin is collected, the emitter is programatically stopped with <code>stop()</code>.

<br><br><br>
Sources:<br>
https://www.youtube.com/watch?v=rcBHIOjZDpk<br>
https://fmod.com/docs/2.03/studio/

