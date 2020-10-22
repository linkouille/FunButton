using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Sprite3DRender : MonoBehaviour
{
    public Texture text;

    void Update()
    {
        if(text != GetComponent<Renderer>().material.mainTexture)
            GetComponent<Renderer>().material.mainTexture = text;
    }
}
