using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {
    public float BulletSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().velocity = this.gameObject.transform.forward * BulletSpeed;
	}

    void OnTriggerEnter2D(Collider2D Col)
    {
        Destroy(this.gameObject);
    }
}
