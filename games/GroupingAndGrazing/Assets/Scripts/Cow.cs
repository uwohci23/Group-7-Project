using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cow : MonoBehaviour {
	public CowManager cowManager;

	private Camera main;
	private BoxCollider2D boxCollider2D;
	private SpriteRenderer sr;
	public Sprite cowSprite, selectedSprite, groupedSprite;

	private Vector3 mousePos, clickPos, groupPos;
	public float leftBoundary, rightBoundary, bottomBoundary;
	public float speed = 25f;
	private bool isDown = false;
	private bool isSelected = false;
	private bool isGrouping = false;

	private void Start() {
		main = Camera.main;
		boxCollider2D = GetComponent<BoxCollider2D>();

		sr = GetComponent<SpriteRenderer>();
		sr.flipX = Random.value > 0.5f;

		clickPos = transform.position;
	}

	private void Update() {
		if (isGrouping) {
			transform.position = Vector2.MoveTowards(transform.position, groupPos, speed * Time.deltaTime);

			if (transform.position == groupPos) {
				sr.sprite = groupedSprite;
				sr.flipX = true;
				Destroy(this);
			}
		}
		else if (isDown) {
			Vector3 mouseMovement = main.ScreenToWorldPoint(Input.mousePosition) - mousePos;
			mouseMovement.z = 0;
			transform.position = clickPos + mouseMovement;
		}
	}

	public void OnMouseDown() {
		if (!isGrouping) {
			Move();

			if (isSelected)
				cowManager.MoveSelected();
		}
	}

	private void OnMouseUp() {
		if (!isGrouping) {
			Select();
			Check();
			cowManager.CheckSelected();
		}
	}

	public void Move() {
		isDown = true;
		mousePos = main.ScreenToWorldPoint(Input.mousePosition);
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
		float height = Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;

		if (transform.position.x <= -width + leftBoundary || transform.position.x >= width - rightBoundary || transform.position.y <= -height + bottomBoundary)
			transform.position = clickPos;
		else {
			Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxCollider2D.size * 0.5f, 0f);

			foreach (Collider2D collider in colliders) {
				if (collider == boxCollider2D)
					continue;

				if (collider.gameObject.layer == LayerMask.NameToLayer("Field")) {
					if (!cowManager.Field())
						transform.position = clickPos;
				}
				else if (collider.gameObject.layer == LayerMask.NameToLayer("Cow"))
					transform.position = clickPos;
				else
					clickPos = transform.position;
			}
		}
	}

	public void Mooove(Vector2 groupPos) {
		this.groupPos = groupPos;
		isGrouping = true;
	}
}
