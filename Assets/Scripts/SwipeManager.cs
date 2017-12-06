using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection
{
    //stackoverflow.com/questions/9811114/why-do-enum-permissions-often-have-0-1-2-4-values
    None = 0,
    Left = 1,
    Right = 2,
    Up = 4,
    Down = 8,

    //// Right + Up = 2 + 4 = 6 yang hasilnya diagonal kanan atas
    //LeftDown = 9,
    //LeftUp = 5,
    //RightDown = 10,
    //RightUp = 6
}

public class SwipeManager : MonoBehaviour
{

    private static SwipeManager instance;
    public static SwipeManager Instance { get { return instance; } }

    public SwipeDirection Direction { set; get; }

    private Vector3 touchPosition;
    public float swipeThresholdX = 25.0f;
    public float swipeThresholdY = 10.0f;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Direction = SwipeDirection.None;

        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = touchPosition - Input.mousePosition;

            if (Mathf.Abs(deltaSwipe.x) > swipeThresholdX)
            {
                //Swipe X Axis
                Direction = (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;
            }

            if (Mathf.Abs(deltaSwipe.y) > swipeThresholdY)
            {
                //Swipe Y Axis
                Direction |= (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;
            }
        }
    }

    //Check kalau lagi swipe atau tidak
    public bool IsSwiping(SwipeDirection dir)
    {
        return (Direction & dir) == dir;
    }

    //Put In Update || FixedUpdate
    //How to Use
    //4 Arah simetris
    //if (Swipe.Instance.IsSwiping(SwipeDirection.Right))
    //    Debug.Log("Swipe Right");
    //else if (Swipe.Instance.IsSwiping(SwipeDirection.Left))
    //    Debug.Log("Swipe Left");
    //else if (Swipe.Instance.IsSwiping(SwipeDirection.Up))
    //    Debug.Log("Swipe Up");
    //else if (Swipe.Instance.IsSwiping(SwipeDirection.Down))
    //    Debug.Log("Swipe Down");

    //4 Arah Diagonal
    //if (Swipe.Instance.IsSwiping(SwipeDirection.RightUp))
    //    Debug.Log("Diagonal Right Up");
    //else if (Swipe.Instance.IsSwiping(SwipeDirection.RightDown))
    //    Debug.Log("Diagonal Right Down");
    //else if (Swipe.Instance.IsSwiping(SwipeDirection.LeftUp))
    //    Debug.Log("Diagonal Left Up");
    //else if (Swipe.Instance.IsSwiping(SwipeDirection.LeftDown))
    //    Debug.Log("Diagonal Left Down");
}