using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class saveButton : MonoBehaviour
{
	public Button saveB;

    public logicScript logic;

    private oktaSpawn oktaSpawner;
    // Start is called before the first frame update
    void Start()
    {

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
		oktaSpawner = GameObject.FindGameObjectWithTag("OktaSpawner").GetComponent<oktaSpawn>();

        Button btn = saveB.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void TaskOnClick(){
        oktaSpawner.generateOkta(5);
		Debug.Log ("You have clicked the button!");
	}

}
