using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace SojaExiles
{
    public class OvenFlip : MonoBehaviour
    {
        public Animator openandcloseoven;
        public bool open;
        public XRController controller; // Referencia al controlador de VR

        void Start()
        {
            open = false;
        }

        void Update()
        {
            CheckForInput();
        }

        void CheckForInput()
        {
            if (controller)
            {
                // Detectar si el botón de agarre se ha presionado
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool isPressed) && isPressed)
                {
                    float dist = Vector3.Distance(controller.transform.position, transform.position);
                    if (dist < 15)
                    {
                        if (open == false)
                        {
                            StartCoroutine(opening());
                        }
                        else
                        {
                            StartCoroutine(closing());
                        }
                    }
                }
            }
        }

        IEnumerator opening()
        {
            print("you are opening the Oven");
            openandcloseoven.Play("OpenOven");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print("you are closing the Oven");
            openandcloseoven.Play("ClosingOven");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}
