using UnityEngine;
using System.Collections;

public class StoreLogic : MonoBehaviour {
    public GameObject StoreCan;
    public GameObject Player;
    public GameObject Store;
    public GameObject TurretPrefab;
    public GameObject Turret;
    public float MaxDist;
    public bool Creating;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(Player.transform.position, Store.transform.position) <= MaxDist)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StoreCan.SetActive(true);
            }
        }
        else
        {
            StoreCan.SetActive(false);
        }

        if (StoreCan.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StoreCan.SetActive(false);
            }
        }

        if (Creating)
        {
            Turret.transform.position = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
            Turret.transform.position = new Vector3(Mathf.Clamp(Turret.transform.position.x, -6.59f, 6.59f), Mathf.Clamp(Turret.transform.position.y, -4.56f, 4.56f), Turret.transform.position.z);
            
            if (Input.GetMouseButtonDown(0))
            {
                Turret.transform.position = Turret.transform.position;
                Creating = false;
            }
             
        }
	}

    public void CreateTurret()
    {
        StoreCan.SetActive(false);
        Creating = true;
        Turret = Instantiate(TurretPrefab) as GameObject;
    }
}
