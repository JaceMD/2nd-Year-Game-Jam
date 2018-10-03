using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedManagerScript : MonoBehaviour {

	int itemPlacement = 0;
	int itemPlaced_1 = 0;
	int itemPlaced_2 = 0;
	int itemPlaced_3 = 0;
	int itemPlaced_4 = 0;
	int playerBed = 0;

	// Use this for initialization
	void Start () {

		itemPlacement = Random.Range (1, 17);
		playerBed = itemPlacement;

		do{
			itemPlacement = Random.Range(1,17);
		}while(itemPlacement == playerBed);
			
		itemPlaced_1 = itemPlacement;

		do{
			itemPlacement = Random.Range(1,17);
		}while(itemPlacement == playerBed||itemPlacement == itemPlaced_1);

		itemPlaced_2 = itemPlacement;

		do{
			itemPlacement = Random.Range(1,17);
		}while(itemPlacement == playerBed||itemPlacement == itemPlaced_1 || itemPlacement == itemPlaced_2);

		itemPlaced_3 = itemPlacement;

		do{
			itemPlacement = Random.Range(1,17);
		}while(itemPlacement == playerBed||itemPlacement == itemPlaced_1 || itemPlacement == itemPlaced_2 || itemPlacement == itemPlaced_3);

		itemPlaced_4 = itemPlacement;


		print ("Player bed at "+ playerBed);
		print ("Item 1 at "+itemPlaced_1);
		print ("Item 2 at "+itemPlaced_2);
		print ("Item 3 at "+ itemPlaced_3);
		print ("Item 4 at "+itemPlaced_4);


		GameObject.Find ("Bed_" + playerBed).GetComponent<BedScript>().setPlayerBed();
		GameObject.Find ("Bed_" + itemPlaced_1).GetComponent<BedScript>().setItem_1();
		GameObject.Find ("Bed_" + itemPlaced_2).GetComponent<BedScript>().setItem_2();
		GameObject.Find ("Bed_" + itemPlaced_3).GetComponent<BedScript>().setItem_3();
		GameObject.Find ("Bed_" + itemPlaced_4).GetComponent<BedScript>().setItem_4();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
