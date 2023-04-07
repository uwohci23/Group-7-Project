using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class oktaSpawn : MonoBehaviour
{
    public GameObject okta;
    public GameObject oktaOutline;
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


    public void generateOkta(int oktaNum)
    {
        float height = Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;
        height -= 1f;
        width -= 1f;
        int counter = 0;

        while (counter < oktaNum)
        {

            Vector2 pos;
            do
            {
                float oktaWidth = Random.Range(-width + 1f, width - 3.5f);
                float oktaHeight = Random.Range(-height, height - 1f);
                pos = new Vector2(oktaWidth, oktaHeight);

            } while (Physics2D.OverlapCircleAll(pos, 1f).Length > 0);
            // okta is a PREFAB!!!!
            GameObject oktaObj = Instantiate(okta, pos, transform.rotation);
            oktaList.Add(oktaObj);

            counter++;
        }
    }

    public void generateOutlineOkta(int needToSave)
    {
        Vector2 initalPos = new Vector2(7f, 3f);
        Vector2 pos = initalPos;
        float addX = 1.5f;
        float addY = -1.5f;

        for (int i = 0; i < needToSave; i++)
        {
            if (i % 2 == 0 && i != 0)
            {
                pos = new Vector2(initalPos.x, initalPos.y + addY * (i / 2));
            }
            else if (i % 2 == 1)
            {
                pos = new Vector2(initalPos.x + addX, initalPos.y + addY * (i / 2));
            }
            else
            {
                pos = initalPos;
            }

            Instantiate(oktaOutline, pos, transform.rotation);

        }

    }
}
