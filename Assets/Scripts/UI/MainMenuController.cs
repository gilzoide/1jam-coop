using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public ScoreInfo gameplayScoreInfo;

    public void StartGameplay()
    {
        gameplayScoreInfo.Reset();
        SceneManager.LoadScene("Gameplay");
    }
}
