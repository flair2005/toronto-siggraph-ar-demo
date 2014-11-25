using UnityEngine;
using System.Collections;

public class AssetAnimation : MonoBehaviour {

	public float fromValue;
	public float toValue;

	public MeshCollider collider;
	private bool isEnable; 
	private bool preventAction; 

	// Use this for initialization
	void Start () {
		if (collider == null) {
			collider = transform.GetComponent<MeshCollider>();
		}

		isEnable = false;
		preventAction = false;
	}

	void OnEnable() {

	}

	void Update() {

		if (collider.enabled) {
			isEnable = true;
		} else {
			isEnable = false;	
		}

		if (isEnable && !preventAction) {
			preventAction = true; 
			AnimatePosition();
		} 

		if (!isEnable && preventAction) {
			preventAction = false;		
		}
	}

	void AnimatePosition() {
		Vector3 localPosition = transform.localPosition;
		localPosition.y = toValue;
		transform.localPosition = localPosition;
		
		Hashtable translateArgs = iTween.Hash 
			(	"from", fromValue, 
			 "to", toValue, 
			 "time", 3f, 
			 "delay", 0.4f,  
			 "onupdate", "UpdateTransform", 
			 "onupdatetarget", this.gameObject
			 );
		
		iTween.ValueTo (this.gameObject, translateArgs);
	}

	void OnDisable() {
		Vector3 localPosition = transform.localPosition;
		localPosition.y = fromValue;
		transform.localPosition = localPosition;
	}
	
	private void UpdateTransform(float value) {
		Vector3 position = transform.localPosition;
		position.y = value;
		
	}
}
