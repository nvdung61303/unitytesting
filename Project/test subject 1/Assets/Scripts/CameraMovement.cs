using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -5);
    [SerializeField] private float cameraSpeed;
    private Vector3 playerVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime);
    }
}
