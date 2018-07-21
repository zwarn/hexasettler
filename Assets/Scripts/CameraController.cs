using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    float keyScrollSpeed = 4f;
    float mouseScrollSpeed = 0.05f;
    float zoomSpeed = 100f;

    public Vector3 center;
    
	void Update () {
        Camera camera = this.GetComponent<Camera>();

        Vector3 delta = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * keyScrollSpeed;

        if (Input.GetMouseButtonDown(2))
        {
            center = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            delta += (center - Input.mousePosition) * Time.deltaTime * mouseScrollSpeed;
        }

        camera.transform.Translate(delta);

        float deltaZoom = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed * -1;
        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize + deltaZoom, 2f, 50f);
        
    }
}
