using UnityEngine;

[RequireComponent(typeof(Jumper), typeof(JumpAnimationHandler))]
[RequireComponent(typeof(Walker), typeof(WalkAnimationHandler))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Collector))]
public class Player : MonoBehaviour
{
    [SerializeField] private WalkAnimationHandler _walkAnimationHandler;
    [SerializeField] private JumpAnimationHandler _jumpAnimationHandler;
    [SerializeField] private Walker _walker;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Collector _collector;
    [SerializeField] private GroundDetector _sensor;
    
    private int _wallet = 0;

    private void OnValidate()
    {
        WalkAnimationHandler walkAnimationHandler = GetComponent<WalkAnimationHandler>();
        JumpAnimationHandler jumpAnimationHandler = GetComponent<JumpAnimationHandler>();
        Walker walker = GetComponent<Walker>();
        Jumper jumper = GetComponent<Jumper>();
        InputReader inputReader = GetComponent<InputReader>();
        Collector collector = GetComponent<Collector>();

        if (_walkAnimationHandler != null || _walkAnimationHandler != walkAnimationHandler)
            _walkAnimationHandler = walkAnimationHandler;

        if (_jumpAnimationHandler != null || _jumpAnimationHandler != jumpAnimationHandler)
            _jumpAnimationHandler = jumpAnimationHandler;

        if (_walker != null || _walker != walker)
            _walker = walker;

        if (_jumper != null || _jumper != jumper)
            _jumper = jumper;

        if (_inputReader != null || _inputReader != inputReader)
            _inputReader = inputReader;

        if (_collector != null || _collector != collector)
            _collector = collector;
    }

    private void OnEnable()
    {
        _inputReader.JumpKeyPressed += Jump;
        _sensor.Landed += Land;
        _collector.CoinCollected += CollectCoin;
    }

    private void OnDisable()
    {
        _inputReader.JumpKeyPressed -= Jump;
        _sensor.Landed -= Land;
        _collector.CoinCollected -= CollectCoin;
    }

    private void FixedUpdate()
    {
        Walk(_inputReader.Direction);
    }

    private void Jump()
    {
        if (_sensor.IsGrounded)
        {
            _jumper.Jump();
            _jumpAnimationHandler.Jump();
        }
    }

    private void Land()
    {
        _jumpAnimationHandler.Land();
    }

    private void Walk(float direction)
    {
        _walker.Walk(direction);
        _walkAnimationHandler.Walk(direction);
    }

    private void CollectCoin(int value)
    {
        if (value > 0)
            _wallet += value;
    }
}