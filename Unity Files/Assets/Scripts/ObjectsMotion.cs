using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMotion : MonoBehaviour
{
    [SerializeField] private float _rotationSensitivity = 5f;
    [SerializeField] private float _movementSensitivity = 1f;
    [SerializeField] private float yAxisMovementSensitivity = 0.1f;
    [SerializeField] private Vector2 _verticalLimits = new Vector2(-0.5f, 1.5f);

    private Vector3 _screenPosition;
    private Vector3 _worldPosition;
    private Vector2 _rotationAngle;
    Plane _invisiblePlane = new Plane(Vector3.down, 0);

    public void ControlWithTouchInput()
    {

        if (Input.GetMouseButton(1))
        {
            AdjustRotation();
        }
        else
        {
            AdjustMovement();
        }
    }

    private void AdjustMovement()
    {
        _screenPosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(_screenPosition);

        if (_invisiblePlane.Raycast(ray, out float distance))
        {
            _worldPosition = ray.GetPoint(distance);
        }

        float yPosition = Input.GetAxis("Vertical") * yAxisMovementSensitivity;

        transform.localPosition = new Vector3(
            _worldPosition.x,
            Mathf.Clamp(transform.position.y + yPosition, _verticalLimits.x, _verticalLimits.y),
            _worldPosition.z
            ) * _movementSensitivity;
    }

    private void AdjustRotation()
    {
        _rotationAngle.x += Input.GetAxis("Mouse X") * _rotationSensitivity;
        _rotationAngle.y += Input.GetAxis("Mouse Y") * _rotationSensitivity;
        transform.localRotation = Quaternion.Euler(-_rotationAngle.y, _rotationAngle.x, 0);
    }
}
