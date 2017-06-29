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

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

		if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 camPos = transform.position;

        camPos.y -= scroll * scollMultiplier * scrollSpeed * Time.deltaTime;
        camPos.y = Mathf.Clamp(camPos.y, minY, maxY);

        transform.position = camPos;
    }
}
