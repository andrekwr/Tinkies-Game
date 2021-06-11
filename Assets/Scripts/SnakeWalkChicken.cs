using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeWalkChicken : MonoBehaviour
{
    private float checkRadius = 0.3f;
    public LayerMask chickenMask;
    private bool chicken_head;
    private Transform chickenTransform;
    // Start is called before the first frame update
    void Start()
    {
        chickenTransform = GameObject.Find("Player1").transform;

        
    }

    // Update is called once per frame
    void Update()
    {
        chicken_head = Physics2D.OverlapCircle(new Vector3(transform.position.x, transform.position.y - 0.35f, transform.position.z), checkRadius, chickenMask);

        if(chicken_head)
        {
            transform.SetParent(chickenTransform);
        } else{
            transform.SetParent(null);
        }
        
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - 0.35f, transform.position.z), checkRadius);
    } 
}
