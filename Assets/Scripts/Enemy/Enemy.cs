using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField]
    private float moveSpeed, waitTime, walkTime;

    private float waitCounter,moveCounter;

    private Vector2 moveDir;

    [SerializeField]
    private BoxCollider2D area;
    [SerializeField]
    private bool chase;

    private bool isChaseing;
    private bool isMoveing;
    [SerializeField]
    private float chaseSpeed,rangeToChase;
    private Transform target;
    private SpriteRenderer sp;
    private Color color;
  //  private Color baseColor;
    


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        isMoveing = true;
        sp = GetComponent<SpriteRenderer>();
        color = new Color(0.2f, 0.2f, 1);
        //baseColor = new Color(1f,1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoveing)
        {
            return;
        }

        if (!isChaseing)
        {
            
            if (waitCounter > 0)
            {
                waitCounter -= Time.deltaTime;
                rb2d.velocity = Vector2.zero;

                if (waitCounter <= 0)
                {
                    moveCounter = walkTime;

                    moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                    moveDir.Normalize();
                }
            }
            else
            {
                moveCounter -= Time.deltaTime;
                rb2d.velocity = moveDir * moveSpeed;
                if (moveCounter <= 0)
                {
                    waitCounter = waitTime;
                }
            }

            if (chase)
            {
                if (Vector3.Distance(transform.position,target.transform.position) < rangeToChase)
                {
                    
                    isChaseing = true;
                }
            }
        }
        else
        {
            if(waitCounter > 0)
            {
                waitCounter -= Time.deltaTime;
                rb2d.velocity = Vector2.zero;
                if(waitCounter <= 0)
                {
                    
                }
                
            }
            else
            {
                sp.color = color;
                moveDir = target.transform.position - transform.position;
                moveDir.Normalize();
                rb2d.velocity = moveDir * chaseSpeed;
            }

            if (Vector3.Distance(transform.position, target.transform.position) > rangeToChase)
            {
                isChaseing = false;
                waitCounter = waitTime;
            }
        }
  

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, area.bounds.min.x + 1, area.bounds.max.x - 1),
            Mathf.Clamp(transform.position.y, area.bounds.min.y + 1, area.bounds.max.y - 1), transform.position.z
            );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isChaseing)
            {
                //GameManager.I.ChangeGameState(GameState.GAMEOVER);
                GameManager.I.IsCatch();
                //rb2d.velocity = Vector2.zero;
                isMoveing = false;
                sp.color = new Color(1f, 1f, 1f);
                //restart loop
            }
        }
    }
}
