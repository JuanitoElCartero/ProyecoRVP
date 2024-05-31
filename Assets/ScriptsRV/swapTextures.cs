using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapTextures : MonoBehaviour
{
    public Texture[] textures;
    private int currentTextureIndex = 0;

    // Método público para cambiar la textura
    public void ChangeTexture()
    {
        currentTextureIndex++;
        currentTextureIndex %= textures.Length;
        GetComponent<Renderer>().material.mainTexture = textures[currentTextureIndex];
    }
}
