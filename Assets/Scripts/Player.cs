using UnityEngine;

[RequireComponent(typeof(WalkAnimationHandler))]
[RequireComponent(typeof(JumpAnimationHandler))]
[RequireComponent(typeof(Walker))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(InputReader))]

public class Player : MonoBehaviour
{
    private WalkAnimationHandler _walkAnimationHandler;   
    private JumpAnimationHandler _jumpAnimationHandler;
    private Walker _walker;
    private Jumper _jumper;
    private GroundDetector _groundDetector;
    private InputReader _inputReader;

    private float _direction = 0f;

    private void Awake()
    {
        _walkAnimationHandler = GetComponent<WalkAnimationHandler>();
        _jumpAnimationHandler = GetComponent<JumpAnimationHandler>();
        _walker = GetComponent<Walker>();
        _jumper = GetComponent<Jumper>();
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
    }

    private void FixedUpdate()
    {
        _direction = _inputReader.Direction;
        Walk();
    }

    private void OnEnable()
    {
        _inputReader.JumpKeyPressed += Jump;
        _groundDetector.Landed += Land;
    }

    private void OnDisable()
    {
        _inputReader.JumpKeyPressed -= Jump;
        _groundDetector.Landed -= Land;
    }

    private void Jump()
    {
        if (_groundDetector.IsGrounded())
        {
            _jumper.Jump();
            _jumpAnimationHandler.Jump();
        }
    }

    private void Land()
    {
        _jumpAnimationHandler.Land();
    }

    private void Walk()
    {
        _walker.Walk(_direction);
        _walkAnimationHandler.Walk(_direction);
    }
}
