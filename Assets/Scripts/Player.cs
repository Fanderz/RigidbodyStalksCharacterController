using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _strafeSpeed;

    [SerializeField] private float _horizontalTurnSensitivity;
    [SerializeField] private float _verticalTurnSensitivity;

    [SerializeField] private float _verticalMinAngle = -89f;
    [SerializeField] private float _verticalMaxAngle = 89f;

    private bool _isLookingBack;

    public float PlayerSpeed => _speed;
    public float PlayerStrafeSpeed => _strafeSpeed;
    public float HorizontalTurnSensitivity => _horizontalTurnSensitivity;
    public float VerticalTurnSensitivity => _verticalTurnSensitivity;
    public float VerticalMinAngle => _verticalMinAngle;
    public float VerticalMaxAngle => _verticalMaxAngle;
    public bool IsLookingBack => _isLookingBack;
}
