using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void quitAppBtn() {
		//Application.Quit ();
        System.Diagnostics.Process.GetCurrentProcess().Kill();

}
}
