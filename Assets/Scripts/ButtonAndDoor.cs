using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAndDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Transform closePos;
    [SerializeField] Transform openPos;
    [SerializeField] float lerpSpeed = 2.0f;

    private bool isOpening = false; 
    private float lerpFactor = 0.0f; 

    private void Update()
    {

        if (isOpening)
        {
            lerpFactor += Time.deltaTime * lerpSpeed;  
        }
        else
        {
            lerpFactor -= Time.deltaTime * lerpSpeed; 
        }

        lerpFactor = Mathf.Clamp01(lerpFactor);

        door.transform.position = Vector3.Lerp(closePos.position, openPos.position, lerpFactor);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ice" || collision.gameObject.tag == "Player")
        {
            isOpening = true; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ice" || collision.gameObject.tag == "Player")
        {
            isOpening = false; 
        }
    }
}
