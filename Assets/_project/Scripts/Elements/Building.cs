using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;

    public void StartBuilding()
    {
        foreach (var s in spriteRenderers)
        {
            s.color = new Color(1,1,1,UnityEngine.Random.Range(.3f,1f));
        }
    }
}
