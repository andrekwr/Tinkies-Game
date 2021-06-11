using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Referencia https://www.youtube.com/watch?v=GTxiCzvYNOc
public class CameraMove : MonoBehaviour
{
    public Vector2 followOffset;
    public Vector2 speed;
    public float vel = 7f;
    private Vector2 threshold;
    private Rigidbody2D rb;
    private bool outx;
    private bool outy;
    GameObject followObject;
    Vector3 newPosition;

    private void Start() {
        newPosition = transform.position;
        threshold = CalculateThreshold();
        followObject = GameObject.FindWithTag("Player1");
        transform.position = new Vector3(followObject.transform.position.x, followObject.transform.position.y, transform.position.z);
    }
    private void FixedUpdate() {
        Vector2 follow = followObject.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);
        if(Mathf.Abs(xDifference)>=threshold.x){
            outx = true;
        }
        if(Mathf.Abs(yDifference)>=threshold.y){
            outy = true;
        }
        if (outx){
            newPosition.x = follow.x;
        }
        if (outy){
            newPosition.y = follow.y;
        }
        if (Mathf.Abs(transform.position.x - follow.x)<=1f){
            outx = false;
        }
        if (Mathf.Abs(transform.position.y - follow.y)<=1f){
            outy = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, vel * Time.deltaTime);
    }

    private Vector3 CalculateThreshold() {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Vector2 border = CalculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
