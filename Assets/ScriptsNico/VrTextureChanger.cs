using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class VrTextureChanger : MonoBehaviour
{
    public Camera vrCamera;
    public float interactionDistance = 5.0f;
    public Canvas objectUICanvas;
    public TextMeshProUGUI objectNameText;
    public XRRayInteractor rayInteractor;

    private GameObject selectedObject;

    void Update()
    {
        // Verificar si el rayo del ray interactor intersecta con un objeto interactivo
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Interactive"))
            {
                selectedObject = hit.collider.gameObject;
                ShowUI(hit.point);
                return; // Salir temprano si se encuentra un objeto interactivo
            }
        }

        // Si no se encuentra ning�n objeto interactivo, ocultar la UI
        HideUI();
        selectedObject = null;
    }

    void ShowUI(Vector3 position)
    {
        // Desplazamiento hacia la derecha del rayo
        Vector3 offset = vrCamera.transform.right * 0.5f; // Ajusta este valor seg�n sea necesario

        // Aplica el desplazamiento a la posici�n del Canvas
        Vector3 uiPosition = position + offset;

        objectUICanvas.transform.position = uiPosition;

        // Hacer que el Canvas mire hacia la c�mara
        objectUICanvas.transform.LookAt(vrCamera.transform);

        // Ajustar la rotaci�n para que no est� al rev�s
        objectUICanvas.transform.Rotate(0, 180, 0);

        objectUICanvas.gameObject.SetActive(true);
        objectNameText.text = selectedObject.name;
    }

    void HideUI()
    {
        objectUICanvas.gameObject.SetActive(false);
    }
}

