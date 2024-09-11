using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEarth : MonoBehaviour
{
    [SerializeField] CameraShake shake;
    
    public void UsePower()
    {
        StartCoroutine(shake.shakeCamera());
    }
}
