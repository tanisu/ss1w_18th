using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager I;
    public GameState gameState;
    private int loopCount = 0;
    [SerializeField]
    private int loopMax = 5;
    GameObject startPoint;
    GameObject player;

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
        startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsCatch(){
        if(loopCount < loopMax)
        {
            loopCount++;
            startPoint.GetComponent<StartPoint>().Restart();
            player.transform.position = startPoint.transform.position;
            player.GetComponent<player>().RepeatDream();

        }
    }


    public void ChangeGameState(GameState g)
    {
        gameState = g;
    }
}
