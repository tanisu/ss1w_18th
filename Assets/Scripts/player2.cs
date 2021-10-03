using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngin.InputSystem;

public class player2 : MonoBehaviour
{
    public InputAction m_inputMover;//InputActionはInputSystemを扱うもの
    public Vector2 m_movementValue;
    public float m_fSpeed = 0.01;//パラメータを受け取るためのVector2と移動速度の変数

    private void OnEnable()
	{
        m_inputMover.Enable();
	}

    private void OnDisable()
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
