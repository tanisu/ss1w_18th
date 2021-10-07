using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 moveDir;
    [SerializeField] float moveSpeed, waitTime, walkTime;
    public BoxCollider2D area;
    [SerializeField] float chaseSpeed;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDir = new Vector2(1f,0) ;
        moveDir.Normalize();
        rb2d.velocity = moveDir * moveSpeed;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, area.bounds.min.x + 1, area.bounds.max.x - 1),
            Mathf.Clamp(transform.position.y, area.bounds.min.y + 1, area.bounds.max.y - 1), 
            transform.position.z
        );
    }
}
