using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public LevelManager levelManager;
    public Player player;
    
    void Start()
    {
        RestartLevel();
    }

    private void RestartLevel()
    {
        player.RestartPlayer();
        levelManager.RestartLevelManager();
        
    }
}
