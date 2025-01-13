//Made by 'MaskedMouse' at https://forum.unity.com/threads/while-hovering-over-ui-how-do-i-get-the-controller-being-used.1196866/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using UnityEngine.XR.Interaction.Toolkit.UI;

namespace GooglyEyesGames.TicTacToe
{
    public class XRHapticFeedbackComponent : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        public float hoverFeedBackForce = 0.4f;
        public float hoverDuration = 0.02f;

        public float clickFeedBackForce = 0.6f;
        public float clickDuration = 0.02f;


        private Button button;

        private XRUIInputModule GetXRInputModule() => EventSystem.current.currentInputModule as XRUIInputModule;

        /*private void Awake()
        {
            if (button == null && GetComponent<Button>() != null)
            {
                button = GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.AddListener(OnClick);
                }
            }
        }*/


        private bool TryGetXRRayInteractor(int pointerID, out UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor)
        {
            var inputModule = GetXRInputModule();
            if (inputModule == null)
            {
                rayInteractor = null;
                return false;
            }

            rayInteractor = inputModule.GetInteractor(pointerID) as UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor;
            return rayInteractor != null;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (TryGetXRRayInteractor(eventData.pointerId, out var rayInteractor))
            {
                rayInteractor.SendHapticImpulse(hoverFeedBackForce, hoverDuration);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (TryGetXRRayInteractor(eventData.pointerId, out var rayInteractor))
            {
                rayInteractor.SendHapticImpulse(clickFeedBackForce, clickDuration);
            }
        }
    }
}

