using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// OKTA OVERLAP EACH OTHER!!!
public class oktaSpawn : MonoBehaviour
{
    public GameObject okta;
    private int maxOkta = 20;
    private List<GameObject> oktaList;
    // Start is called before the first frame update
    void Start()
    {
        oktaList = new List<GameObject>();
        float height = Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
        height -= 1f;
		width -= 1f;

       	for (int i = 0; i < maxOkta; i++) {
            Debug.Log(i);
            Vector3 pos = new Vector3(Random.Range(-width + 1, width - 3), Random.Range(-height, height - 1), 0f);

            Instantiate(okta, pos, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
