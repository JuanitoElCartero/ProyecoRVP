using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HDMinfoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!XRSettings.isDeviceActive)
        {
            Debug.Log("El casco no esta conectado");
        }
        else if(XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD"
               || XRSettings.loadedDeviceName == "MockHMDDisplay"))
        {
            Debug.Log("Usando Mock HDM");
        }
        else
        {
            Debug.Log("Tenes los cascos  " + XRSettings.loadedDeviceName);

        }



        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
