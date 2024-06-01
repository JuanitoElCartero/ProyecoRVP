using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class Lightswitchsala : MonoBehaviour
{
    public XRRayInteractor rightHandRay;
    public XRRayInteractor leftHandRay; // Si quieres incluir la mano izquierda

    public List<Light> pointLights; // Lista de luces que quieres desactivar/activar
    private bool isHovering;

    void Start()
    {
        // Aseg�rate de inicializar la lista si no lo has hecho en el inspector
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
    }

    void OnDisable()
    {
        rightHandRay.hoverEntered.RemoveListener(OnHoverEntered);
        rightHandRay.hoverExited.RemoveListener(OnHoverExited);
        leftHandRay.hoverEntered.RemoveListener(OnHoverEntered);
        leftHandRay.hoverExited.RemoveListener(OnHoverExited);
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
        // Detectar si el gatillo derecho o izquierdo est� presionado
        if (isHovering && (Input.GetButtonDown("Trigger") || Input.GetButtonDown("Trigger")))
        {
            TogglePointLights();
        }
    }

    private void TogglePointLights()
    {
        foreach (var light in pointLights)
        {
            light.gameObject.SetActive(!light.gameObject.activeSelf);
        }
    }
}
