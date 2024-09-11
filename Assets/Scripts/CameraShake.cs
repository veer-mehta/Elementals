using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float timer = 1f;
    public IEnumerator shakeCamera()
    {
        Vector3 orignalPosition = transform.localPosition;

        float elapsed = 0f;

        while (elapsed<timer)
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);

            transform.localPosition = new Vector3 (x, y, orignalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = orignalPosition;
    }
}
