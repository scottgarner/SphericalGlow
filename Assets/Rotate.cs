using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speed = 100;
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(Time.time * speed, Vector3.back);
    }
}
