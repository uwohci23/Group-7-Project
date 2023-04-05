using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public GameObject playerBeach;
    public GameObject enemyBeach;
    //public Transform playerBeachT;
    //public Transform enemyBeachT;

    public GameObject bubbleGrid;
    public GameObject playerPoppedBubbleGrid;
    public GameObject enemyPoppedBubbleGrid;

    private int sum = 10;
    private int playerSum = 0;
    private int enemySum = 0;
    public UnitCurrentSum playerSumText;
    public UnitCurrentSum enemySumText; 

    //Unit playerUnit;
    //Unit enemyUnit;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        playerBeach = Instantiate(playerBeach);
        enemyBeach = Instantiate(enemyBeach);
        //Instantiate(playerBeachT);
        //Instantiate(enemyBeachT);

        //GameObject playerGO = Instantiate(playerPrefab, playerBeachT.position, Quaternion.identity);
        //Vector3 position = playerGO.transform.position;
        //position.y = playerPrefab.transform.position.y;
        //playerGO.transform.position = position;
        //playerUnit = playerGO.GetComponent<Unit>();

        //GameObject enemyGO = Instantiate(enemyPrefab, enemyBeachT.position, Quaternion.identity);
        //enemyUnit = enemyGO.GetComponent<Unit>();

        bubbleGrid = Instantiate(bubbleGrid);
        playerPoppedBubbleGrid = Instantiate(playerPoppedBubbleGrid);
        enemyPoppedBubbleGrid = Instantiate(enemyPoppedBubbleGrid);
        SetupBubbles();

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void SetupBubbles()
    {
        BubbleGridManager bgm = bubbleGrid.GetComponent<BubbleGridManager>();
        List<GameObject> bubbleList = bgm.getBubbles();
        Debug.Log(bubbleList);
        foreach (GameObject bubble in bubbleList)
        {
            BubbleUnit bubble_component = bubble.GetComponent<BubbleUnit>();
            bubble_component.system = this;
        }
    }

    void SetColliderFalse(GameObject beach)
    {
        BoxCollider2D obj = beach.transform.GetChild(1).GetComponent<BoxCollider2D>();
        obj.gameObject.SetActive(false);
    }

    void SetColliderActive(GameObject beach)
    {
        BoxCollider2D obj = beach.transform.GetChild(1).GetComponent<BoxCollider2D>();
        obj.gameObject.SetActive(true);
    }

    public void ChangeTurn(int value)
    {
        if (state == BattleState.PLAYERTURN)
        {
            // add value of the bubble to player's current sum
            playerSum = playerSum + value;
            // remove bubble from bubble grid and add to player's beach
            DeleteNumber(value, playerBeach);
            PlayerPoppedBubbleGrid ppbg = playerPoppedBubbleGrid.GetComponent<PlayerPoppedBubbleGrid>();
            ppbg.AddBubble(value);
            // update text
            playerSumText.ChangeText("Current Sum: " + playerSum.ToString());

            // check if game is won
            bool check = CheckSum(playerSum);
            if (check) {
                Debug.Log("player won");
            }
            // change turn
            EnemyTurn();
            state = BattleState.ENEMYTURN;
        }
        else if (state == BattleState.ENEMYTURN)
        {
            enemySum = enemySum + value;

            // remove bubble from bubble grid
            DeleteNumber(value, enemyBeach);
            // add bubble
            EnemyPoppedBubbleGrid epbg = enemyPoppedBubbleGrid.GetComponent<EnemyPoppedBubbleGrid>();
            epbg.AddBubble(value);
            // update text
            enemySumText.ChangeText("Current Sum: " + enemySum.ToString());

            // check if game is won
            bool check = CheckSum(enemySum);
            if (check)
            {
                Debug.Log("enemy won");
            }

            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else if (state == BattleState.WON)
        {
            Debug.Log("out of turns");
        }
    }

    private bool CheckSum(int currentSum)
    {
        if (currentSum == sum)
        {
            Debug.Log("WON GAME");
            state = BattleState.WON;
            return true;
        }
        return false;
    }

    private void DeleteNumber(int value, GameObject beach)
    {
        BubbleGridManager bgm = bubbleGrid.GetComponent<BubbleGridManager>();
        bgm.DeleteBubble(value);
    }

    private void PlayerTurn()
    {
        SetColliderActive(playerBeach);
        SetColliderFalse(enemyBeach);
    }

    void EnemyTurn()
    {
        SetColliderActive(enemyBeach);
        SetColliderFalse(playerBeach);
    }

}
