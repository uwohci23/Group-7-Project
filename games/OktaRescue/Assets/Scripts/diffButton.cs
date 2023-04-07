using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class diffButton : MonoBehaviour
{
    public Button easy;
    public Button medium;
    public Button difficult;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = easy.GetComponent<Button>();
		btn.onClick.AddListener(EasyTaskOnClick);
        btn = medium.GetComponent<Button>();
		btn.onClick.AddListener(MediumTaskOnClick);
        btn = difficult.GetComponent<Button>();
		btn.onClick.AddListener(DiffTaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void EasyTaskOnClick(){
        PlayerPrefs.SetString("difficulty", "easy");
        SceneManager.LoadScene(sceneName);
    }
    
    void MediumTaskOnClick(){
        PlayerPrefs.SetString("difficulty", "medium");
        SceneManager.LoadScene(sceneName);
    }
    
    void DiffTaskOnClick(){
        PlayerPrefs.SetString("difficulty", "difficulty");
        SceneManager.LoadScene(sceneName);
    }

}
