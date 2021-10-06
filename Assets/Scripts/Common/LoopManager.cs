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
    [SerializeField] GameObject globalLight;
    [SerializeField] GameObject pointLight;
    [SerializeField] GameObject nextConfiner;
    [SerializeField] WrapPoint[] wrapPoints;
    [SerializeField] Vector2 nextPos;
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

            
            player.transform.position = startPoint.transform.position;
            player.GetComponent<player>().RepeatDream();
            _changeWithLoop();
            startPoint.GetComponent<StartPoint>().Restart();

        }
    }

    public void AddLoop()
    {
        loopCount++;
       
        _changeWithLoop();

    }


    private void _changeWithLoop()
    {
        if(loopCount == 1)
        {
            if (trap)
            {
                trap.SetActive(true);
            }
            if (wrapPoints.Length > 0)
            {
                foreach (WrapPoint wrapPoint in wrapPoints)
                {
                    wrapPoint.ChangeConfiner(nextConfiner);
                    wrapPoint.ChangeNextPos(nextPos);
                }
            }
            
        }

        if (loopCount == 2)
        {
            if (itemTiles)
            {
                itemTiles.SetActive(true);
            }
            if (keyItem)
            {
                keyItem.SetActive(true);
            }
            

            if (houtyouGenerator)
            {
                houtyouGenerator.SetActive(true);
            }
            if (enemies.Length > 0)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].ChangeChase();
                }
            }
            globalLight.SetActive(false);
            pointLight.SetActive(true);


        }
        mapSprite.color = colors[loopCount];
    }
}
