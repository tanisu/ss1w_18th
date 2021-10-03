using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player2 : MonoBehaviour
{
    public InputAction m_inputMover;//InputActionはInputSystemを扱うもの
    public Vector2 m_movementValue;
    public float m_fSpeed = 0.01f;//パラメータを受け取るためのVector2と移動速度の変数

    public void OnEnable()
	{
        m_inputMover.Enable();
	}

    public void OnDisable()
    {
        m_inputMover.Disable();
    }

    void Update()
    {
        m_movementValue = m_inputMover.ReadValue<Vector2>();
        transform.Translate(
            m_movementValue.x * m_fSpeed,
            m_movementValue.y * m_fSpeed,
            0.0f);
    }
}
