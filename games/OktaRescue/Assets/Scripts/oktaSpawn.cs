using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// OKTA OVERLAP EACH OTHER!!!
public class oktaSpawn : MonoBehaviour
{
    public GameObject okta;
    private int maxOkta = 3;
    private List<GameObject> oktaList;
    private IDictionary<float, float> posDictionary = new Dictionary<float, float>();

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
            float oktaWidth = Random.Range(-width + 1, width - 3);
            float oktaHeight = Random.Range(-height, height - 1);

            // while (posDictionary.ContainsKey(oktaWidth) && oktaHeight == posDictionary[oktaWidth]) {
            //     oktaWidth = Random.Range(-width + 1, width - 3);
            //     oktaHeight = Random.Range(-height, height - 1);
            // }

            // posDictionary.Add(oktaWidth, oktaHeight);

            Vector3 pos = new Vector3(oktaWidth, oktaHeight, 0f);

            Instantiate(okta, pos, transform.rotation);
            // okta.tag = "Okta";
            // oktaList.Add(okta);

            counter ++;
        }
    }
}
