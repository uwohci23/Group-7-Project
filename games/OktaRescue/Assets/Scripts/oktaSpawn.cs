using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// OKTA OVERLAP EACH OTHER!!!
public class oktaSpawn : MonoBehaviour
{
    public GameObject okta;
    private int maxOkta = 18;
    private List<GameObject> oktaList;

    // Start is called before the first frame update
    void Start()
    {
        oktaList = new List<GameObject>();
        
        
        generateOkta(maxOkta);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void generateOkta(int oktaNum) {
        float height = Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
        height -= 1f;
		width -= 1f;
        int counter = 0;

       	while(counter < oktaNum) {

            Vector2 pos;
            do {
                float oktaWidth = Random.Range(-width + 1f, width - 3.5f);
                float oktaHeight = Random.Range(-height, height - 1f);
                pos = new Vector2(oktaWidth, oktaHeight);
                Debug.Log("regenerated");

            } while (Physics2D.OverlapCircleAll(pos, 1f).Length > 0);
            // okta is a PREFAB!!!!
            GameObject oktaObj= Instantiate(okta, pos, transform.rotation);
            oktaList.Add(oktaObj);

            counter ++;
        }
    }
}
