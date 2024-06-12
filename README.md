# For Base Game
## To play the game
1. Pull the master branch from Github repos.
2. Click on final/base/SlayTheHaunted.exe to play the game.
## To load the scene and compile the game
1. Load Assets/main in Unity Editor.
2. Change the resolution in the Game tab to Full HD.
3. Click the Play button.
## To build the game
1. Click File -> Build Settings.
2. Click Add Open Scenes.
3. Click build and select a folder to store the built version (The game is already built in final/base folder) 

# For AR
## To play the game
1. Pull the master branch from Github repos.
2. Click on final/ar/SlayTheHaunted.exe to play the game.
## To load the scene and compile the game
1. Download add-vuforia-package-10-21-3.unitypackage from this [link](https://drive.google.com/file/d/1xro_znx7eAz-oLPXoFT72fhturNsg5h0/view?fbclid=IwZXh0bgNhZW0CMTAAAR18zM9d-KeNK9w6tLaiXV1PCOPgaSTBgMc3HwfXYmZVekTakL9KxYg6oi8_aem_AZWl9ugoPTuRz4hp0ix0T8196qQF4o2998Uryy0-1tfxBrp4FEXD6T00aOYlQvi8sxeacS_rGlc-TI0SvIMKd6zs)
2. Drag the downloaded file to the Unity Editor and import the files.
3. Copy Assets\Editor\Migration\com.ptc.vuforia.engine-10.21.3.tgz to Packages
4. Open Library\PackageCache\com.ptc.vuforia.engine@54106664636f-1706680995000\Vuforia\Scripts\DefaultObserverEventHandler.cs
5. Go to lines 42 and 43, change "new();" to "new UnityEvent();"
6. Open Library\PackageCache\com.ptc.vuforia.engine@54106664636f-1706680995000\Vuforia\Scripts\Internal\RuntimeOpenSourceInitializer.cs
7. Go to lines 148, remove the line "notOccludingCameraData.allowHDROutput = mainCameraData.allowHDROutput;" 
8. Change the Game tab to Simulator tab.
9. Connect your phone to Unity via Droid Cam
10. Enter your Vuforia key in ARCamera -> Open Vuforia Engine Configuration -> App License Key.
11. Click the Play button.
## To build the game
1. Click File -> Build Settings.
2. Click Add Open Scenes.
3. Click build and select a folder to store the built version (The game is already built in final/ar folder) 