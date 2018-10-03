using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour {

	bool item_1;
	bool item_2;
	bool item_3;
	bool item_4;
	bool playerBed;


	// Use this for initialization
	void Start () {
		item_1 = false;
		item_2 = false;
		item_3 = false;
		item_4 = false;
		playerBed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setItem_1()
	{
		item_1 = true;
		print ("Item 1 placed here:" + this.gameObject.name);
	}

	public void setItem_2()
	{
		item_2 = true;
		print ("Item 2 placed here:" + this.gameObject.name);
	}

	public void setItem_3()
	{
		item_3 = true;
		print ("Item 3 placed here:" + this.gameObject.name);
	}

	public void setItem_4()
	{
		item_4 = true;
		print ("Item 4 placed here:" + this.gameObject.name);
	}

	public bool anyItems()
	{
		if (item_1 || item_2 || item_3 || item_4) {
			return true;
		}
		return false;
	}

	public void setPlayerBed()
	{
		playerBed = true;
		print ("PlayerBed placed here:" + this.gameObject.name);
	}

}
