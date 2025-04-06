using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public bool isActive;
    public float sensitivity;
    public float zoomSensitivity;
    public float panSensitivity;
    public bool invertRotateDirection;
    public float rotationLimit;
    public float zoomInLimit;
    public float zoomOutLimit;
    public bool alwaysZoomToObject;

    public Camera mainCamera;

    private float _yRotation;
    private float _xSlide;
    private float _ySlide;

    void Update()
    {
        if (isActive)
        {
            if (Input.GetMouseButton(0))
            {
                var sign = -1;
                if (invertRotateDirection)
                {
                    sign = +1;
                }
                _yRotation += Input.GetAxis("Mouse X") * sensitivity;
                _yRotation = Mathf.Clamp(sign * _yRotation, -rotationLimit, rotationLimit);
                transform.rotation = Quaternion.Euler(0, _yRotation, 0);
            }
            var mouseWheelAction = Input.GetAxis("Mouse ScrollWheel");
            if (mouseWheelAction < 0 || mouseWheelAction > 0)
            {
                var zoomAmount = mouseWheelAction * zoomSensitivity;
                //mainCamera.transform.position += mainCamera.transform.forward * zoomAmount;
                var direction = transform.position - mainCamera.transform.position;
                var directionNormalized = direction.normalized;

                if (direction.magnitude > zoomOutLimit && zoomAmount < 0)
                {
                    zoomAmount = 0;
                }
                else if (direction.magnitude < zoomInLimit && zoomAmount > 0)
                {
                    zoomAmount = 0;
                }
                mainCamera.transform.position += directionNormalized * zoomAmount;
            }
            if (Input.GetMouseButton(2))
            {
                _xSlide = -Input.GetAxis("Mouse X") * panSensitivity;
                _ySlide = -Input.GetAxis("Mouse Y") * panSensitivity;

                if (alwaysZoomToObject)
                {
                    mainCamera.transform.position += _xSlide * transform.right + _ySlide * transform.up;
                }
                else
                {
                    transform.position += _xSlide * mainCamera.transform.right + _ySlide * mainCamera.transform.up;
                }
            }
        }        
    }
}
