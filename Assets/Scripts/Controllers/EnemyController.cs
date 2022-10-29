using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 0.3f;
    Rigidbody2D rb;
    GameObject player;
    private Vector2 toPlayer;
    Vector2 boxSize = new Vector2(1, 1);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        toPlayer = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;

        RaycastHit2D[] hits = (Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero));
        {
            if (hits.Length > 0)
            {
                foreach (RaycastHit2D rc in hits)
                {
                    if (rc.transform.CompareTag("Player"))
                    {
                        rb.MovePosition(rb.position += toPlayer * speed * Time.deltaTime);
                    }
                }
            }
        }
                    
    }
}
