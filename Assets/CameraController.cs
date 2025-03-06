using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Point1;
    public Transform Point2;
    
    public float MovementSpeed;
    public float RotationSpeed;
    public float MovementTime;
    private Vector3 _newCameraPosition;
    private Vector3 _startCameraPosition;
    
    public BoxCollider Collider;
    public Transform CameraTransform;

    public Vector3 zoomAmount;
    
    private Vector3 _currentCameraPosition;
    
    private Vector3 _mousePosition;
    private Vector3 _newPosition;
    private Quaternion _newRotation;
    private Vector3 _zoomPosition;
    

    private bool _isMoving;
    
    void Start()
    {
        _startCameraPosition = transform.position;
        _newPosition = transform.position;
        _newRotation = transform.rotation;
        _zoomPosition = CameraTransform.localPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(Point1.position, 1f);
        Gizmos.DrawSphere(Point2.position, 1f);
        Gizmos.DrawLine(Point1.position, Point2.position);
    }

    void Update()
    {

        if (UnityEngine.Input.GetMouseButtonDown(1))
        {
            _mousePosition = UnityEngine.Input.mousePosition;
            _newRotation = transform.rotation;
        }

        if (UnityEngine.Input.GetMouseButton(1))
        {
            _newRotation *= Quaternion.Euler(Vector3.up * - (_mousePosition.x - UnityEngine.Input.mousePosition.x) * RotationSpeed);
            _mousePosition = UnityEngine.Input.mousePosition;
        }

        if (UnityEngine.Input.GetKey(KeyCode.W) || UnityEngine.Input.GetKey(KeyCode.UpArrow))
        {
            _newPosition += transform.forward * MovementSpeed;
        }

        if (UnityEngine.Input.GetKey(KeyCode.S) || UnityEngine.Input.GetKey(KeyCode.DownArrow))
        {
            _newPosition += transform.forward * - MovementSpeed;
        }
        
        if (UnityEngine.Input.GetKey(KeyCode.A) || UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        {
            _newPosition += transform.right * -MovementSpeed;
        }
        
        if (UnityEngine.Input.GetKey(KeyCode.D) || UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {
            _newPosition += transform.right * MovementSpeed;
        }

        if (UnityEngine.Input.mouseScrollDelta.y != 0)
        {
            _zoomPosition += zoomAmount * UnityEngine.Input.mouseScrollDelta.y;
        }

        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * MovementTime);
        transform.rotation = _newRotation;

        CameraTransform.localPosition = Vector3.Lerp(CameraTransform.localPosition, _zoomPosition, Time.deltaTime);
    }
}
