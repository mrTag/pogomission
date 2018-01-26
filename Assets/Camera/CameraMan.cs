using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraMan : MonoBehaviour {

    public static CameraMan sCamera = null;

    public CameraTarget Target;
    public float SmoothMinTime = .2f;
    [HideInInspector]
    public Camera Cam { get; private set; }
    private SmoothDampedVector3 _position;

    void Start()
    {
        sCamera = this;
        Application.targetFrameRate = 120;
        Cam = GetComponent<Camera>();
        _position = new SmoothDampedVector3(Target.PointOfInterest, SmoothMinTime);
    }

    void LateUpdate ()
    {
        if (Target != null)
        {
            _position.Target = Target.PointOfInterest;
            _position.DoUpdate();
            transform.position = new Vector3(
                _position.Current.x,
                _position.Current.y,
                transform.position.z);
        }
    }
}
