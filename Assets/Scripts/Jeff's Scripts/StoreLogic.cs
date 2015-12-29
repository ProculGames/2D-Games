using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreLogic : MonoBehaviour {
    public GameObject StoreCan;
    public GameObject Player;
    public GameObject Store;
    public GameObject TurretPrefab;
    public GameObject Turret;
    public float MaxDist;
    public float TurretWoodCost;
    public float Wood;
    public Text WoodTxt;
    public bool Creating;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetFloat("Wood", 13);
	}
	
	// Update is called once per frame
	void Update () {
        WoodTxt.text = Wood.ToString();
        Wood = PlayerPrefs.GetFloat("Wood");
        if (Vector3.Distance(Player.transform.position, Store.transform.position) <= MaxDist)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0;
                StoreCan.SetActive(true);
            }
        }
        else
        {
            StoreCan.SetActive(false);
        }

        if (StoreCan.activeInHierarchy)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                StoreCan.SetActive(true);
                Destroy(Turret);
                PlayerPrefs.SetFloat("Wood", PlayerPrefs.GetFloat("Wood") + TurretWoodCost);
            }
             
        }
	}

    public void CreateTurret()
    {
        if (PlayerPrefs.GetFloat("Wood") >= TurretWoodCost)
        {
            Time.timeScale = 1;
            StoreCan.SetActive(false);
            Creating = true;
            Turret = Instantiate(TurretPrefab) as GameObject;
            PlayerPrefs.SetFloat("Wood", PlayerPrefs.GetFloat("Wood") - TurretWoodCost);
        }
        else
        {
            Debug.Log("Not enough resources.");
        }
    }
}
