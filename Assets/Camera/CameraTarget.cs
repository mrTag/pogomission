using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour
{
    public Transform PointOfInterest;
    public float PointMovementSpeed;
    public Rect Rectangle;
    public float HorizontalPush; 
    public Transform TargetPosition;
    public Rect TargetBounds;
    public AnimationCurve SmoothStepCurve;

    public float RightBoundary { get { return transform.position.x + Rectangle.max.x; } }
    public float LeftBoundary { get { return transform.position.x + Rectangle.min.x; } }
    public float TopBoundary { get { return transform.position.y + Rectangle.max.y; } }
    public float BottomBoundary { get { return transform.position.y + Rectangle.min.y; } }
    
    public float TargetLeft { get { return TargetPosition.position.x + TargetBounds.min.x; } }
    public float TargetRight { get { return TargetPosition.position.x + TargetBounds.max.x; } }
    public float TargetBottom { get { return TargetPosition.position.y + TargetBounds.min.y; } }
    public float TargetTop { get { return TargetPosition.position.y + TargetBounds.max.y; } }

    private Vector2 mTargetLocalPOIPosition;
    private bool mPOIMovesLeft;
    private Coroutine mMovePOIRoutine; 
    
	void Update ()
    {
        if (TargetPosition != null)
        {
            if (RightBoundary < TargetRight)
            {
                transform.position += Vector3.right * (TargetRight - RightBoundary);
                mTargetLocalPOIPosition = new Vector2(Rectangle.max.x + HorizontalPush, 0f);
                if (mMovePOIRoutine != null && mPOIMovesLeft)
                {
                    StopCoroutine(mMovePOIRoutine);
                    mMovePOIRoutine = null;
                }
                if (mMovePOIRoutine ==  null)
                {
                    mPOIMovesLeft = false;
                    mMovePOIRoutine = StartCoroutine(MovePOI());
                }
            }
            if (LeftBoundary > TargetLeft)
            {
                transform.position += Vector3.left * (LeftBoundary - TargetLeft);
                mTargetLocalPOIPosition = new Vector2(Rectangle.min.x - HorizontalPush, 0f);
                if (mMovePOIRoutine != null && !mPOIMovesLeft)
                {
                    StopCoroutine(mMovePOIRoutine);
                    mMovePOIRoutine = null;
                }
                if (mMovePOIRoutine == null)
                {
                    mPOIMovesLeft = true;
                    mMovePOIRoutine = StartCoroutine(MovePOI());
                }
            }
            if (TopBoundary < TargetTop)
            {
                transform.position += Vector3.up * (TargetTop - TopBoundary);
            }
            if (BottomBoundary > TargetBottom)
            {
                transform.position += Vector3.down * (BottomBoundary - TargetBottom);
            }
        }
	}

    IEnumerator MovePOI()
    {
        float t = 0f;
        Vector2 start = PointOfInterest.localPosition;
        Vector2 end = mTargetLocalPOIPosition;
        while (t < 1f)
        {
            PointOfInterest.localPosition = Vector2.Lerp(start, end, SmoothStepCurve.Evaluate(t));
            t += Time.deltaTime * PointMovementSpeed;
            yield return null;
        }
        mMovePOIRoutine = null;
    }
    
    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, .5f, 1f, .5f);
        Gizmos.DrawWireCube(transform.position + (Vector3)Rectangle.center, Rectangle.size);
        Gizmos.color = new Color(1f, .2f, .4f, .7f);
        Gizmos.DrawLine(new Vector3(RightBoundary + HorizontalPush, BottomBoundary, 0f), new Vector3(RightBoundary + HorizontalPush, TopBoundary, 0f));
        Gizmos.DrawLine(new Vector3(LeftBoundary - HorizontalPush, BottomBoundary, 0f), new Vector3(LeftBoundary - HorizontalPush, TopBoundary, 0f));
        if (PointOfInterest != null)
        {
            Gizmos.DrawWireSphere(PointOfInterest.position, .2f);
        }
        if (TargetPosition != null)
        {
            Gizmos.color = new Color(1f, 0f, 1f, .8f);
            Gizmos.DrawWireCube(TargetPosition.position + (Vector3)TargetBounds.center, TargetBounds.size);
        }
    }
    #endif
}
