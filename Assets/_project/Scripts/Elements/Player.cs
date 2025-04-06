using System;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public Transform cameraHolder;
    public float forwardSpeed;
    public float navigationSpeed;

    public void RestartPlayer()
    {

    }

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * forwardSpeed;

        cameraHolder.transform.position = new Vector3(transform.position.x, 5, 0);

        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector3.down;
        }

        transform.position += direction.normalized * Time.deltaTime * navigationSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
        }
    }
}
