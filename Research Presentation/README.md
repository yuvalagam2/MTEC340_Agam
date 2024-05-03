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

FMOD docs: [https://fmod.com/docs/2.03/studio/welcome-to-fmod-studio.html](https://fmod.com/docs/2.03/studio/welcome-to-fmod-studio.html)

<h3>Interaction between Unity and FMOD Studio</h3>
Unity is able to access your programmed FMOD events using the <code>EventReference</code> keyword. To implement this at the most basic level, we can program the Audio Manager (singleton class) to play a one-shot sound effect. When creating a one-shot sound, such as "coin collect," <code>EventReference</code> must be called from the namespace FMODUnity. <code>PlayOneShot()</code>, in the Audio Manager singleton class, plays the specified event once, at the specified world position.

<h3>Event Instances</h3>


<br><br><br>
Sources:<br>
https://www.youtube.com/watch?v=rcBHIOjZDpk<br>
https://fmod.com/docs/2.03/studio/welcome-to-fmod-studio.html

