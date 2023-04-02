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

    Unit playerUnit;
    Unit enemyUnit;

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
        Instantiate(playerPoppedBubbleGrid);
        Instantiate(enemyPoppedBubbleGrid);
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
            Debug.Log("here");
        }
        Debug.Log("done");
    }

    void setColliderFalse(GameObject beach)
    {
        BoxCollider2D obj = beach.transform.GetChild(1).GetComponent<BoxCollider2D>();
        obj.gameObject.SetActive(false);
    }

    void setColliderActive(GameObject beach)
    {
        BoxCollider2D obj = beach.transform.GetChild(1).GetComponent<BoxCollider2D>();
        obj.gameObject.SetActive(true);
    }

    public void changeTurn(int value)
    {
        Debug.Log("change turn");
        if (state == BattleState.PLAYERTURN)
        {
            // add value of the bubble to player's current sum
            playerSum = playerSum + value;
            // remove bubble from bubble grid and add to player's beach
            DeleteNumber(value, playerBeach);
        }
        if (state == BattleState.ENEMYTURN)
        {
            Debug.Log("this is enemy turn");
        }
    }

    private void CheckSum(int currentSum)
    {
        if (currentSum == sum)
        {
            Debug.Log("done");
            state = BattleState.WON;
        }
    }

    private void DeleteNumber(int value, GameObject beach)
    {
        BubbleGridManager bgm = bubbleGrid.GetComponent<BubbleGridManager>();
        bgm.DeleteBubble(value);
        // access the bubblegridmanager
        // delete the number referenced
        // add to beach
    }

    private void PlayerTurn()
    {
        //set reference to enemy collider false
        Debug.Log("Starting player turn logic.");
        setColliderActive(playerBeach);
        setColliderFalse(enemyBeach);
    }

    void EnemyTurn()
    {
        // pass
    }

}
