using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float xBound1;
    public float xBound2;
    private float xScale;
    private Rigidbody2D rb;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        xScale = transform.localScale.x/transform.localScale.x;
        moveDirection = new Vector3(xScale, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        float temp = Mathf.Abs(transform.localScale.x);
        if (transform.position.x >= xBound1)
        {
            transform.localScale = new Vector3(-temp, transform.localScale.y, 0);
        }
        if (transform.position.x <= xBound2)
        {
            transform.localScale = new Vector3(temp, transform.localScale.y, 0);
        }
        moveDirection = new Vector3(transform.localScale.x, 0, 0);
        rb.velocity = moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player)
        {
            player.setIsHurt(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.setIsHurt(false);
        }
    }
}
