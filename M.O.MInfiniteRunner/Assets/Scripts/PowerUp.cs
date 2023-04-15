using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField]private Player player;

    private float respawnTimer;
    [SerializeField]private float timeUntilSpawn = 12.0f;

    private bool hasSpawned = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        respawnTimer = 0.0f;
        timeUntilSpawn = Random.Range(8.0f, 20.0f);
        hasSpawned = false;
    }

    void Update()
    {
        if (!player.getIsPoweredUp())
        {
            if (!hasSpawned)
            {
                respawnTimer += Time.deltaTime;
                if (respawnTimer >= timeUntilSpawn)
                {
                    GetComponent<Renderer>().enabled = true;
                    GetComponent<BoxCollider2D>().enabled = true;
                    transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 4);
                    hasSpawned = true;
                    if (transform.position.y > 8.0f)
                    {
                        transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 4);
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.setIsPoweredUp(true);
            player.setIsInvincible(true);
            player.setTargetPos(new Vector2(player.transform.position.x, 0));
            
            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            respawnTimer = 0.0f;
            timeUntilSpawn = Random.Range(8.0f, 20.0f);
            hasSpawned = false;
        }
    }

}
