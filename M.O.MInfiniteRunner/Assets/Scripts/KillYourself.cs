using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillYourself : MonoBehaviour
{
    private float timeUntilKill;
    [SerializeField]private float objectLifetime;
    void Update()
    {
        timeUntilKill += Time.deltaTime;

        if (timeUntilKill >= objectLifetime)
        {
            Destroy(gameObject);
        }
    }
}
