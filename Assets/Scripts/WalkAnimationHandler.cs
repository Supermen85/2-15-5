using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WalkAnimationHandler : MonoBehaviour
{
    private static readonly int Walking = Animator.StringToHash(nameof(Walking));

    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _transform;

    private Quaternion _right = Quaternion.Euler(Vector3.zero);
    private Quaternion _left = Quaternion.Euler(0, 180f, 0);
    
    private float _yRotation = 180f;

    private void OnValidate()
    {
        Animator animator = GetComponent<Animator>();
        Transform transform = GetComponent<Transform>();

        if (_animator != null || _animator != animator)
            _animator = animator;

        if (_transform != null || _transform != transform)
            _transform = transform;
    }

    public void Walk(float direction)
    {
        _animator.SetBool(Walking, direction != 0);

        if (direction > 0 && _transform.rotation.eulerAngles.y == _yRotation)
            _transform.rotation = _right;

        if (direction < 0 && _transform.rotation.eulerAngles == Vector3.zero)
            _transform.rotation = _left;
    }
}
