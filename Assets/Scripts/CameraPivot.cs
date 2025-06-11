using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    [Header("Camera Settings")]
    public float sensitivity = 120f;
    public float minClamp = -50f, maxClamp = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate our pivot point globally on y rotation, and locally on x rotation. Stops any rolling rotations.
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0, Space.World);
        transform.Rotate(-Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime, 0, 0, Space.Self);

        //Clamp the current x rotation to min-->max clamp
        //Ensure rotation is set to a minus -180-180 range instead of 0-360.
        float xRot = transform.eulerAngles.x;
        if(xRot > 180)
        {
            xRot -= 360;
        }
        xRot = Mathf.Clamp(xRot, minClamp, maxClamp);
        transform.eulerAngles = new Vector3(xRot, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
