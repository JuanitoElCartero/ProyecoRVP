using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lightswitchsala: MonoBehaviour
{
    public List<Light> lightsToControl; // Lista de luces que se controlarán
    private bool lightsOn = true;

    void Start()
    {
        // Asegúrate de que las luces están encendidas al inicio
        SetLights(true);

        // Añade un listener para el evento de interacción
        GetComponent<XRGrabInteractable>().onActivate.AddListener(ToggleLights);
    }

    void ToggleLights(XRBaseInteractor interactor)
    {
        lightsOn = !lightsOn;
        SetLights(lightsOn);
    }

    void SetLights(bool state)
    {
        foreach (var light in lightsToControl)
        {
            light.enabled = state;
        }
    }
}

