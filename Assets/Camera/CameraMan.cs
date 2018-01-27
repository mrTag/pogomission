using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraMan : MonoBehaviour {

    public static CameraMan sCamera = null;

    public CameraTarget Target;
    public float SmoothMinTime = .2f;
    public float MinOrthoSize = 5;
    public float MaxOrthoSize = 10;
    public float VelocityForMaxOrtho = 10;
    public float VelocityForMinOrtho = 3;

    [HideInInspector]
    public Camera Cam { get; private set; }
    private SmoothDampedVector3 _position;
    private Vector3 _positionLastFrame;
    private SmoothDampedValue _orthoSize;

    void Start()
    {
        sCamera = this;
        Application.targetFrameRate = 120;
        Cam = GetComponent<Camera>();
        _position = new SmoothDampedVector3(Target.PointOfInterest, SmoothMinTime);
        _orthoSize = new SmoothDampedValue(MinOrthoSize, SmoothMinTime);
        _positionLastFrame = transform.position;
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
            
            Vector3 vel = (transform.position - _positionLastFrame) / Time.deltaTime;
            float speed = vel.magnitude;
            _orthoSize.Target = MinOrthoSize + (MaxOrthoSize - MinOrthoSize) * Mathf.InverseLerp(VelocityForMinOrtho, VelocityForMaxOrtho, speed);
            _orthoSize.DoUpdate();
            Cam.orthographicSize = _orthoSize.Current;
            _positionLastFrame = transform.position;
        }
    }
}
