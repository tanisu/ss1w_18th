using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    Vector2 move;
    float speed = 1f;

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        // 押しっぱなしの動作は、直接オブジェクトを動かすのではなく方向性のみを登録する
        move = context.ReadValue<Vector2>();
    }

    //離したらspeed１にする
    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.performed)
		{
            speed = 100f;
            //押しっぱなしのときを感知して、speedniに*
            Debug.Log(context.ReadValueAsButton());
            //transform.Translate(move * Time.deltaTime * 100);
        }
    }

    void Update()
    {
        transform.Translate(move * Time.deltaTime * speed);
    }
}
