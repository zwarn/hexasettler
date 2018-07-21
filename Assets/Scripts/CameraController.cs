using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    float scrollSpeed = 4f;
    
	void Update () {
        Vector3 delta = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * scrollSpeed;
        this.GetComponent<Camera>().transform.Translate(delta);
	}
}
