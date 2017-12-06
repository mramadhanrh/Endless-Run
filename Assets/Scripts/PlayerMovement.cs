using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private static PlayerMovement instance;
    public static PlayerMovement Instance { get { return instance;  } }

    public Vector3[] posList = new Vector3[3];

    [Range(0, 100)]
    public float speed;
    public float forcePower;
    public float switchSpeed;

    Vector3 tarPos;

    Rigidbody myRb;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        myRb = GetComponent<Rigidbody>();
        tarPos = posList[1];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveFoward();

        Control();

        LerpPosition();
	}

    void MoveFoward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void Control()
    {
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Right))
        {
            if (getCurrentLane() != 2)
            {
                tarPos = posList[getCurrentLane() + 1];
            }
            Debug.Log(getCurrentLane());
        }
        else if (SwipeManager.Instance.IsSwiping(SwipeDirection.Left))
        {
            if (getCurrentLane() != 0)
            {
                tarPos = posList[getCurrentLane() - 1];
            }
            Debug.Log(getCurrentLane());
        }
        else if (SwipeManager.Instance.IsSwiping(SwipeDirection.Up))
        {
            Jump();
        }
    }

    void Jump()
    {
        myRb.AddForce(Vector2.up * forcePower, ForceMode.Impulse);
    }

    void LerpPosition()
    {
        transform.position = Vector3.Lerp(transform.position,
                                          new Vector3(tarPos.x, transform.position.y, transform.position.z),
                                          switchSpeed * Time.deltaTime);

        if (transform.position == (tarPos - new Vector3(0.1f, 0f, 0f)))
        {
            transform.position = tarPos;
        }
    }

    public int getCurrentLane()
    {
        int i = 0;
        foreach (Vector3 mypos in posList)
        {
            if (tarPos == mypos)
            {
                return i;
            }
            i++;
        }
        return 0;
    }
}
