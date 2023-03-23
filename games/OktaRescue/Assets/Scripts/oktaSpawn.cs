using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oktaSpawn : MonoBehaviour
{
    public GameObject okta;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(okta, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
