using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Camera))]
public class CameraMan : MonoBehaviour {

    public static CameraMan sCamera = null;

    public Transform ObjectToFollow;
    [HideInInspector]

    public Camera Cam { get; private set; }

    void Start()
    {
        sCamera = this;
        Application.targetFrameRate = 120;
        Cam = GetComponent<Camera>();
    }

    void LateUpdate ()
    {
        if (ObjectToFollow != null)
        {
            transform.position = new Vector3(
                ObjectToFollow.position.x,
                ObjectToFollow.position.y,
                transform.position.z);
        }
    }
}
