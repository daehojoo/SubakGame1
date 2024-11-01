using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public Image Image;

    public void Start()
    {
        
        
    }
    public void Update() { }

    public void RestartBtnClick()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void LevelEasy()
    {
        GameManager.Instance.SetDifficulty(1); // Easy 난이도 설정
        Image.gameObject.SetActive(false);
    }

    public void LevelNormal()
    {
        GameManager.Instance.SetDifficulty(2); // Normal 난이도 설정
        Image.gameObject.SetActive(false);

    }

    public void LevelHard()
    {
        GameManager.Instance.SetDifficulty(3); // Hard 난이도 설정
        Image.gameObject.SetActive(false);

    }
}
