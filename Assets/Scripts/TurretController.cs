using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    private Transform _Player;
    public float dist;
    public float howClose;
    public Transform head;
    public Transform shootPos;
    public GameObject proyectil;
    public float cadDisp, nextDisp;
    public int fuerzaDisp = 500;
    public int ammo = 0;

    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(_Player.position, transform.position);
        if(dist <= howClose)
        {
            head.LookAt(_Player);
            if(Time.time >= nextDisp)
            {
                nextDisp = Time.time + 1f / cadDisp;
                Shoot();
            }
        }

    }

    void Shoot()
    {
        GameObject bala =  PoolManager.Instance.GetPooledObjects(ammo, head.position, head.rotation);             //Instantiate(proyectil, shootPos.position, head.rotation);
        bala.SetActive(true);
        bala.GetComponent<Rigidbody>().AddForce(head.forward * fuerzaDisp);
        //Destroy(bala, 10);
    }
}
