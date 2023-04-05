using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector2 targetPos;
    public float xIncrement;
    public float yIncrement;
    public float speed;


    public float maxWidth;
    public float minWidth;
    public float maxHeight;
    public float minHeight;

    void Update()
    {
        
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && transform.position.x < maxWidth)
        {
            targetPos = new Vector2(transform.position.x + xIncrement, transform.position.y);
            
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && transform.position.x > minWidth)
        {
            targetPos = new Vector2(transform.position.x - xIncrement, transform.position.y);
            
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);

        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);

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

        Debug.Log("targetPos.x: " + targetPos.x + "   targetPos.y: " + targetPos.y);
    }
}
