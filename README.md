# Master's Thesis on Code Entry in Virtual Reality
The thesis consisted of the re-implementation of several VR text entry systems from the literature and a user study on the intuitiveness and learnability of the text entry systems in a custom tesing environment. 

Testing Environment runs in the [TLabWebViewVR Browser](https://github.com/TLabAltoh/TLabWebViewVR). It can be moved using the [MoveAndScale.cs](https://github.com/NormalVR/CutieKeys/blob/master/Assets/Keyboard/Scripts/MoveAndScale.cs) by [NormalVR/CutieKeys](https://github.com/NormalVR/CutieKeys/tree/master). Cube Keyboard Scripts are heavily based on Drum Keyboard by by [NormalVR/CutieKeys](https://github.com/NormalVR/CutieKeys/tree/master) as well. 
Main Scene is in: Assets/TLab/TLabWebViewVR/MetaXR/Samples/Scenes/MetaXR Sample.unity

--- Original README ---
# TLabWebViewVR

[日本語版READMEはこちら](README-ja.md)

Sample project for using [```TLabWebView```](https://github.com/TLabAltoh/TLabWebView) in OculusQuest. Includes [```Meta XR SDK```](https://developers.meta.com/horizon/downloads/package/meta-xr-sdk-all-in-one-upm) and [```XR Interaction Toolkit```](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@3.0/manual/index.html) implementation example.

[Document is here](https://tlabgames.gitbook.io/tlabwebview)  
[Snippets is here](https://gist.github.com/TLabAltoh/e0512b3367c25d3e1ec28ddbe95da497#file-tlabwebview-snippets-md)  

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/tlabaltoh)

## Screenshot  
[Watch on Youtube](https://youtu.be/q3swlSP1mRg)  
![output](Media/tlab-webview-vr.gif)

## Operating Environment
|         |                     |
| ------- | ------------------- |
| Headset | Oculus Quest 2      |
| GPU     | Qualcomm Adreno 650 |
| Unity   | 2021.37f1           |

## Getting Started
### Prerequisites
- Unity 2021.26f1 (meta xr sdk requires Unity Editor 2021.26f1 ~)
- [meta-xr-all-in-one-sdk](https://assetstore.unity.com/packages/tools/integration/meta-xr-all-in-one-sdk-269657?locale=ja-JP)
- [com.unity.xr.interaction.toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@3.0/manual/index.html)
- [TLabVKeyborad](https://github.com/TLabAltoh/TLabVKeyborad)
- [TLabWebView](https://github.com/TLabAltoh/TLabWebView)

### Installing
- Clone the repository with the following command
```
git clone https://github.com/TLabAltoh/TLabWebViewVR.git

cd TLabWebViewVR

git submodule update --init
```

### Set Up
Please see the setup section [here](https://github.com/TLabAltoh/TLabWebView)

### Sample Scene

#### Meta XR SDK
```Assets/TLab/TLabWebViewVR/MetaXR/Samples/Scenes/MetaXR Sample.unity```

#### XR Interaction Toolkit
```Assets/TLab/TLabWebViewVR/XRInteractionToolkit/Samples/Scenes/XRInteractionToolkit Sample.unity```


## Sample Repository for Unity 2022
- [Oculus Integration Sample](https://github.com/TLabAltoh/TLabWebViewVR-OculusIntegration-2022)
- [XR Interaction Toolkit Sample (VR Template)](https://github.com/TLabAltoh/TLabWebViewVR-XRInteractionToolkit-2022)
