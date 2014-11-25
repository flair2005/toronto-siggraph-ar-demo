using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("Entering mouse button down");
			try {
				Collider collider = GetRayCastHitCollider();
				PlayTrailerByName(collider.transform.name);
				Debug.Log (collider.transform.name);
			} catch (System.Exception nre) {
				Debug.Log (nre.StackTrace);
			}
		}
	}

	// Returns RayCastHit collider, if found. Otherwise, return null;
	Collider GetRayCastHitCollider() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit; 
		switch (Physics.Raycast (ray, out hit)) {
		case true:
			return hit.collider; 
		case false:
			return null;
		}
		
		return null;
		
	}

	void PlayTrailerByName( string name ) {
		StartCoroutine(PlayTrailer(name));
	}

	IEnumerator PlayTrailer( string name ) {

	#if !UNITY_EDITOR
		Handheld.PlayFullScreenMovie ("Trailers/" + name + ".mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	#endif

		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();

		Debug.Log ("Done Playing Movie");
	}
}
