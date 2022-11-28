using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBullet : MonoBehaviour
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
        Destroy(gameObject, 1);
    }
    private void Update()
    {
        PlayerTransform = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 pos = Vector3.MoveTowards(transform.position, PlayerTransform.transform.position, speed * Time.deltaTime);
        
        rb.MovePosition(pos);
        // Debug.Log(PlayerTransform.transform.position);
    }
}