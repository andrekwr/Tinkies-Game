using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float vel;

    void Update()
    {
        transform.position = new Vector3(transform.position.x + (vel*Time.deltaTime), transform.position.y, transform.position.z);

    }

}
