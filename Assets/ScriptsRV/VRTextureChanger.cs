using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRTextureChanger : MonoBehaviour
{
    public XRRayInteractor rightHandRay;
    public XRRayInteractor leftHandRay; // Si quieres incluir la mano izquierda
    public InputActionProperty pressAnimationAction; // Acción del gatillo
    public AudioSource audioSource; // AudioSource que se activará

    private swapTextures hoveredSwapTexture;
    private bool canPressTrigger = true; // Control para limitar la presión del gatillo
    private float pressCooldown = 1f; // Tiempo de espera entre presiones

    void OnEnable()
    {
        rightHandRay.hoverEntered.AddListener(OnHoverEntered);
        rightHandRay.hoverExited.AddListener(OnHoverExited);
        leftHandRay.hoverEntered.AddListener(OnHoverEntered);
        leftHandRay.hoverExited.AddListener(OnHoverExited);

        pressAnimationAction.action.Enable();
    }

    void OnDisable()
    {
        rightHandRay.hoverEntered.RemoveListener(OnHoverEntered);
        rightHandRay.hoverExited.RemoveListener(OnHoverExited);
        leftHandRay.hoverEntered.RemoveListener(OnHoverEntered);
        leftHandRay.hoverExited.RemoveListener(OnHoverExited);

        pressAnimationAction.action.Disable();
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        var swapTexture = args.interactableObject.transform.GetComponent<swapTextures>();
        if (swapTexture != null)
        {
            hoveredSwapTexture = swapTexture;
        }
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        var swapTexture = args.interactableObject.transform.GetComponent<swapTextures>();
        if (swapTexture == hoveredSwapTexture)
        {
            hoveredSwapTexture = null;
        }
    }

    void Update()
    {
        float triggerValue = pressAnimationAction.action.ReadValue<float>();

        // Detectar si el gatillo está presionado (valor float 1.0) y si se puede presionar nuevamente
        if (hoveredSwapTexture != null && triggerValue > 0.5f && canPressTrigger) // Ajusta el umbral según sea necesario
        {
            hoveredSwapTexture.ChangeTexture();
            Debug.Log("Trigger pressed");

            // Reproducir el sonido
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Iniciar cooldown
            StartCoroutine(TriggerCooldown());
        }
    }

    private IEnumerator TriggerCooldown()
    {
        canPressTrigger = false;
        yield return new WaitForSeconds(pressCooldown);
        canPressTrigger = true;
    }
}

