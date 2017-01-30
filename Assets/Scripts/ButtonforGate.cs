using UnityEngine;
using System.Collections;

public class ButtonforGate: MonoBehaviour {
	public GameObject gate;
	public bool isStateless;
	public bool destroyed;
	// Use this for initialization
	void Start () {
		if (destroyed) {
			gate.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			if (!isStateless) {
				if (!destroyed) {
					destroyed = !destroyed;
					gate.SetActive (false);
				}
				else{
					destroyed = !destroyed;
					Debug.Log ("Setactive = true");
					gate.SetActive(true);
				}
			}
			else {
				Destroy(gate);
				Destroy (gameObject);
			}

		}

	}
}
