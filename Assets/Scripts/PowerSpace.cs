using System.Collections;
using UnityEngine;

public class PowerSpace : MonoBehaviour
{
    private float remainingTimer;
    public float timerDuration = 1f;

    public GameObject teleportEffect;
    public GameObject spawnEffect;

    private void Start()
    {
        remainingTimer = timerDuration; 
    }

    public void UsePower()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GameObject effect = Instantiate(teleportEffect,GetComponent<Transform>().position,Quaternion.identity);
        Destroy(effect,0.3f);
        if (transform.localScale.x == 1)
        {
            transform.position += new Vector3(8f, 0f, 0f);
        }
        else
        {
            transform.position -= new Vector3(8f, 0f, 0f);
        }
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (remainingTimer > 0f)
        {
            remainingTimer -= Time.deltaTime;
            Debug.Log("Time remaining: " + remainingTimer);
            yield return null;
        }
        remainingTimer = timerDuration;
        GetComponent<SpriteRenderer>().enabled = true;
        GameObject effect = Instantiate(spawnEffect, GetComponent<Transform>().position, Quaternion.identity);
        Destroy(effect, 0.6f);
    }
}
