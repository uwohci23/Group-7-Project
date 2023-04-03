using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowManager : MonoBehaviour {
	public GameObject cowPrefab, fencePrefab;
	public List<GameObject> cows, selectedCows;

	public Vector2 groupPos = new Vector2(-17f, 4f);
	public float groupX = 1.65f;
	public float groupY = 1f;
	public float groupSpacing = 5f;
	public float leftBoundary = 1.5f;
	public float rightBoundary = 6f;
	public int maxCows = 30;
	public int minCows = 10;

	private void Start() {
		cows = new List<GameObject>();
		selectedCows = new List<GameObject>();

		int cowNum = Random.Range(minCows, maxCows + 1);
		float height = Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
		height -= 1f;

		for (int i = 0; i < cowNum; i++) {
			Vector3 pos = new Vector3(Random.Range(-width + leftBoundary, width - rightBoundary), Random.Range(-height, -1f), 0f);
			GameObject cowObj = Instantiate(cowPrefab, pos, Quaternion.identity);
			cows.Add(cowObj);
			Cow cow = cowObj.GetComponent<Cow>();
			cow.cowManager = this;
			cow.leftBoundary = leftBoundary;
			cow.rightBoundary = rightBoundary;
		}
	}

	public void Select(GameObject cow, bool isSelected) {
		if (isSelected)
			selectedCows.Add(cow);
		else
			selectedCows.Remove(cow);
	}

	public void MoveSelected() {
		foreach (GameObject selectedCow in selectedCows) {
			Cow cow = selectedCow.GetComponent<Cow>();
			cow.Move();
		}
	}

	public void CheckSelected() {
		foreach (GameObject selectedCow in selectedCows) {
			Cow cow = selectedCow.GetComponent<Cow>();
			cow.Check();
		}
	}

	public bool Field() {
		if (cows.Count > 4 || cows.Count - selectedCows.Count > 0)
			return false;
		else {
			Group();
			return true;
		}
	}

	public void GroupButton() {
		if (selectedCows.Count == 5) {
			Group();
		}
	}

	private void Group() {
		Vector2 oldGroupPos = groupPos;
		foreach (GameObject selectedCow in selectedCows) {
			selectedCow.GetComponent<Cow>().Mooove(groupPos);
			cows.Remove(selectedCow);

			groupPos.x += groupX;
			groupPos.y += groupY;
		}

		selectedCows.Clear();

		Instantiate(fencePrefab, oldGroupPos, Quaternion.identity);

		groupPos = oldGroupPos;
		groupPos.x += groupSpacing;
	}

	public void CheckButton() {
		if (cows.Count == 0) {
			Debug.Log("GG");
		}
	}
}
