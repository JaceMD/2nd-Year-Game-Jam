using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchProgress : MonoBehaviour {


	public Transform progressBar;
	[SerializeField] float currentAmount;
	[SerializeField] float speed = 1;

	public GameObject player;
	public bool looking;
	public bool found;

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
		currentAmount = 0;
		looking = false;
		found = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (looking) {
			currentAmount += speed;
		}

		if (currentAmount >= 100) {
			currentAmount = 100;
			found = true;
			looking = false;
		}

		if (found) {
			player.GetComponent<PlayerScript> ().objectFound ();
			found = false;
		}

		progressBar.GetComponent<Image> ().fillAmount = currentAmount / 100;

	}
		
	public void search()
	{
		looking = true;
		this.gameObject.SetActive (true);
	}

	public void stopSearch()
	{
		looking = false;
		currentAmount = 0;
		this.gameObject.SetActive (false);
	}
}
