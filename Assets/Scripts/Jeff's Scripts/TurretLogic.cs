using UnityEngine;
using System.Collections;

public class TurretLogic : MonoBehaviour {
    public float Sight;
    public float BulletSpeed;
    float ShotTime;
    public float SecBetweenShot;
    public GameObject TargetedEnemy;
    public GameObject BulletPrefab;
    public bool EnemyInSight;
    bool Initialized;
	// Use this for initialization
	void Start () {
        Initialized = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Initialized = true;
        }
        if (Initialized)
        {
            foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (Vector3.Distance(this.transform.position, Enemy.transform.position) <= Sight)
                {
                    TargetedEnemy = Enemy;
                    EnemyInSight = true;
                    break;
                }
            }

            if (EnemyInSight)
            {
                this.transform.LookAt(TargetedEnemy.transform);
                ShotTime += Time.deltaTime;
                if (ShotTime >= SecBetweenShot)
                {
                    Shoot();
                    ShotTime = 0;
                }
            }
        }
	}

    void Shoot()
    {
        GameObject Bullet;
        Bullet = Instantiate(BulletPrefab) as GameObject;
        Bullet.transform.position = this.gameObject.transform.position;
        Bullet.transform.rotation = this.gameObject.transform.rotation;
    }
}
