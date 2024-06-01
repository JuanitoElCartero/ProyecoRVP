using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOverlayManager : MonoBehaviour
{

    [SerializeField] private float distanciaOcultar = 5f;
    [SerializeField] private Camera camaraJugador;
    [SerializeField] private List<GameObject> objetosConTexto = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject objeto in objetosConTexto)
        {
            objeto.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject objeto in objetosConTexto)
        {
            float distancia = Vector3.Distance(objeto.transform.position, camaraJugador.transform.position);

            if (distancia <= distanciaOcultar)
            {
                objeto.SetActive(true);
                objeto.transform.LookAt(camaraJugador.transform.position, camaraJugador.transform.up);
            }
            else
            {
                objeto.SetActive(false);
            }
        }
    }
}