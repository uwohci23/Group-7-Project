using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class saveButton : MonoBehaviour
{
	public Button saveB;

    public logicScript logic;

    public oktaSpawn oktaSpawner;
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
        int addOkta = logic.getScore();
        DestroyAll("Selected");
        oktaSpawner.generateOkta(addOkta);

	}

    void DestroyAll(string tag) {
        GameObject[] selectedOkta = GameObject.FindGameObjectsWithTag(tag);
        for(int i=0; i< selectedOkta. Length; i++)
        {
            Destroy(selectedOkta[i]);
        }
    }

}
