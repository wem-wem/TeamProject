using UnityEngine;
using System.Collections;

public class LightRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, Random.Range(5.0f, 10.0f));
    }
}
