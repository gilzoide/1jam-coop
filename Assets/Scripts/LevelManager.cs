using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    public Transform train;
    public GameObject shop;
    public GameObject[] levels;

    private int currentLevel;
    private List<PlayerInput> players = new List<PlayerInput>();

    void Awake()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        GameObject level = Instantiate(levels[currentLevel]);
        level.GetComponent<WaveManager>().train = train;
        level.GetComponent<WaveManager>().endLevel.AddListener(OpenShop);
        SetActivePlayers(true);
    }

    void OpenShop()
    {
        if (currentLevel >= levels.Length - 1) return;

        SetActivePlayers(false);
        shop.SetActive(true);
        currentLevel++;
    }

    void SetActivePlayers(bool active)
    {
        foreach (var player in players)
        {
            player.enabled = active;
        }
    }

    void OnPlayerJoined(PlayerInput player)
    {
        players.Add(player);
    }
}
