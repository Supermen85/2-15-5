using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class WalkAnimationHandler : MonoBehaviour
{
    private static readonly int Walking = Animator.StringToHash(nameof(Walking));

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Walk(float direction)
    {
        _animator.SetBool(Walking, direction != 0);

        if (direction > 0)
            _spriteRenderer.flipX = false;

        if (direction < 0)
            _spriteRenderer.flipX = true;
    }
}
