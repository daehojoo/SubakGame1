using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LobbyUiManager : MonoBehaviour
{

    public void LobbyBtn()
    {
        SceneManager.LoadScene("LobbyScene");

    }
    public void GameSceneBtn()
    {
        SceneManager.LoadScene("GameScene");

    }









}
