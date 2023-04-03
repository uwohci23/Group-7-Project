using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CowManager : MonoBehaviour {
	public GameObject cowPrefab, fencePrefab;
	public List<GameObject> cows, selectedCows;
	private int cowNum;

	public GameObject tallyMark, tallyGroup;
	public List<GameObject> tallies, tallyGroups;
	public Vector2 tallyPos = new Vector2(14f, 8f);
	public float tallyX = 3f;
	public float tallyY = 2f;
	public float tallySpacing = 0.535f;
	private int tallyCount = 0;

	public GameObject groupButton, checkButton, popupText, checkBox;
	public TMP_InputField checkField;
	public bool isChecking = false;
	public string groupText, checkText, correctText, wrongText;

	public float popupTime = 6f;

	public Vector2 groupPos = new Vector2(-17f, 4f);
	public float groupX = 1.65f;
	public float groupY = 1f;
	public float groupSpacing = 5f;
	public float leftBoundary = 1.5f;
	public float rightBoundary = 6f;
	public float bottomBoundary = 1.5f;
	public int maxCows = 30;
	public int minCows = 10;

	private void Start() {
		cows = new List<GameObject>();
		selectedCows = new List<GameObject>();

		tallies = new List<GameObject>();
		tallyGroups = new List<GameObject>();

		cowNum = Random.Range(minCows, maxCows + 1);
		float height = Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
		height -= bottomBoundary;
		tallyPos.x = width - 5.25f;
		groupPos.x = -width + leftBoundary * 1.5f;

		for (int i = 0; i < cowNum; i++) {
			Vector3 pos = new Vector3(Random.Range(-width + leftBoundary, width - rightBoundary), Random.Range(-height, -bottomBoundary), 0f);

			do
				pos = new Vector3(Random.Range(-width + leftBoundary, width - rightBoundary), Random.Range(-height, -bottomBoundary), 0f);
			while (Physics2D.OverlapBoxAll(pos, Vector2.one * 1.25f, 0f).Length > 0);

			GameObject cowObj = Instantiate(cowPrefab, pos, Quaternion.identity);
			cows.Add(cowObj);

			Cow cow = cowObj.GetComponent<Cow>();
			cow.cowManager = this;

			cow.leftBoundary = leftBoundary;
			cow.rightBoundary = rightBoundary;
			cow.bottomBoundary = bottomBoundary;
		}
	}

	private void Update() {
		if (isChecking && Input.GetKeyDown(KeyCode.Return))
			CheckAnswer();
	}

	public void Select(GameObject cow, bool isSelected) {
		if (isSelected) {
			selectedCows.Add(cow);

			tallyCount++;

			if (!tallies.Any() || tallyCount % 5f != 0) {
				tallies.Add(Instantiate(tallyMark, tallyPos, Quaternion.identity));
				tallyPos.x += tallySpacing;
			}
			else {
				tallyPos.x -= tallySpacing * 4f;

				foreach (GameObject tally in tallies)
					Destroy(tally);

				tallies.Clear();
				tallyGroups.Add(Instantiate(tallyGroup, tallyPos, Quaternion.identity));

				if (tallyCount % 10f == 0) {
					tallyPos.x -= tallyX;
					tallyPos.y -= tallyY;
				}
				else
					tallyPos.x += tallyX;
			}
		}
		else {
			selectedCows.Remove(cow);

			if (tallyCount % 5f == 0) {
				if (tallyCount % 10f == 0) {
					tallyPos.x += tallyX;
					tallyPos.y += tallyY;
				}
				else
					tallyPos.x -= tallyX;

				Destroy(tallyGroups.Last());
				tallyGroups.RemoveAt(tallyGroups.Count - 1);
				
				for (int i = 0; i < 4; i++) {
					tallies.Add(Instantiate(tallyMark, tallyPos, Quaternion.identity));
					tallyPos.x += tallySpacing;
				}
			}
			else {
				tallyPos.x -= tallySpacing;

				Destroy(tallies.Last());
				tallies.RemoveAt(tallies.Count - 1);
			}			

			tallyCount--;
		}
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
		if (selectedCows.Count == 5)
			Group();
		else
			StartCoroutine(ShowPopupText(groupText));
	}

	private void Group() {
		Vector2 oldGroupPos = groupPos;

		foreach (GameObject selectedCow in selectedCows) {
			selectedCow.GetComponent<Cow>().Mooove(groupPos);
			cows.Remove(selectedCow);

			groupPos.x += groupX;
			groupPos.y += groupY;
		}

		Instantiate(fencePrefab, oldGroupPos, Quaternion.identity);

		selectedCows.Clear();

		groupPos = oldGroupPos;
		groupPos.x += groupSpacing;
	}

	public void CheckButton() {
		if (cows.Count == 0) {
			StopAllCoroutines();
			popupText.SetActive(false);
			Destroy(groupButton);
			Destroy(checkButton);
			checkBox.SetActive(true);
			isChecking = true;
		}
		else
			StartCoroutine(ShowPopupText(checkText));
	}

	public void CheckAnswer() {
		if (int.Parse(checkField.text) == cowNum) {
			isChecking = false;
			Destroy(checkBox);
			StartCoroutine(ShowPopupText(correctText));
		}
		else
			StartCoroutine(ShowPopupText(wrongText));
	}

	private IEnumerator ShowPopupText(string text) {
		popupText.GetComponent<TextMeshProUGUI>().text = text;
		popupText.SetActive(true);

		yield return new WaitForSeconds(popupTime);

		popupText.SetActive(false);
	}
}
