using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class player : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 move;
    [SerializeField]
    float speed;
    PlayerState playerState = PlayerState.SLEEP;
    //Direction direction = Direction.STOP;

    private bool isRunning = false;//何も書いてないとfalse
    private bool isTired = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Static;
    }

    public void RepeatDream()
    {
        Debug.Log("repeat");
        
        transform.localScale = new Vector3(1f, 1f, 1f);
        rb2d.bodyType = RigidbodyType2D.Static;
        playerState = PlayerState.SLEEP;
        Debug.Log(transform.rotation);

        transform.rotation = new Quaternion(0f, 0f, 0,0.5f);
    }

    public void OnMove(InputAction.CallbackContext context)
    {

        if (playerState == PlayerState.SLEEP)
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            playerState = PlayerState.WAKE;
        }

       // Debug.Log(context.ReadValue<Vector2>());
        // 押しっぱなしの動作は、直接オブジェクトを動かすのではなく方向性のみを登録する
        move = context.ReadValue<Vector2>();
    }

    //離したらspeed１にしたい
    public void OnDash(InputAction.CallbackContext context)
    {
        
        if(context.started)
		{
            StartCoroutine(running());
            Debug.Log(context.ReadValueAsButton());
        }
        
        if(context.canceled)
		{
            speed = 3f;
            Debug.Log(context.ReadValueAsButton());

            
            if(isTired == true)
			{
                StartCoroutine(tiredboy());
                //speed = 1f;
                //キー入力無効みたいな感じにしたい
            }
            

        }

    }

    void Update()
    {
       
        if (move.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            //direction = Direction.LEFT;
        }
        else if (move.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            //direction = Direction.RIGHT;
        }

        Debug.Log(isTired);
        Debug.Log(isRunning);

        transform.Translate(move * Time.deltaTime * speed);
    }

    IEnumerator running()
    {
        if (isRunning) yield break;

        isRunning = true;

        speed = 5f;
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
    
    


    public void FallHole(Transform tf)
    {
        transform.DOMove(tf.position, 1f);
        transform.DOScale(Vector3.zero,1f).OnComplete(()=> {
            GameManager.I.IsCatch();
            
        });
    }

    
}
