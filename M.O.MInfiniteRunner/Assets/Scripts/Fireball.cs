using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float speed = 6;
    private float maxHeight = 10;
    
    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y >= maxHeight)
        {
            Destroy(gameObject);
        }
    }
}
