using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
	public float mouseSensitivity = 1000;
    private float xRotation;

    private void Start()
    {
        xRotation = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        //get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //inverted on x axis
        xRotation -= mouseY;

        //xRotation should not ever be bigger than 90, or less than 90
       xRotation = Mathf.Clamp(xRotation, -90, 90);

        //rotate player around y axis, camera around x axis
        transform.parent.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

}
