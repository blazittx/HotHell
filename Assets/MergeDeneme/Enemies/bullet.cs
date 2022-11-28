using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody rb;
    public GameObject PlayerTransform;
    public float speed = 11;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PlayerTransform = GameObject.FindWithTag("Player");
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 pos = Vector3.MoveTowards(transform.position, PlayerTransform.transform.position, speed * Time.deltaTime);

        rb.MovePosition(pos);
        Destroy(gameObject, 1f);
    }
    //public void BulletTrace(Vector3 enemyPos)
    //{
    //    Vector3 pos = Vector3.MoveTowards(transform.position, PlayerTransform.transform.position, speed * Time.deltaTime);

    //    rb.MovePosition(enemyPos);
    //    Destroy(gameObject, 1f);
    //}
}
