# For Base Game

# For AR
1. Pull the ar-beta branch from Github repos.
2. Download add-vuforia-package-10-21-3.unitypackage from this link: [<link>](https://drive.google.com/file/d/1xro_znx7eAz-oLPXoFT72fhturNsg5h0/view?fbclid=IwZXh0bgNhZW0CMTAAAR18zM9d-KeNK9w6tLaiXV1PCOPgaSTBgMc3HwfXYmZVekTakL9KxYg6oi8_aem_AZWl9ugoPTuRz4hp0ix0T8196qQF4o2998Uryy0-1tfxBrp4FEXD6T00aOYlQvi8sxeacS_rGlc-TI0SvIMKd6zs)
3. Drag the downloaded file to the Unity Editor and import the files.
4. Copy Assets\Editor\Migration\com.ptc.vuforia.engine-10.21.3.tgz to Packages
5. Open Library\PackageCache\com.ptc.vuforia.engine@54106664636f-1706680995000\Vuforia\Scripts\DefaultObserverEventHandler.cs
6. Go to lines 42 and 43, change "new();" to "new UnityEvent();"