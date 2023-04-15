using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;

    public float speed;

    public GameObject effect;

    public Shake shake;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y <= -3)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            shake.CamShake();
            if (!other.GetComponent<Player>().getIsInvinvible())
            {
                //player takes damage
                other.GetComponent<Player>().health -= damage;
                Debug.Log(other.GetComponent<Player>().health);
                
            }
            Destroy(gameObject);
        }

        if (other.CompareTag("Projectile"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            shake.CamShake();
            Destroy(gameObject);
        }
    }

}
