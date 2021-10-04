using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager I;
    public GameState gameState;
    [SerializeField]
    private LoopManager loopManager;

    private void Awake()
    {
        if (I == null)
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

    public void IsCatch(){
        loopManager.Loop();
    }


    public void ChangeGameState(GameState g)
    {
        gameState = g;
    }
}
