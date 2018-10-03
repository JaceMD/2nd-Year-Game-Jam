using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedWatchScript : MonoBehaviour {

	Vector3 resetPos;
	public Transform pos1;
	public Transform pos2;
	public Transform pos3;
	public Transform pos4;
	public Transform pos5;
	public Transform pos6;
	public Transform pos7;
	public Transform pos8;
	public Transform pos9;
	public Transform pos10;
	public Transform pos11;
	public Transform pos12;
	public Transform pos13;
	public Transform pos14;
	public Transform pos15;
	public Transform pos16;

	public GameObject nunAI;

	// Use this for initialization
	void Start () {
		resetPos = new Vector3 (0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nextBed ()
	{
		print (transform.position);
		if (transform.position == resetPos) {
			transform.position = pos1.position;
		}
		else
			if (transform.position == pos1.position) {
				transform.position = pos2.position;
		}
		else
				if (transform.position == pos2.position) {
					transform.position = pos3.position;
			}
			else
					if (transform.position == pos3.position) {
						transform.position = pos4.position;
				}
				else
						if (transform.position == pos4.position) {
							transform.position = pos5.position;
					}
					else
							if (transform.position == pos5.position) {
								transform.position = pos6.position;
						}
						else
								if (transform.position == pos6.position) {
									transform.position = pos7.position;
							}
							else
									if (transform.position == pos7.position) {
										transform.position = pos8.position;
								}
								else
										if (transform.position == pos8.position) {
											transform.position = pos9.position;
									}
									else
											if (transform.position == pos9.position) {
												transform.position = pos10.position;
										}
										else
												if (transform.position == pos10.position) {
													transform.position = pos11.position;
											}
											else
													if (transform.position == pos11.position) {
														transform.position = pos12.position;
												}
												else
														if (transform.position == pos12.position) {
															transform.position = pos13.position;
													}
													else
															if (transform.position == pos13.position) {
																transform.position = pos14.position;
														}
														else
																if (transform.position == pos14.position) {
																	transform.position = pos15.position;
															}
															else
																	if (transform.position == pos15.position) {
																		transform.position = pos16.position;
																}
																else
																		if (transform.position == pos16.position) {
																		nunAI.GetComponent<NunScript> ().endSuspicion ();
																		transform.position = resetPos;
																	}
	}
}
