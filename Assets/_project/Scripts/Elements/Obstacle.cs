using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform meshTransform;

    public float maxJitter;

    public void StartObstacle(int i)
    {
        maxJitter += i / 5;
        var randomizer = Random.value;
        if (randomizer < .4f)
        {
            meshTransform.transform.localScale = new Vector3(Random.Range(1, maxJitter), 1, 1);
        }
        else if (randomizer < .8f)
        {
            meshTransform.transform.localScale = new Vector3(1, Random.Range(1, maxJitter), 1);
        }
        else
        {
            meshTransform.transform.localScale = Vector3.one * Random.Range(1, maxJitter);
        }
        meshTransform.position = new Vector3(meshTransform.position.x, Random.Range(0,10), 0);

    }
}
