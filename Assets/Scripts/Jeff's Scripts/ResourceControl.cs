using UnityEngine;
using System.Collections;

public class ResourceControl : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Tree")
        {
            Debug.Log("Hitting Tree.");
            PlayerPrefs.SetFloat("Wood", PlayerPrefs.GetFloat("Wood") + 5);
        }
    }
}
