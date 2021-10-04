using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LoopManager : MonoBehaviour
{
    private int loopCount = 0;
    [SerializeField]
    private int loopMax = 5;
    [SerializeField]
    Tilemap mapSprite;
    [SerializeField]
    GameObject itemTiles;
    Color[] colors;
    GameObject startPoint;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        player = GameObject.FindGameObjectWithTag("Player");
        colors = new Color[] { Color.white,Color.blue,Color.cyan,Color.red,Color.black};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loop()
    {
        if (loopCount < loopMax)
        {

            loopCount++;
            if(loopCount >= loopMax)
            {
                return;
            }
            if(loopCount > 2)
            {
                itemTiles.SetActive(true);
            }
            Debug.Log(loopCount);
            mapSprite.color = colors[loopCount];
            startPoint.GetComponent<StartPoint>().Restart();
            player.transform.position = startPoint.transform.position;
            player.GetComponent<player>().RepeatDream();

        }
    }
}
