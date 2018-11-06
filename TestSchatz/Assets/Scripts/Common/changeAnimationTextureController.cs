using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAnimationTextureController : MonoBehaviour {

    private SpriteRenderer sr;

    private static int idMainTex = Shader.PropertyToID("_MainTex");
    private MaterialPropertyBlock block;

    [SerializeField]
    private Texture texture = null;
    public Texture overrideTexture
    {
        get { return texture; }
        set
        {
            texture = value;
            if (block == null)
            {
                Init();
            }
            block.SetTexture(idMainTex, texture);
        }
    }

    void Awake()
    {
        Init();
        overrideTexture = texture;
    }

    void LateUpdate()
    {
        sr.SetPropertyBlock(block);
    }

    void OnValidate()
    {
        overrideTexture = texture;
    }

    void Init()
    {
        block = new MaterialPropertyBlock();
        sr = GetComponent<SpriteRenderer>();
        sr.GetPropertyBlock(block);
    }

    void ChangeClilp() { }
}
