using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Color color;
    public int health = 100;
    public int damage = 10;
    public int speed = 3;
    public bool isSmart = true;
    private Vector2 target;
    void Start()
    {
        // Change the color of the enemy
        GetComponent<SpriteRenderer>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSmart)
        {
            // Move towards the player
            GameObject player = GameObject.Find("Player");
            Vector3 direction = player.transform.position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
        else
        { 
            // Choose target if it has achieved target already or its null
            if (target == null || Vector3.Distance(transform.position, target) < 0.1f)
            {
                target =  Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            }
            // Move towards the target
            Vector3 direction = target - (Vector2)transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
}
