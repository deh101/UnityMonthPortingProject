using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{

    [SerializeField]private Vector2 scrollSpeed = new Vector2(0.1f, 0.1f);
    private Renderer objectRenderer; 
    private Vector2 currentOffset = Vector2.zero; 
    
    void Start() 
    {
        objectRenderer = GetComponent<Renderer>(); 
    } 
    
    void Update() 
    { 
        currentOffset += scrollSpeed * Time.deltaTime; 
        objectRenderer.material.SetTextureOffset("_MainTex", currentOffset); 
    }

}
