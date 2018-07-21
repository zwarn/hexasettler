using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour {

	
	void Start () {
		
	}

    private void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.9f, 0.9f);
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    }

}
