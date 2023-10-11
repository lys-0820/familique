using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Transform target;
    public float zoomLevel = 50f;
    public float zoomSpeed = 5f;
    public float rotationSpeed = 5f;

    private void Update()
    {
        // 缩放相机
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoomLevel -= scroll * zoomSpeed;
        zoomLevel = Mathf.Clamp(zoomLevel, 10f, 100f);
        mainCamera.fieldOfView = zoomLevel;

        // 聚焦到目标
        if (Input.GetMouseButton(0))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
            float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed;

            target.rotation *= Quaternion.Euler(rotationY, rotationX, 0f);
        }
    }
}
