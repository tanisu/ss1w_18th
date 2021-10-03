using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    Vector2 move;
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        move = context.ReadValue<Vector2>();
    }
    void Update()
    {
        transform.Translate(move * Time.deltaTime);
    }
}
