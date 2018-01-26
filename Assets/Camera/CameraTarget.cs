using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour
{
    public float VelocityAdvanceFactor = 1f;
    public float MaxAdvanceDistance = 5f;
    public Vector3 PointOfInterest { get; private set; }
	private Rigidbody2D _rb;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update () {
        if (_rb != null) {
            Vector3 advanceVector = Vector3.ClampMagnitude(_rb.velocity * VelocityAdvanceFactor, MaxAdvanceDistance);
            PointOfInterest = transform.position + advanceVector;
        } else {
            PointOfInterest = transform.position;
        }
	}
}
