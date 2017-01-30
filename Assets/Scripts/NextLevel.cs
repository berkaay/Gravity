using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	private static Scene scene ;

	void Start () {
		scene = SceneManager.GetActiveScene();	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			SceneManager.LoadScene (scene.buildIndex+1);
			Debug.Log ("Next Level");
		}
	}

	public static void GoToNextLevel(){
		SceneManager.LoadScene(scene.buildIndex + 1);
	}

	public static void RestartLevel(){
		SceneManager.LoadScene(scene.buildIndex);
	}
}
	