using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject PlayerTransform;
    public Transform TeleporterPos;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform.transform.position = TeleporterPos.transform.position;
    }

}
