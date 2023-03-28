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
    // 18 available pos
    public List<Vector3> availablePos = new List<Vector3>();


	private bool isDown = false;


    // Start is called before the first frame update
    void Start()
    {
        availablePosList();

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
        findTargetPos();
        MoveOktaTo();

    }

    // determine where okta should be moved to
    // used to select and unselect okta
    public void MoveOktaTo()
    {
        if (isDown) {
            if (oktaSR.tag == "Selected") {
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

    void availablePosList() {
        availablePos.Add(new Vector3(8.1f, -3f, 0));
        availablePos.Add(new Vector3(7f, -3f, 0));
        availablePos.Add(new Vector3(8.1f, -2.5f, 0));
    }

    void findTargetPos() {
        targetPosition = new Vector3(8.1f, -3f, 0);
        // targetPosition = availablePos[Random.Range(0, 2)];
    }
        
}
