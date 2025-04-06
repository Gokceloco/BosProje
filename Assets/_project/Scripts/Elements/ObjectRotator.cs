using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public bool isActive;
    public float sensitivity;
    public bool invertRotateDirection;


    private float _yRotation;

    void Update()
    {
        if (isActive && Input.GetMouseButton(0))
        {
            var sign = -1;
            if (invertRotateDirection)
            {
                sign = +1;
            }
            _yRotation += Input.GetAxis("Mouse X") * sensitivity;
            transform.rotation = Quaternion.Euler(0, sign * _yRotation, 0);
        }                
    }
}
