using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller2d : MonoBehaviour
{
    public LayerMask collisionMask;
    public LayerMask springMask;


    const float skinWidth = 0.03f;
    public int horizontalRayCount;
    public int verticalRayCount;

    BoxCollider2D collider_;
    RaycastOrigins raycastOrigins;

    

    const float dstBetweenRays = .12f;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    public CollisionInfo collisions;

    public RaycastHit2D spring;


    // Start is called before the first frame update
    void Start()
    {
        collider_ = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
    }

    public void Move(Vector2 velocity)
    {
        UpdateRaycastOrigins();
        collisions.Reset();
        if (velocity.x != 0)
        {
            HorizontalCollisions(ref velocity);
        }
        if (velocity.y != 0)
        {
            VerticalCollisions(ref velocity);
        }

        transform.Translate(velocity);
    }

    void HorizontalCollisions(ref Vector2 velocity)
    {
        float directionX = Mathf.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x) + skinWidth;

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);
            Debug.DrawRay(rayOrigin, Vector2.right * directionX, Color.red);
            if (hit)
            {
                velocity.x = (hit.distance - skinWidth) * directionX;
                rayLength = hit.distance;
                collisions.left = directionX == -1;
                collisions.right = directionX == 1;
            }

        }
    }

    void VerticalCollisions(ref Vector2 velocity)
    {
        float directionY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + skinWidth;

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);
            Debug.DrawRay(rayOrigin, Vector2.up * directionY, Color.red);
            if (gameObject.name == "Player1" && !spring){
                spring = Physics2D.Raycast(rayOrigin, Vector2.up * -1, rayLength, springMask);
            }
            if (hit)
            {
                velocity.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;
                collisions.below = directionY == -1;
                collisions.above = directionY == 1;
            }
        }
    }

    void UpdateRaycastOrigins()
    {
        Bounds bounds = collider_.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    public void CalculateRaySpacing()
    {
        Bounds bounds = collider_.bounds;
        bounds.Expand(skinWidth * -2);

        float boundsWidth = bounds.size.x;
        float boundsHeight = bounds.size.y;

        horizontalRayCount = Mathf.RoundToInt(boundsHeight / dstBetweenRays);
        verticalRayCount = Mathf.RoundToInt(boundsWidth / dstBetweenRays);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

    public struct CollisionInfo
    {
        public bool above, below;
        public bool left, right;

        public void Reset()
        {
            above = below = false;
            left = right = false;
        }
    }

}
