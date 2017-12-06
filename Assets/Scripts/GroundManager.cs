using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {

    private static GroundManager instance;
    public static GroundManager Instance { get { return instance;  } }

    public GameObject ground;

    public float repeatTime;

    public List<GameObject> groundPool = new List<GameObject>();

    int _index;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        groundPool.AddRange(GameObject.FindGameObjectsWithTag("Ground"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 getSpawnPos()
    {
        Vector3 spawnPos = new Vector3(0, 0, 31 + (4 * _index));
        _index++;
        return spawnPos;
    }
}
