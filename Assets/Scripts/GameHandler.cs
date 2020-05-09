using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Text lvlText;
    [SerializeField] GameObject arrowPrefab;

    GameObject ballGO;
    BallMoover ballComponent;
    ArrowInput inputArrow;

    GameObject enemyGO;
    EnemyControll enemyControll;

    List<GameObject> blockList;
    int activeBlockCount;

    int lvl;


    int startPositionX = 4;
    int startPositionZ = -6;
    int startPositionY = 1;
    int distanceBetweenBlocks = 3;

    void Awake()
    {
        lvl = 1;
        CreateBall();


        CreateEnemy();

        blockList = new List<GameObject>();
        activeBlockCount = 0;

        CreateBlock();
        CreateBlock();
        CreateBlock();

        InputInitialisation();
    }

   
    private void CreateBlock()
    {
       
        GameObject blockTemp;
        Vector3 blockPos = new Vector3(startPositionX + (activeBlockCount * distanceBetweenBlocks), startPositionY, startPositionZ);
        blockList.Add(blockTemp = Instantiate(blockPrefab, blockPos, Quaternion.identity));
        blockTemp.GetComponent<BlockTrigger>().gameHandler = this;
        activeBlockCount++;
    }

    public void DeactivateBlocks(GameObject block)
    {
        block.SetActive(false);
        activeBlockCount--;
        ballComponent.SetDefaultPosition();
        if(activeBlockCount <= 0)
        {
            LvlUP();
        }
    }
    private void LvlUP()
    {
        enemyControll.LvlUp();
        lvl++;
        UILvlUpdate();
        RestartLvl();

    }
    private void RestartLvl()
    {
        ActivateBlocks();
    }
    private void ActivateBlocks()
    {
        for (int i = 0; i < blockList.Count; i++)
        {
            blockList[i].SetActive(true);
            activeBlockCount++;
        }
    }
    private void CreateEnemy()
    {
        enemyGO = Instantiate(enemyPrefab);
        enemyControll = enemyGO.GetComponent<EnemyControll>();
        enemyControll.ball = ballGO;
    }
    private void CreateBall()
    {
        ballGO = Instantiate(ballPrefab);
        ballComponent = ballGO.GetComponent<BallMoover>();
    }
    private void UILvlUpdate()
    {
        lvlText.text = "Lvl: " + lvl;
    }
    public void InputInitialisation()
    {
        inputArrow = gameObject.AddComponent<ArrowInput>();
        inputArrow.arrowPrefab = arrowPrefab;
        inputArrow.ballComponent = ballComponent;
    }

    
}
