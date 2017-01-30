using UnityEngine;
using System.Collections;

public class DontGoThroughThings : MonoBehaviour
{
	
	//private Rigidbody myRigidbody;
	private Player player; 
	private Vector3 pos;
	private float yAxis,xAxis,negYAxis,negXAxis;

	//initialize values 
	void Start(){
		
	//	myRigidbody = GetComponent<Rigidbody>();
		player = GetComponent<Player> ();

	
	} 

	void FixedUpdate() {
		pos = player.transform.position;
		if (Rotation.GetIsVertical ()) {
			yAxis = 5.53f;
			xAxis = 2.03f;
			negYAxis = -3.53f;
			negXAxis = -2.03f;
		} else {
			yAxis = 3f;
			xAxis = 4.53f;
			negYAxis = -1f;
			negXAxis = -4.53f;
		}

		if (pos.x < negXAxis) { 
			player.transform.position = new Vector3 (negXAxis, pos.y, pos.z);
		}
		if (pos.y < negYAxis) { 
			player.transform.position = new Vector3 (pos.x, negYAxis, pos.z);
		}
		if (pos.y > xAxis) { 
			player.transform.position = new Vector3 (pos.x, xAxis, pos.z);
		}

		if (pos.x > yAxis) { 
			player.transform.position = new Vector3 (yAxis, pos.y, pos.z);
		}
	} 
}
