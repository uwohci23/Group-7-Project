using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour {
	public CowManager cowManager;

	private BoxCollider2D boxCollider2D;
	private SpriteRenderer sr;
	public Sprite cowSprite, selectedSprite;

	private Vector3 mousePos, clickPos;
	private bool isDown = false;
	private bool isSelected = false;

	private void Start() {
		boxCollider2D = GetComponent<BoxCollider2D>();

		sr = GetComponent<SpriteRenderer>();
		sr.flipX = Random.value > 0.5f;

		clickPos = transform.position;
	}

	private void Update() {
		if (isDown) {
			Vector3 mouseMovement = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;
			mouseMovement.z = 0;
			transform.position = clickPos + mouseMovement;
		}
	}

	public void OnMouseDown() {
		Move();

		if (isSelected)
			cowManager.MoveSelected();
	}

	private void OnMouseUp() {
		Select();
		Check();
		cowManager.CheckSelected();
	}

	public void Move() {
		isDown = true;
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		clickPos = transform.position;
	}

	public void Check() {
		isDown = false;
		CheckOverlap();
	}

	private void Select() {
		if (isSelected && transform.position != clickPos)
			return;

		isSelected = !isSelected;
		cowManager.Select(gameObject, isSelected);

		sr.sprite = isSelected ? selectedSprite : cowSprite;
	}

	private void CheckOverlap() {
		Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxCollider2D.size * 0.5f, 0f);

		foreach (Collider2D collider in colliders) {
			if (collider == boxCollider2D)
				continue;

			if (collider.gameObject.layer == LayerMask.NameToLayer("Cow"))
				transform.position = clickPos;
			else
				clickPos = transform.position;
		}
	}
}
