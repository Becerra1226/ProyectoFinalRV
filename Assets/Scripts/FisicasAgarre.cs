using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FisicasAgarre : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Transform originalParent;
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        originalParent = transform.parent;
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnRelease(XRBaseInteractor interactable)
    {
        if(originalParent != null)
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
        else
        {
            Debug.LogWarning("El objeto no tiene un padre original");
        }
    }
}
