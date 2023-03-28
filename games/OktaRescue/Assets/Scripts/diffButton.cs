using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class diffButton : MonoBehaviour
{
    public Button easy;
    // public Button medium;
    // public Button difficult;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = easy.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void TaskOnClick(){
        SceneManager.LoadScene(sceneName);

    }

}
