using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;
    public int recoilStrength = 300;
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

        // Add a recoil momentum to the player
        player.GetComponent<Rigidbody2D>().AddForce(-bullet.transform.right * recoilStrength);
    }
}
