
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class UIHapticFeedback : MonoBehaviour
{

    private XRUIInputModule InputModule => EventSystem.current.currentInputModule as XRUIInputModule;


    public void OnPointerEnter(PointerEventData eventData)
    {

        XRRayInteractor interactor = InputModule.GetInteractor(eventData.pointerId) as XRRayInteractor;

        if (!interactor) { return; }

        interactor.xrController.SendHapticImpulse(.5f, .5f);

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        XRRayInteractor interactor = InputModule.GetInteractor(eventData.pointerId) as XRRayInteractor;

        if (!interactor) { return; }

        interactor.xrController.SendHapticImpulse(.5f, .5f);

    }

}

