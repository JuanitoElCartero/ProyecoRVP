using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lightswitchsala: MonoBehaviour
{
    public List<Light> lightsToControl; // Lista de luces que se controlar�n
    private bool lightsOn = true;

    void Start()
    {
        // Aseg�rate de que las luces est�n encendidas al inicio
        SetLights(true);

        // A�ade un listener para el evento de interacci�n
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

