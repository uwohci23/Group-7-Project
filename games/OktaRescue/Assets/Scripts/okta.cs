using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class okta : MonoBehaviour
{
    public float speed;
    public logicScript logic;

    private Color startcolor;
	private SpriteRenderer oktaSR;
    private Vector3 targetPosition;
    private Vector3 startPos;
    // prev position of a okta that it can be return to
    private Vector3 prevPos;
    public Vector2 initalPos = new Vector2(7f, 3f);
    public float addX = 1.5f;
    public float addY = -1.5f;
	private bool isDown = false;


    // Start is called before the first frame update
    void Start()
    {
        oktaSR = GetComponent<SpriteRenderer>();
        startcolor = oktaSR.color;
        // check which should be target position in the list

        startPos = transform.position;
        prevPos = transform.position;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveOktaTo();

    }

    // need to find the position first and not update it per frame
    // vecotr3 movetowards with target position need to be update per fram


    // determine where okta should be moved to
    // used to select and unselect okta
    public void MoveOktaTo()
    {
        if (isDown) {
            if (oktaSR.tag == "Selected") {
                // findTargetPos();
                startPos = Vector3.MoveTowards(startPos, targetPosition, speed * Time.deltaTime);
                transform.position = startPos;
            }
            else if (oktaSR.tag == "Okta") {
                startPos = Vector3.MoveTowards(transform.position, prevPos, speed * Time.deltaTime);
                transform.position = startPos;
                oktaSR.color = startcolor;
            }

        }
        if (transform.position == targetPosition) {
            // oktaSR.color = Color.green;
            isDown = false;
        }
    }

    // if it selected, get the position 
    // PlayerPrefs stores number of selected okta
    // if total number % 2 == 0 
    // update y axis by addY * (total number / 2)
    // else update inital pos by addX * 1
    // THIS LOGIC IS FINE
    void findTargetPos() {
        int savedNum = logic.getScore();
        int numRow = savedNum / 2;
        if (savedNum % 2 == 0 && savedNum != 0) {
            targetPosition = new Vector2(initalPos.x, initalPos.y + addY * numRow);
        }
        else if (savedNum % 2 == 1){
            Debug.Log("current saved num: " + savedNum + " at " + targetPosition);
            targetPosition = new Vector2(initalPos.x + addX, initalPos.y + addY * numRow);
        }
        else {
            Debug.Log(targetPosition);
            targetPosition = initalPos;
        }


    }

    // change the object to yellow when mouse hover
    void OnMouseEnter()
    {
        startcolor = oktaSR.color;
        oktaSR.color = Color.yellow;
    }

    void OnMouseExit()
    {
        oktaSR.color = startcolor;
    }

    // maybe in easy level let okta gets flushed
    // change the object to yellow when user click okta and okta will automatically move to a left position
    // change okta tag to selected after user click one
	void OnMouseDown() {
        findTargetPos();
        if (oktaSR.tag == "Selected") {
            oktaSR.tag = "Okta";

        }
        else {
            oktaSR.tag = "Selected";
        }
        isDown = true;
	}

    void OnTriggerEnter2D(Collider2D collision) {


        if (collision.gameObject.tag == "Tube" && oktaSR.tag == "Selected") {
            logic.addNum(1);
        }
        else if (collision.gameObject.tag == "Tube" && oktaSR.tag == "Okta") {
            logic.subtractNum(1);
        }
    }



        
}
