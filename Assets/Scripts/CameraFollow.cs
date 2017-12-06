using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;

    public float speed;

    public int depth;

    public float edgeThreshold;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, player.position.z - depth), speed * Time.fixedDeltaTime);
        SwitchCameraLane();
	}

    void SwitchCameraLane()
    {
        Vector3 newPos = PlayerMovement.Instance.posList[PlayerMovement.Instance.getCurrentLane()];
        switch (PlayerMovement.Instance.getCurrentLane())
        {
            case 0:
                transform.position = Vector3.Lerp(transform.position, new Vector3(newPos.x + edgeThreshold, transform.position.y, transform.position.z), speed * Time.fixedDeltaTime);
                break;
            case 1:
                transform.position = Vector3.Lerp(transform.position, new Vector3(newPos.x, transform.position.y, transform.position.z), speed * Time.fixedDeltaTime);
                break;
            case 2:
                transform.position = Vector3.Lerp(transform.position, new Vector3(newPos.x - edgeThreshold, transform.position.y, transform.position.z), speed * Time.fixedDeltaTime);
                break;
        }
    }
}
