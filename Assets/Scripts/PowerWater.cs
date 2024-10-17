using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerWater : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject ice;
    [SerializeField] float iceHeight;

    private GameObject lastIceBlock;
    private Vector3 spawnPosition;
    private Stack<GameObject> iceStack;

    private void Start()
    {
        iceStack = new Stack<GameObject>();
    }
    public void UsePower()
    {
        if (lastIceBlock!=null )
        {
            spawnPosition = lastIceBlock.transform.position + new Vector3(0f, iceHeight, 0f);
        }
        else
        {
            spawnPosition=spawnPoint.position;
        }
        if(iceStack.Count < 8)
        {
            lastIceBlock = Instantiate(ice, spawnPosition, Quaternion.identity);
            iceStack.Push(lastIceBlock);
        }
    }

    public void destroyPower()
    {
        if (iceStack.Count>0)
        {
            Destroy(lastIceBlock);
            spawnPosition = lastIceBlock.transform.position - new Vector3(0f, iceHeight, 0f);
            iceStack.Pop();
            if (iceStack.Count != 0)
            {
                lastIceBlock = iceStack.Peek();
            }
            else
            {
                lastIceBlock = null;
            }  
        }
        return;
    }
}
