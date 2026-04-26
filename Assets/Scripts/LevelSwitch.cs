using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadLevel0()
    {
        LoadLevel("TitleScreenArea");
    }
    public void LoadLevel1()
    {
        LoadLevel("Level1");
    }
    public void LoadLevel2()
    {
        LoadLevel("Level2");
    }
    public void LoadLevel3()
    {
        LoadLevel("Level3");
    }

}
