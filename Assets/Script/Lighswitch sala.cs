using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Lightswitchsala : MonoBehaviour
{
    public XRRayInteractor rightHandRay;
    public XRRayInteractor leftHandRay; // Si quieres incluir la mano izquierda
    public InputActionProperty triggerAction; // Acción del gatillo
    public AudioSource audioSource; // AudioSource que se activará

    public List<Light> pointLights; // Lista de luces que quieres desactivar/activar
    private bool isHovering;
    private bool canPressTrigger = true; // Control para limitar la presión del gatillo
    private float pressCooldown = 1f; // Tiempo de espera entre presiones

    void Start()
    {
        // Asegúrate de inicializar la lista si no lo has hecho en el inspector
        if (pointLights == null)
        {
            pointLights = new List<Light>();
        }
    }

    void OnEnable()
    {
        rightHandRay.hoverEntered.AddListener(OnHoverEntered);
        rightHandRay.hoverExited.AddListener(OnHoverExited);
        leftHandRay.hoverEntered.AddListener(OnHoverEntered);
        leftHandRay.hoverExited.AddListener(OnHoverExited);

        triggerAction.action.Enable();
    }

    void OnDisable()
    {
        rightHandRay.hoverEntered.RemoveListener(OnHoverEntered);
        rightHandRay.hoverExited.RemoveListener(OnHoverExited);
        leftHandRay.hoverEntered.RemoveListener(OnHoverEntered);
        leftHandRay.hoverExited.RemoveListener(OnHoverExited);

        triggerAction.action.Disable();
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        isHovering = true;
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        isHovering = false;
    }

    void Update()
    {
        float triggerValue = triggerAction.action.ReadValue<float>();

        // Detectar si el gatillo derecho o izquierdo está presionado (valor float 1.0) y si se puede presionar nuevamente
        if (isHovering && triggerValue > 0.5f && canPressTrigger) // Ajusta el umbral según sea necesario
        {
            TogglePointLights();
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

    private void TogglePointLights()
    {
        foreach (var light in pointLights)
        {
            light.gameObject.SetActive(!light.gameObject.activeSelf);
        }
    }

    private IEnumerator TriggerCooldown()
    {
        canPressTrigger = false;
        yield return new WaitForSeconds(pressCooldown);
        canPressTrigger = true;
    }
}
