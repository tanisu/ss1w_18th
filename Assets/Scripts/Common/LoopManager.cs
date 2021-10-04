using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LoopManager : MonoBehaviour
{
    private int loopCount = 0;
    [SerializeField] int loopMax = 5;
    [SerializeField] Tilemap mapSprite;
    [SerializeField] GameObject itemTiles;
    [SerializeField] GameObject keyItem;
    [SerializeField] GameObject houtyouGenerator;
    [SerializeField] GameObject trap;
    [SerializeField] GameObject enemiyWrapper;
    Color[] colors;
    GameObject startPoint;
    GameObject player;
    Enemy[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        player = GameObject.FindGameObjectWithTag("Player");
        colors = new Color[] { Color.white,new Color(0.8f,0.2f,0.6f),Color.red, new Color(0.4f, 0.3f, 0.3f), Color.black};
        enemies = enemiyWrapper.GetComponentsInChildren<Enemy>();
        
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
                GameManager.I.GameOver();
                return;
            }


            _changeWithLoop();
            startPoint.GetComponent<StartPoint>().Restart();
            player.transform.position = startPoint.transform.position;
            player.GetComponent<player>().RepeatDream();

        }
    }

    public void AddLoop()
    {
        loopCount++;
       
        _changeWithLoop();

    }


    private void _changeWithLoop()
    {
        if (loopCount == 2)
        {
            itemTiles.SetActive(true);
            keyItem.SetActive(true);
            trap.SetActive(true);
            houtyouGenerator.SetActive(true);
            for(int i = 0;i < enemies.Length; i++)
            {
                enemies[i].ChangeChase();
            }
        }
        mapSprite.color = colors[loopCount];
    }
}
