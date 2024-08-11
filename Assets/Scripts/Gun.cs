using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If LMB clicked, shoot a bullet
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        // get a child named 'BulletPoint' from the gun
        GameObject bulletPoint = transform.Find("BulletPoint").gameObject;
        
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);
        // Set bullets vel to the direction of the gun
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 10;

        // Add a recoil back to the player
        player.GetComponent<Rigidbody2D>().AddForce(-player.transform.right * 100);
    }
}
