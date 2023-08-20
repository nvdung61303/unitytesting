using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public GameObject player;
    [SerializeField] private float offset;
    [SerializeField] private float cameraSpeed;
    private Vector3 playerVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        playerVector = new Vector3(player.transform.position.x, player.transform.position.y , transform.position.z);

        if (player.transform.localScale.x > 0f) 
        {
            playerVector = new Vector3(playerVector.x + offset, playerVector.y , playerVector.z);
        }
        else 
        {
            playerVector = new Vector3(playerVector.x - offset, playerVector.y , playerVector.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerVector, cameraSpeed * Time.deltaTime);
    }
}
