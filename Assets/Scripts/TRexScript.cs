using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TRexScript : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public int speed = 3;
    private const float maxWaitTimer = 1.0f;
    public float waitTimer = 1.0f;
    private Vector2 target;
    void Start()
    {
        // Change the color of the enemy
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction;
        GameObject player = GameObject.Find("Player");
        if (player.GetComponentInChildren<Rigidbody2D>().velocity != Vector2.zero)
        { 
            // Move towards the player
            direction = player.transform.position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
            waitTimer = maxWaitTimer;
        }
        else
        {
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
                return;
            }
            // Choose target if it has achieved target already or its null
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                target = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            }

            // Move towards the target
            direction = target - (Vector2)transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= collision.gameObject.GetComponent<BulletScript>().damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
