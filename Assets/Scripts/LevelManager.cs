using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform train;
    public GameObject[] levels;

    private int currentLevel;

    void Awake()
    {
        NextLevel();
    }

    void NextLevel()
    {
        GameObject level = Instantiate(levels[currentLevel]);
        level.GetComponent<WaveManager>().train = train;
        level.GetComponent<WaveManager>().endLevel.AddListener(EndLevel);
    }

    void EndLevel()
    {
        if (currentLevel < levels.Length - 1)
        {
            currentLevel++;
            NextLevel();
        }
    }
}
