using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class VRPointLightColorChanger : MonoBehaviour
{
    public XRRayInteractor rightHandRay;
    public XRRayInteractor leftHandRay; // Si quieres incluir la mano izquierda

    public List<Light> pointLights; // Lista de luces que quieres cambiar de color
    private bool isHovering;
    private int colorIndex = 0;
    private Color[] colors = { Color.red, Color.blue, Color.white };

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
        // Detectar si el gatillo derecho o izquierdo está presionado
        if (isHovering && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")))
        {
            ChangeLightColors();
        }
    }

    private void ChangeLightColors()
    {
        colorIndex = (colorIndex + 1) % colors.Length;

        foreach (var light in pointLights)
        {
            light.color = colors[colorIndex];
        }
    }
}
