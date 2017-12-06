using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundReUse : MonoBehaviour {

    public float destroyDelay;
    public float distThreshold;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckReuse();
	}

    void ReUseMe()
    {
        transform.parent.position = GroundManager.Instance.getSpawnPos();
    }

    //void OnCollisionExit(Collision col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        Debug.Log("exit");
    //        ReUseMe();
    //    }
    //}

    void CheckReuse()
    {
        Vector3 dist = transform.position - PlayerMovement.Instance.transform.position;
        if (PlayerMovement.Instance.transform.position.z > transform.position.z)
        {
            if (dist.magnitude >= distThreshold)
            {
                ReUseMe();
            }
        }
    }
}
