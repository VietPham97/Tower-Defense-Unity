using UnityEngine;

public class CameraController : MonoBehaviour 
{
    bool isMoving = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

	const float scollMultiplier = 1000f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isMoving = !isMoving;
        
        if (!isMoving) return;
		
        Vector3 camPos = transform.position;

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            Vector3 panDir = Vector3.forward;
            camPos.z += panDir.magnitude * panSpeed * Time.deltaTime;
            camPos.z = Mathf.Min(camPos.z, 35f);
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            Vector3 panDir = Vector3.back;
			camPos.z -= panDir.magnitude * panSpeed * Time.deltaTime;
            camPos.z = Mathf.Max(camPos.z, -40f);
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            Vector3 panDir = Vector3.right;
            camPos.x += panDir.magnitude * panSpeed * Time.deltaTime;
            camPos.x = Mathf.Min(camPos.x, 30f);
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            Vector3 panDir = Vector3.left;
			camPos.x -= panDir.magnitude * panSpeed * Time.deltaTime;
            camPos.x = Mathf.Max(camPos.x, -30f);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        camPos.y -= scroll * scollMultiplier * scrollSpeed * Time.deltaTime;
        camPos.y = Mathf.Clamp(camPos.y, minY, maxY);

        transform.position = camPos;
    }
}
