using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager I;
    public GameState gameState;
    

    private void Awake()
    {
        if(I == null)
        {
            I = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameState = GameState.PLAY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGameState(GameState g)
    {
        gameState = g;
    }
}
