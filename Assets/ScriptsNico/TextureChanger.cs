using UnityEngine;
using UnityEngine.UI;

public class TextureChanger : MonoBehaviour
{
    public Renderer targetRenderer; // El renderer del objeto al que quieres cambiar la textura

    public void ChangeTexture(Texture newTexture)
    {
        if (targetRenderer != null)
        {
            targetRenderer.material.mainTexture = newTexture;
        }
    }
}
