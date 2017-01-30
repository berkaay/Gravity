using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int curHealth;
	public int maxHealth = 1;
	public bool grounded = true; 

	// Use this for initialization
	void Start () {
		

		curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (curHealth <= 0) {
			Die ();
		}


	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag("Plane")) {
			Debug.Log("grounded");
		}
	}

	public void Damage(int damageAmount){
		curHealth -= damageAmount;
	
	}

	void Die(){
		NextLevel.RestartLevel();
	}
}
