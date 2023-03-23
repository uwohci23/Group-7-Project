using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowManager : MonoBehaviour {
	public GameObject cowPrefab;
	public List<GameObject> cows, selectedCows;

	public int maxCows = 25;

	private void Start() {
		cows = new List<GameObject>();
		selectedCows = new List<GameObject>();

		int cowNum = Random.Range(5, maxCows + 1);
		float height = Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
		height -= 1f;
		width -= 1f;

		for (int i = 0; i < cowNum; i++) {
			Vector3 pos = new Vector3(Random.Range(-width, width), Random.Range(-height, -1f), 0f);
			GameObject cow = Instantiate(cowPrefab, pos, Quaternion.identity);
			cows.Add(cow);
			cow.GetComponent<Cow>().cowManager = this;
		}
	}

	private void Update() {

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
}
