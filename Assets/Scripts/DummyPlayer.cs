using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayer : MonoBehaviour
{

    Rigidbody2D rb2d;
    Animator animator;
    float x;
    float y;
    float speed = 3f;
    


    Direction direction = Direction.STOP;
    PlayerState playerState = PlayerState.SLEEP;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(GameManager.I.gameState == GameState.GAMEOVER)
        {
            direction = Direction.STOP;
            
            return;
        }
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        
        if(x != 0 || y != 0 && playerState == PlayerState.SLEEP)
        {
            Debug.Log("wake");
            playerState = PlayerState.WAKE;
            transform.localRotation = new Quaternion(0f,0f,0f,0f);
        }
        
        if(x == 0 && y == 0)
        {
            direction = Direction.STOP;
        }
        else if( x > 0 && y == 0)
        {
            direction = Direction.RIGHT;
        }
        else if(x < 0 && y == 0)
        {
            direction = Direction.LEFT;
        }else if(y > 0 && x == 0)
        {
            direction = Direction.UP;
        }else if(y < 0 && x == 0)
        {
            direction = Direction.DOWN;
        }
    }

    private void FixedUpdate()
    {
        switch (direction)
        {
            case Direction.STOP:
                rb2d.velocity = new Vector2(0f, 0f);
                break;
            case Direction.UP:
                rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
                animator.SetTrigger("Up");
                break;
            case Direction.DOWN:
                rb2d.velocity = new Vector2(rb2d.velocity.x, -speed);
                animator.SetTrigger("Down");
                break;
            case Direction.RIGHT:
                transform.localScale = new Vector3(1, 1, 1);
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
                animator.SetTrigger("Side");
                break;
            case Direction.LEFT:
                transform.localScale = new Vector3(-1, 1, 1);
                rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
                animator.SetTrigger("Side");

                break;
        }
    }
}
