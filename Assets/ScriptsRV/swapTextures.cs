using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapTextures : MonoBehaviour
{
    public Texture[] textures;
    public int currentTextures;
    public GameObject HairSSj2;

    // Start is called before the first frame update
    void Start()
    {
        // Aqu� puedes agregar cualquier inicializaci�n necesaria
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            currentTextures++;
            currentTextures %= textures.Length;
            GetComponent<Renderer>().material.mainTexture = textures[currentTextures];
        }
    }
}
