using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Sprite3DRender : MonoBehaviour
{
    public Texture text;

    [SerializeField] private Material material;

    void Update()
    {
        if(text != material.mainTexture)
        {
            material.mainTexture = text;

        }

    }
}
