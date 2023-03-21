using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour {
	private SpriteRenderer sr;

	private bool isDown = false;
	private bool isSelected = false;

	private void Start() {
		sr = GetComponent<SpriteRenderer>();
	}

	private void Update() {
		if (isDown) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.z = 0;
			transform.position = pos;
		}
	}

	private void Select() {
		isSelected = !isSelected;

		if (isSelected)
			sr.color = Color.black;
		else
			sr.color = Color.white;
	}

	private void OnMouseDown() {
		isDown = true;
	}

	private void OnMouseUp() {
		isDown = false;
		Select();
	}
}
