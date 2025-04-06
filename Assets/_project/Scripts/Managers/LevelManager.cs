using System;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    public GameDirector gameDirector;

    public Building buildingSpritePrefab;
    public Obstacle obstaclePrefab;

    public int count;
    public float distanceBetweenBuildings;

    public int obstacleCount;
    public float distanceBetweenObstacles;
    public float obstacleStartOffset;

    public LayerMask layerMask;

    public void RestartLevelManager()
    {
        DeleteCurrentLevel();
        CreateNewLevel();
    }    
    private void DeleteCurrentLevel()
    {
        GetCurrentLevel();
    }

    private void GetCurrentLevel()
    {
        
    }

    private void CreateNewLevel()
    {
        for (int i = 0; i < count; i++)
        {
            var newBuilding = Instantiate(buildingSpritePrefab);
            newBuilding.transform.position = new Vector3(i * distanceBetweenBuildings,
                UnityEngine.Random.Range(-2f,2f),2);
            newBuilding.StartBuilding();
        }

        for (int i = 0; i < obstacleCount; i++)
        {
            var newObstacle = Instantiate(obstaclePrefab);
            newObstacle.transform.position = new Vector3(obstacleStartOffset 
                + i * distanceBetweenObstacles, 5, 0);
            newObstacle.StartObstacle(i);
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, .5f, layerMask))
        {
            print(hit.point);
        }
    }   
}
