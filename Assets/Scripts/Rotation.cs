using UnityEngine;
using System.Collections;
using UnityEngine.Events;


public class Rotation : MonoBehaviour {
	private float timer;
	private int playerAngle = 0;
	public GameObject player;
	private int rotated;
	private static bool isVertical = false;
	public enum State{
		Normal = 0 ,
		Rotating = 1 ,
		HasRotated = 2
	}

	public State MyState = new State();

	public delegate void BoolDel(bool p_bool);
	public event BoolDel BoolEvent;

	public delegate void Vec3Del(Vector3 p_Vector);
	public event Vec3Del RotEvent;

	public static Rotation instance;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		MyState = State.Normal;
		timer = 0;
		StartCoroutine (Rotator ());
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}


	public IEnumerator Rotator (){
		while (true) { 
			yield return new WaitForSeconds(1.4f);
			float timer = 0.5f;
			Physics2D.gravity = Vector3.zero;
			//For Platform
			Quaternion startAngle = transform.rotation;
			Quaternion endAngle = Quaternion.LookRotation (Vector3.forward, transform.right);
			//For Player
			Quaternion endAnglePlayer = Quaternion.LookRotation (Vector3.forward );
			BoolEvent.Invoke (false);
			
			while (timer > 0) {
				transform.rotation = Quaternion.Lerp (startAngle, endAngle, (0.5f - timer)*2);
				player.transform.rotation = Quaternion.Lerp (startAngle, endAnglePlayer, (0.5f - timer) * 2);
				timer -= Time.deltaTime;

				yield return null;
			}	
			transform.rotation = endAngle;	
			player.transform.rotation = endAnglePlayer;
			isVertical = !isVertical;
			Physics2D.gravity = new Vector3 (0, -9.81f, 0);
			BoolEvent.Invoke (true);


			yield return null;
		}
	}

	public static bool GetIsVertical(){
		return isVertical;
	}

}
