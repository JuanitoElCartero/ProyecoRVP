using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRTextureChanger : MonoBehaviour
{
    public XRRayInteractor rightHandRay;
    public XRRayInteractor leftHandRay; // Si quieres incluir la mano izquierda

    private swapTextures hoveredSwapTexture;

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
        if (hoveredSwapTexture != null && Input.GetKeyDown(KeyCode.Alpha0))
        {
            hoveredSwapTexture.ChangeTexture();
        }
    }
}
