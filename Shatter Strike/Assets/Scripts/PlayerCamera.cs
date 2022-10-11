using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _bodyRotation;
    [SerializeField] private float _sensitivity = 1f;
    [SerializeField] private float _minAngle = -90f;
    [SerializeField] private float _maxAngle = 90f;
    [SerializeField] private bool _rotationIsLocked;

    private Vector3 _clampedRotation;

    private void Update()
    {
        if (_rotationIsLocked == false)
        {
            float mouseHorizontal = Input.GetAxis("Mouse X") * _sensitivity;

            _bodyRotation.eulerAngles += new Vector3(0f, mouseHorizontal);

            float mouseVertical = Input.GetAxis("Mouse Y") * _sensitivity;

            _clampedRotation.x -= mouseVertical;
            _clampedRotation.x = Mathf.Clamp(_clampedRotation.x, _minAngle, _maxAngle);
            _camera.localEulerAngles = _clampedRotation;
        }
    }

    public void LockCameraRotation()
    {
        _rotationIsLocked = true;
    }

    public void UnLockCameraRotation()
    {
        _rotationIsLocked = false;
    }

    private bool GetCameraState()
    {
        return _rotationIsLocked;
    }
}
