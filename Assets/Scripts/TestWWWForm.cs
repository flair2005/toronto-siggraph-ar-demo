using UnityEngine;
using System.Collections;

public class TestWWWForm : MonoBehaviour {
	string url = "http://toronto.siggraph.org/test";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ClickButton() {
		StartCoroutine (ConnectToServer());

	}

	IEnumerator ConnectToServer() {
		yield return new WaitForEndOfFrame ();

		WWWForm form = new WWWForm ();
		form.AddField ("action", "hello_world");
		form.AddField("info","dsffdsfs");
		
		WWW server = new WWW (url, form);
		
		yield return server;

		if (!string.IsNullOrEmpty (server.error)) {
			Debug.Log(server.error);
		} else {
			Debug.Log (server.text);
		}

		Debug.Log (server.url);
	}
}
