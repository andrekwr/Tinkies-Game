using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float shootSeconds;
    public GameObject bulletPrefab;

    public float bulletVel;

    public GameObject bullet;

    private int direction;
    private Vector3 bulletPos;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot(){
        while(true){
            yield return new WaitForSeconds(shootSeconds);
            direction = gameObject.GetComponent<SpriteRenderer>().flipX ? -1 : 1;
            bulletPos = transform.GetChild(0).position;
            bulletPos.x = gameObject.GetComponent<SpriteRenderer>().flipX ? bulletPos.x - (0.36f * 2): bulletPos.x;
            bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
            bullet.GetComponent<BulletMove>().vel = bulletVel*direction;
        }
    }
}
