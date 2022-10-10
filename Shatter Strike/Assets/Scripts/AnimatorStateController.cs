using UnityEngine;

public class AnimatorStateController : MonoBehaviour
{
    private Animator _animator;
    private float _velocityZ = 0.0f;
    private float _velocityX = 0.0f;
    [SerializeField] private float _lerpSpeed = 0.05f;
    [SerializeField] private float _accelerationSpeed = 2f;
    [SerializeField] private float _fastAccelerationSpeed = 2f;
    [SerializeField] private LocalPlayer _player;

    private float _cachedAccelerationSpeed;

    private void Start()
    {
        _cachedAccelerationSpeed = _accelerationSpeed;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _accelerationSpeed = Mathf.Lerp(_accelerationSpeed, _fastAccelerationSpeed, _lerpSpeed);
        }
        else
        {
            _accelerationSpeed = Mathf.Lerp(_accelerationSpeed, _cachedAccelerationSpeed, _lerpSpeed);
        }

        _velocityZ = Input.GetAxis("Vertical") * _accelerationSpeed;
        _velocityX = Input.GetAxis("Horizontal") * _accelerationSpeed;

        _animator.SetFloat("Velocity Z", _velocityZ);
        _animator.SetFloat("Velocity X", _velocityX);

        if (_velocityX == 0f && _velocityZ == 0f)
        {
            _animator.SetBool("Walk", false);
        }
        else
        {
            _animator.SetBool("Walk", true);
        }
    }
}