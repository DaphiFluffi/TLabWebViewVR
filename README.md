# Master's Thesis on Code Entry in Virtual Reality

For my master's thesis I conducted a qualitative study to find out what an intutive and learnable text entry experience in VR should look like for programmers. As part of my thesis, I had to re-implement several VR text entry systems from the literature. The study took place in a custom coding environment displayed in an in-game web browser by TLabAtloh ([TLabWebViewVR Browser](https://github.com/TLabAltoh/TLabWebViewVR)). It can be moved using the [MoveAndScale.cs](https://github.com/NormalVR/CutieKeys/blob/master/Assets/Keyboard/Scripts/MoveAndScale.cs) by [NormalVR/CutieKeys](https://github.com/NormalVR/CutieKeys/tree/master).

Project Structure (all forked from TLabAtloh, main branch: masterarbeit):

* Main Project: This
* Keyboard Submodule: [https://github.com/DaphiFluffi/TLabVKeyborad](https://github.com/DaphiFluffi/TLabVKeyborad)
* Browser Submodule: [https://github.com/DaphiFluffi/TLabWebView](https://github.com/DaphiFluffi/TLabWebView)
* Keybindings Plugin: [https://github.com/DaphiFluffi/TLabWebViewPlugin](https://github.com/DaphiFluffi/TLabWebViewPlugin)

Materials:

* HMD: Meta Quest Pro
* Unity Version: 2022.3.48f1
* Visual Studio Version: 2022
* Main Scene: `Assets/TLab/TLabWebViewVR/MetaXR/Samples/Scenes/MetaXR Sample.unity`

## Inspector Structure

Under the unpacked Prefab `TLabWebView_MetaXR` is the `Screen` object contraining the Browser Screen and the following keyboard implementations. The Study Manager contains the Browser Navigation Button Functions.


* SimpleKeyborad = TLab's Virtual QWERTY Keyboard with layout adjustments [1]
* Drum = NormalVR's CutieKeys Drum Keyboard with layout adjustments [2]
* Eye = Eye-Shaped Keyboard re-implementation [5]
* PizzaDone = PizzaText re-implementation [3]
* Cube = Cubic Keyboard re-implementation [4]
  

<img width=20% alt="fig-inspector" src="https://github.com/user-attachments/assets/80beb541-30e0-4f28-b46e-9d97180ab708" />

Unity Inspector Structure

## Text Entry Systems

### PizzaText

<img width="236" height="236" alt="fig-pt-menu-of-pizzas" src="https://github.com/user-attachments/assets/6e7d181b-df7a-4704-92fe-227fcf2c1630" />

Menu of Pizzas for Layer Switching; Not in the Original

<img width="488" height="117" alt="fig-pt-me" src="https://github.com/user-attachments/assets/9136e0e3-ada2-4f47-96d8-26669a572121" />

PizzaText; L–R: Lowercase, Uppercase, Symbol, Control Layers

### Cubic Keyboard

* Scripts are heavily based on the Drum Keyboard by [NormalVR/CutieKeys](https://github.com/NormalVR/CutieKeys/tree/master).


<img width="328" height="164" alt="fig-ck-me" src="https://github.com/user-attachments/assets/9252c506-2f2d-4c38-85fa-2582a883a6d5" />

Cubic Keyboard;L-R:Control Char Side Panel, Main Keyboard and Text Entry Field, Shift, Layer Change and Arrow keys side panel

  <img width="200" height="100" alt="fig-ck-lowercase" src="https://github.com/user-attachments/assets/c26c7613-be79-46d3-bd6c-5c07a9e2fe72" />
  <img width="200" height="100" alt="fig-ck-uppercase" src="https://github.com/user-attachments/assets/67be694e-e415-4249-9957-305940eeddde" />
  <img width="200" height="93" alt="fig-ck-numbers" src="https://github.com/user-attachments/assets/a8fb8b14-768d-4d45-a387-b155c6d0bede" />
  <img width="200" height="93" alt="fig-ck-symbols" src="https://github.com/user-attachments/assets/6710ebfb-4b36-4ff4-b441-0d57139bb123" />

  Four Layers Dissected: Lowercase and Uppercase Letters, Two Special Character Layers


## Virtual Keyboard

<figure>
  <img width=40% alt="fig-virtual-tlab" src="https://github.com/user-attachments/assets/c9f18192-7168-4f2e-93c7-00d7c68320e0" />

  TLab's Virtual QWERTY Keyboard, added Tab and Arrow Keys, slightly different layout
</figure>

<figure>
  <img width="230" height="64" alt="vk-tlab-layout-letters" src="https://github.com/user-attachments/assets/c3d8cc8c-db07-45e3-9d0d-e9f956c69879" />
  <img width="230" height="64" alt="vk-tlab-layout-symbols" src="https://github.com/user-attachments/assets/e52f2ee6-c1dd-4bcc-883d-d3661481066e" />

  (a) Lowercase letters, (b) numbers and special chars
</figure>

## Drum Keyboard

<figure>
 <img width=50% alt="fig-env-unity" src="https://github.com/user-attachments/assets/bca5b7a8-3592-4c22-92b0-c0d2afb8a68b" />

  Modified Drum Keyboard Layout
</figure>

## Eye-Shaped Keyboard

<figure>
  <img width=30% alt="modified-eye-keyboard" src="https://github.com/user-attachments/assets/13bd8543-1898-4ded-b090-7ba49c68df4e" />

  Modified Eye-Shaped Keyboard Layout
</figure>

## Custom Study Testing Environment Displayed in Browser with added Navigation Buttons

<figure>
  <img width=40% alt="fig-env-unity" src="https://github.com/user-attachments/assets/ba0aa3f6-9224-4aed-8da1-4c17c1971269" />
  <img width=38% alt="fig-browser-unity-buttons" src="https://github.com/user-attachments/assets/58e9f6d8-0a34-4833-9678-8ee7c128a7e5" />
  
  TLab's Browser with added navigaton bar displaying our custom coding env
</figure>

## Sources

* [1] TLabAtloh: TLabWebViewVR. [https://github.com/TLabAltoh/TLabWebViewVR](https://github.com/TLabAltoh/TLabWebViewVR)
* [2] NormalVR: CutieKeys. [https://github.com/NormalVR/CutieKeys](https://github.com/NormalVR/CutieKeys)
* [3] D. Yu, K. Fan, H. Zhang, D. Monteiro, W. Xu, and H. -N. Liang. “Pizza-Text: Text Entry for Virtual Reality Systems Using Dual Thumbsticks”. In: *IEEE Transactions on Visualization and Computer Graphics* 24.11 (Nov. 2018), pages 2927–2935. issn: 1941-0506. doi: 10.1109/TVCG.2018.2868581.
* [4] N. Yanagihara and B. Shizuki. “Cubic Keyboard for Virtual Reality”. In: *Proceedings of the 2018 ACM Symposium on Spatial User Interaction*. SUI ’18. New York, NY, USA: Association for Computing Machinery, Oct. 2018, page 170. isbn: 978-1-4503-5708-1. doi: 10.1145/3267782.3274687.
* [5] K. Wang, Y. Yan, H. Zhang, X. Liu, and L. Wang. “Eye-Shaped Keyboard for Dual-Hand Text Entry in Virtual Reality.” In: *Virtual Reality & Intelligent Hardware*, vol. 5, no. 5, Oct. 2023, pp. 451–469. issn: 2096-5796. doi: 10.1016/j.vrih.2023.07.001.

## Legal Disclaimer

This repository contains the implementation developed as part of my Master's thesis.

The work is based on a fork of TLabWebViewVR by TLabAtloh, available at: [https://github.com/TLabAltoh/TLabWebViewVR](https://github.com/TLabAltoh/TLabWebViewVR). Significant modifications and additions have been made to support the research described in the thesis.

Please note:

- This repository reflects only the implementation part of the thesis and may not represent the full scope of the academic work.
- All original work is © Daphna Beljavskij, 2025.
- The code and materials are shared for academic and non-commercial use only, unless otherwise specified in the license.
- The original project is licensed under the MIT license, and this fork complies with that license. See [LICENSE](LICENSE) for more details.

If you use this code or refer to this project in your own work, please contact me to cite the original project and my thesis appropriately.

# Original README TLabWebViewVR

[日本語版READMEはこちら](README-ja.md)

Sample project for using [``TLabWebView``](https://github.com/TLabAltoh/TLabWebView) in OculusQuest. Includes [``Meta XR SDK``](https://developers.meta.com/horizon/downloads/package/meta-xr-sdk-all-in-one-upm) and [``XR Interaction Toolkit``](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@3.0/manual/index.html) implementation example.

[Document is here](https://tlabgames.gitbook.io/tlabwebview)

[Snippets is here](https://gist.github.com/TLabAltoh/e0512b3367c25d3e1ec28ddbe95da497#file-tlabwebview-snippets-md)

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

``Assets/TLab/TLabWebViewVR/MetaXR/Samples/Scenes/MetaXR Sample.unity``

#### XR Interaction Toolkit

``Assets/TLab/TLabWebViewVR/XRInteractionToolkit/Samples/Scenes/XRInteractionToolkit Sample.unity``

## Sample Repository for Unity 2022

- [Oculus Integration Sample](https://github.com/TLabAltoh/TLabWebViewVR-OculusIntegration-2022)
- [XR Interaction Toolkit Sample (VR Template)](https://github.com/TLabAltoh/TLabWebViewVR-XRInteractionToolkit-2022)

