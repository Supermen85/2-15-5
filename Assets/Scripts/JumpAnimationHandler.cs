using UnityEngine;

[RequireComponent(typeof(Animator))]
public class JumpAnimationHandler : MonoBehaviour
{
    private static readonly int Jumping = Animator.StringToHash(nameof(Jumping));
    private static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));

    [SerializeField] private Animator _animator;

    private void OnValidate()
    {
        Animator animator = GetComponent<Animator>();

        if (_animator == null || _animator != animator)
            _animator = animator;
    }

    public void Jump()
    {
        _animator.SetTrigger(Jumping);
        _animator.SetBool(IsGrounded, false);
    }

    public void Land()
    {
        _animator.SetBool(IsGrounded, true);
    }
}
