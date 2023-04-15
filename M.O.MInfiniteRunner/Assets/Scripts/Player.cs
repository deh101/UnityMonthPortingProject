using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Vector2 targetPos;
    public void setTargetPos(Vector2 value) { targetPos = value; }
    public float xIncrement;
    public float yIncrement;
    public float speed;


    public float maxWidth;
    public float minWidth;
    public float maxHeight;
    public float minHeight;

    public int health = 3;

    private bool hitEffectPlayed = false;
    private float deathDelayTimer = 0;
    [SerializeField]private float deathDelay;

    public GameObject hitEffect;
    public GameObject moveEffect;
    [SerializeField]private GameObject poweredUpEffect;

    private bool isPoweredUpEffectActive;


    private bool isPoweredUp = false;
    public void setIsPoweredUp(bool value) { isPoweredUp = value; }
    public bool getIsPoweredUp() { return isPoweredUp; }
    private bool isInvincible = false;
    public void setIsInvincible(bool value) { isInvincible = value; }
    public bool getIsInvinvible() { return isInvincible; }

    [SerializeField]private GameObject fireball;

    void Update()
    {
        if (health <=0)
        {
            
            if (!hitEffectPlayed)
            {
                GetComponent<Renderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                hitEffectPlayed = true;
                isPoweredUp = false;
                poweredUpEffect.SetActive(false);
            }
            if (hitEffectPlayed)
            {
                deathDelayTimer += Time.deltaTime;
            }
            if (deathDelayTimer >= deathDelay)
            {
                hitEffectPlayed = false;
                deathDelayTimer = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            //to go to a fail scene:
            //SceneManager.LoadScene("NameOfScene")
            //Where NameOfScene is the name of the scene that will be loaded
        }

        

        if (health > 0)
        {
            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && transform.position.x < maxWidth)
            {
                targetPos = new Vector2(transform.position.x + xIncrement, transform.position.y);
                Instantiate(moveEffect, transform.position, Quaternion.Euler(180, 90, 0));
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && transform.position.x > minWidth)
            {
                targetPos = new Vector2(transform.position.x - xIncrement, transform.position.y);
                Instantiate(moveEffect, transform.position, Quaternion.Euler(0, 90, 0));
            }
            else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && transform.position.y < maxHeight)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
                Instantiate(moveEffect, transform.position, Quaternion.Euler(90, 90, 0));
            }
            else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && transform.position.y > minHeight)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
                Instantiate(moveEffect, transform.position, Quaternion.Euler(270, 90, 0));
            }

            if (isPoweredUp)
            {
                if(!isPoweredUpEffectActive)
                {
                    isPoweredUpEffectActive = true;
                    
                    poweredUpEffect.SetActive(true);
                }

                
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(fireball, transform.position, Quaternion.Euler(0, 0, 180));
                    Debug.Log("is shooting a fireball");
                    isPoweredUp = false;
                    poweredUpEffect.SetActive(false);
                    isPoweredUpEffectActive = false;
                }
            }
        }

        if (targetPos.x > maxWidth)
        {
            targetPos.x = maxWidth;
        }
        else if(targetPos.x < minWidth)
        {
            targetPos.x = minWidth;
        }
        else if(targetPos.y > maxHeight)
        {
            targetPos.y = maxHeight;
        }
        else if(targetPos.y < minHeight)
        {
            targetPos.y = minHeight;
        }

        targetPos.x = Mathf.Round(targetPos.x);
        targetPos.y = Mathf.Round(targetPos.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (isInvincible && new Vector2(transform.position.x, transform.position.y) == targetPos)
        {
            isInvincible = false;
        }
    }
}
