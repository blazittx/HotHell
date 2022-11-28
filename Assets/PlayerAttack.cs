using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform gunAim;
    [SerializeField] LineRenderer lineRend;
    Camera cam;
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        cam = Camera.main;
        //StartCoroutine(RightClick(1));
    }

    //void FixedUpdate()
    //{
    //    ray = cam.ScreenPointToRay(Input.mousePosition);

    //    if (Physics.Raycast(ray, out hit, 100))
    //    {

    //        if (Input.GetMouseButton(0))
    //        {
    //            lineRend.enabled = true;
    //            lineRend.SetPosition(0, hit.point);
    //            lineRend.SetPosition(1, gunAim.transform.position);
    //            Debug.DrawLine(ray.origin, hit.point, Color.red);
    //            print(hit.transform.name);
    //            //Destroy(hit.transform.gameObject);
    //        }
    //        else
    //        {
    //            lineRend.enabled = false;



    //        }


    //    }



    }
