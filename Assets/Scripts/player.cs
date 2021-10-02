using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class player : MonoBehaviour
{
    //新しいインプットシステム調べる
    //レイを飛ばして、返ってくるか

    public void OnMove(InputAction.CallbackContext context)
	{
        Debug.Log(context.ReadValue<Vector2>());
	}
}
