using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class player : MonoBehaviour
{
    SpriteRenderer sp;
    Rigidbody2D rb2d;
    Vector2 move;
    [SerializeField]
    float speed,dashSpeed;
    [SerializeField]
    private int limitTime, restTime;
    [SerializeField]
    private GameObject zzz,ase;

    PlayerState playerState = PlayerState.SLEEP;

    private bool isRunning ,isTired,isTiredSE;//何も書いてないとfalse
        
    private float totalTime;
    private int seconds;
    



    private void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        rb2d.bodyType = RigidbodyType2D.Static;
    }

    public void RepeatDream()
    {

        
        zzz.SetActive(true);
        transform.localScale = new Vector3(1f, 1f, 1f);
        rb2d.bodyType = RigidbodyType2D.Static;
        
        playerState = PlayerState.SLEEP;
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
        if (playerState == PlayerState.SLEEP)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            rb2d.gravityScale = 0f;
            playerState = PlayerState.WAKE;
            zzz.SetActive(false);
        }

        if (isTired)
        {
            return;
        }
        
        // Debug.Log(context.ReadValue<Vector2>());
        // 押しっぱなしの動作は、直接オブジェクトを動かすのではなく方向性のみを登録する
        move = context.ReadValue<Vector2>();
    }

    //離したらspeed１にしたい
    public void OnDash(InputAction.CallbackContext context)
    {
        if (playerState != PlayerState.WAKE)
        {
            return;
        }
        if (isTired)
        {
            return;
        }

        if (context.started)
        {
            SoundManager.instance.PlaySE(SoundManager.SE.RunSingle);
            speed = dashSpeed;
            sp.color = Color.red;
            ase.SetActive(true);
            isRunning = true;
        }


        
        if(context.canceled)
		{
            ase.SetActive(false);
            sp.color = Color.white;
            totalTime = 0;
            isRunning = false;
            speed = 3f;
        }

    }



    void Update()
    {
        if(playerState != PlayerState.WAKE)
        {
            return;
        }
       
        if (move.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (move.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (isRunning)
        {
            _countDown();
        }
        if (isTired)
        {
            if (!isTiredSE)
            {
                SoundManager.instance.PlaySE(SoundManager.SE.Tired);
                isTiredSE = true;
            }
            
            _stopCount();
        }
        
        transform.Translate(move * Time.deltaTime * speed);
    }

    private void _stopCount()
    {
        
        ase.SetActive(false);
        sp.color = Color.cyan;
        totalTime += Time.deltaTime;
        seconds = (int)totalTime;
        
        if(seconds > restTime)
        {
            
            sp.color = Color.white;
            speed = 3f;
            move = Vector2.zero;
            totalTime = 0;
            isTired = false;
            isTiredSE = false;
        }
    }


    private void _countDown()
    {
       // StartCoroutine(_dashSound());
        totalTime += Time.deltaTime;
        seconds = (int)totalTime;
        if(seconds > limitTime)
        {
            isRunning = false;
            speed = 0;
            totalTime = 0;
            isTired = true;
        }
    }

    IEnumerator _dashSound()
    {
        if (!isRunning) yield break;

        while (isRunning)
        {
            SoundManager.instance.PlaySE(SoundManager.SE.RunSingle);
            yield return new WaitForSeconds(0.2f);
            
        }
        
    }
  
    
    
    public void FallBillding()
    {
        rb2d.gravityScale = 1.5f;
        rb2d.velocity = Vector2.zero;
        
        StartCoroutine(_screaming());
        PlayerDead();
    }

    public void FallHole(Transform tf)
    {
        StartCoroutine(_screaming());
        PlayerDead();
        transform.DOMove(tf.position, 1f).SetLink(gameObject);
        transform.DOScale(Vector3.zero,1f).SetLink(gameObject).OnComplete(()=> {
            GameManager.I.IsCatch();
        });
    }

    IEnumerator _screaming()
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Fall);
        yield return new WaitForSeconds(0.3f);
        SoundManager.instance.PlaySE(SoundManager.SE.Screaming);


    }

    public void PlayerDead()
    {
        isRunning = false;
        playerState = PlayerState.DEAD;
    }


    IEnumerator running()
    {
        if (isRunning) yield break;

        isRunning = true;

        speed = 6f;
        // 指定した秒数待つ
        yield return new WaitForSeconds(3f);

        speed = 0f;//isTiredの関数内でいいかも
        isTired = true;

        yield return new WaitForSeconds(2f);

        speed = 3f;

        isRunning = false;
    }

    //isTired = trueだったら、という関数作る

    IEnumerator tiredboy()
    {
        speed = 0f;
        yield return new WaitForSeconds(2f);

        isTired = false;
    }
}
