using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFire : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject FlamePrefab;

    private List<GameObject> flameList;

    private void Start()
    {
        flameList = new List<GameObject>();
    }
    public void UsePower()
    {
        GameObject flame = Instantiate(FlamePrefab,SpawnPoint.position+new Vector3(0f,1.3f,0f),Quaternion.identity);
        flameList.Add(flame);
        GetComponent<PowerWater>().destroyPower();
        Destroy(flame,0.5f);
    }

}
