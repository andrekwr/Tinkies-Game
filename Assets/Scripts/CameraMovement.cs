using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform p1;
    public Transform p2;
    private float camHeight;
    private float minDist;
    private float maxDist;
    public static float distanceP;
    // Start is called before the first frame update
    void Start()
    {
        camHeight = 1.2f;
        minDist = 6.0f;
        maxDist = 10.45f;
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow(gameObject.GetComponent<Camera>(),p1,p2);
    }

 public void CameraFollow(Camera cam, Transform p1, Transform p2)
 {


     float zoom = 0.01f;
     float followTime = 0.8f;
 
    //Camera position
     Vector3 mid = new Vector3((p1.position.x + p2.position.x) / 2f, (p1.position.y + p2.position.y) / 2f + camHeight, -10f);
 
    //distanceP between players
     distanceP = (p1.position - p2.position).magnitude;
 
     // Move camera a certain distanceP
     Vector3 cameraToDis = mid - cam.transform.forward * distanceP * zoom;
 
     if (cam.orthographic)
     {
         if (distanceP < minDist) {
            cam.orthographicSize = minDist;
         } else if (distanceP > maxDist) {
            cam.orthographicSize = maxDist;
         } else {
             cam.orthographicSize = distanceP;
         }
         
     }

     transform.position = Vector3.Slerp(transform.position, cameraToDis, followTime);
         
     // Snap when close enough to prevent annoying slerp behavior
     if ((cameraToDis - transform.position).magnitude <= 0.05f)
         transform.position = cameraToDis;
 }
}
