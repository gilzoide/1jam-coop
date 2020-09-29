using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public ScoreInfo gameplayScoreInfo;
    public Object gameplayScene;

    public void StartGameplay()
    {
        gameplayScoreInfo.Reset();
        SceneManager.LoadScene(gameplayScene.name);
    }
}
