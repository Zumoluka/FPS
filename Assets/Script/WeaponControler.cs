using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControler : MonoBehaviour
{
    [Header("General")]
    public GameObject Bullet;
    public LayerMask hittableLayers;
    [Header("Shoot Paramaters")]
    public float Firerange = 200;

    [Header("camera")]
    public Camera playercam;

    private Transform cameraPlayerTransform;
    private void Awake()
    {
        playercam = GameObject.FindObjectOfType<Camera>();
    }
    void Start()
    {
        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        if(playercam == null)
        {
         playercam = GameObject.FindGameObjectWithTag("CatchingCamera").GetComponent<Camera>() as Camera;
        }


    }


    void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraPlayerTransform.position, cameraPlayerTransform.forward, out hit, Firerange, hittableLayers))
            {
                Debug.Log("disparo");

                if (hit.collider.name.Substring(0, 3) == "bot")
                {
                    GameObject ObjetoTocado = GameObject.Find(hit.transform.name);
                    ControlBot ScriptObjetoTocado = (ControlBot)ObjetoTocado.GetComponent(typeof(ControlBot));
                    if(ScriptObjetoTocado != null)
                    {
                        ScriptObjetoTocado.recibirDaño();
                    }
                }
            }
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playercam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            GameObject pro;
            pro = Instantiate(Bullet, ray.origin, transform.rotation);
            Rigidbody rb = pro.GetComponent<Rigidbody>();
            rb.AddForce(playercam.transform.forward* 15, ForceMode.Impulse);
            Destroy(pro, 5);
        }
    }
}
