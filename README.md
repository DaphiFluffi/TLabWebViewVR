# Master's Thesis on Code Entry in Virtual Reality
The thesis consisted of the re-implementation of several VR text entry systems from the literature and a user study on the intuitiveness and learnability of the text entry systems in a custom tesing environment. 

Testing Environment runs in the [TLabWebViewVR Browser](https://github.com/TLabAltoh/TLabWebViewVR). It can be moved using the [MoveAndScale.cs](https://github.com/NormalVR/CutieKeys/blob/master/Assets/Keyboard/Scripts/MoveAndScale.cs) by [NormalVR/CutieKeys](https://github.com/NormalVR/CutieKeys/tree/master). Cube Keyboard Scripts are heavily based on Drum Keyboard by by [NormalVR/CutieKeys](https://github.com/NormalVR/CutieKeys/tree/master) as well. 
Main Scene is in: Assets/TLab/TLabWebViewVR/MetaXR/Samples/Scenes/MetaXR Sample.unity

## Inspector Stucture
<img width="306" height="335" alt="fig-inspector" src="https://github.com/user-attachments/assets/80beb541-30e0-4f28-b46e-9d97180ab708" />


## Text Entry Systems

### PizzaText
<img width="471" height="471" alt="fig-pt-menu-of-pizzas" src="https://github.com/user-attachments/assets/6e7d181b-df7a-4704-92fe-227fcf2c1630" />
<img width="975" height="234" alt="fig-pt-me" src="https://github.com/user-attachments/assets/9136e0e3-ada2-4f47-96d8-26669a572121" />

### Cubic Keyboard
<img width="656" height="345" alt="fig-ck-me" src="https://github.com/user-attachments/assets/9252c506-2f2d-4c38-85fa-2582a883a6d5" />
<img width="816" height="414" alt="fig-ck-lowercase" src="https://github.com/user-attachments/assets/c26c7613-be79-46d3-bd6c-5c07a9e2fe72" />
<img width="834" height="386" alt="fig-ck-uppercase" src="https://github.com/user-attachments/assets/67be694e-e415-4249-9957-305940eeddde" />
<img width="835" height="365" alt="fig-ck-numbers" src="https://github.com/user-attachments/assets/a8fb8b14-768d-4d45-a387-b155c6d0bede" />
<img width="824" height="386" alt="fig-ck-symbols" src="https://github.com/user-attachments/assets/6710ebfb-4b36-4ff4-b441-0d57139bb123" />

## Virtual Keyboard 
very similar to TLabKeyborad, slightly different layout + added Tab and Arrow keys
<img width="1628" height="916" alt="fig-virtual-tlab" src="https://github.com/user-attachments/assets/c9f18192-7168-4f2e-93c7-00d7c68320e0" />
<img width="920" height="255" alt="vk-tlab-layout-letters" src="https://github.com/user-attachments/assets/c3d8cc8c-db07-45e3-9d0d-e9f956c69879" />
<img width="913" height="246" alt="vk-tlab-layout-symbols" src="https://github.com/user-attachments/assets/e52f2ee6-c1dd-4bcc-883d-d3661481066e" />

## Custom Study Testing Environment Displayed in Browser
<img width="1887" height="1062" alt="fig-env-unity" src="https://github.com/user-attachments/assets/ba0aa3f6-9224-4aed-8da1-4c17c1971269" />

## Added Buttons to Browser
<img width="1321" height="793" alt="fig-browser-unity-buttons" src="https://github.com/user-attachments/assets/58e9f6d8-0a34-4833-9678-8ee7c128a7e5" />

# Original README TLabWebViewVR

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
