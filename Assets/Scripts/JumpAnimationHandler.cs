using UnityEngine;

[RequireComponent(typeof(Animator))]

public class JumpAnimationHandler : MonoBehaviour
{
    private static readonly int Jumping = Animator.StringToHash(nameof(Jumping));
    private static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
