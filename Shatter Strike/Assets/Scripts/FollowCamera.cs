using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 1f;
    [SerializeField] private float _cameraOffset = 0f;
    [SerializeField] private Transform _head;
    [SerializeField] private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 lerpPosition = Vector3.Lerp(transform.position, _head.position, _lerpSpeed * Time.deltaTime);
        _camera.transform.position = new Vector3(lerpPosition.x, lerpPosition.y, lerpPosition.z);
    }
}
