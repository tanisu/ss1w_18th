using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 move;
    [SerializeField]
    float speed;
    PlayerState playerState = PlayerState.SLEEP;
    Direction direction = Direction.STOP;

    private bool buttonDownFlag = false;//追加

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Static;
    }

    public void RepeatDream()
    {
        rb2d.bodyType = RigidbodyType2D.Static;
        playerState = PlayerState.SLEEP;
    }

    public void OnMove(InputAction.CallbackContext context)
    {

        if (playerState == PlayerState.SLEEP)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            playerState = PlayerState.WAKE;
        }
        Debug.Log(context.ReadValue<Vector2>());
        // 押しっぱなしの動作は、直接オブジェクトを動かすのではなく方向性のみを登録する
        move = context.ReadValue<Vector2>();
    }

    //離したらspeed１にしたい
    public void OnDash(InputAction.CallbackContext context)
    {
        
        if(context.performed)
		{
            /*
            if(buttonDownFlag = true)//追加
			{
                speed = 10f;
            }
            if (buttonDownFlag = false)//追加
            {
                speed = 1f;
            }
            */
            speed = 10f;
            //押しっぱなしのときを感知して、speedniに*
            Debug.Log(context.ReadValueAsButton());
            //transform.Translate(move * Time.deltaTime * 100);
        }
        if(context.canceled)
		{
            speed = 1f;
            Debug.Log(context.ReadValueAsButton());
        }
    }

    void Update()
    {
        /*
        if (buttonDownFlag)//追加
        {
            Debug.Log("Hold");
        }
        */

        if (move.x < 0)
        {
            direction = Direction.LEFT;
        }
        else if (move.x > 0)
        {
            direction = Direction.RIGHT;
        }


        transform.Translate(move * Time.deltaTime * speed);


    }

    /*
    public void OnButtonDown()//追加
	{
        Debug.Log("Down");
        buttonDownFlag = true;
	}

    public void OnButtonUp()//追加
	{
        if(buttonDownFlag)
		{
            Debug.Log("Up");
            buttonDownFlag = false;
        }
	}
    */

}
