using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -5);
    [SerializeField] private float cameraSpeed;
    private Vector3 playerVector;

    [SerializeField] private float limitXLeft;
    [SerializeField] private float limitXRight;
    [SerializeField] private float limitYDown;
    [SerializeField] private float limitYUp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerVector = new Vector3(
            Mathf.Clamp(player.transform.position.x, limitXLeft, limitXRight),
            Mathf.Clamp(player.transform.position.y, limitYDown, limitYUp),
            player.transform.position.z
        );
        transform.position = Vector3.Lerp(transform.position, playerVector + offset, Time.deltaTime * cameraSpeed);
    }
}
