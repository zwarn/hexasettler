using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    float scrollSpeed = 4f;
    float zoomSpeed = 100f;
    
	void Update () {
        Camera camera = this.GetComponent<Camera>();

        Vector3 delta = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * scrollSpeed;
        camera.transform.Translate(delta);

        float deltaZoom = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed * -1;
        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize + deltaZoom, 2f, 50f);

    }
}
