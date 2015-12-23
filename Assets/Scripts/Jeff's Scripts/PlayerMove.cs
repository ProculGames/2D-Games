using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    public GameObject Player;
    public Rigidbody2D PlayerRigid;
    public float Movespeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x, Movespeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x, -Movespeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerRigid.velocity = new Vector2(-Movespeed, PlayerRigid.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerRigid.velocity = new Vector2(Movespeed, PlayerRigid.velocity.y);
        }
	}
}
