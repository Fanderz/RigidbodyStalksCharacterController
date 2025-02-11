using UnityEngine;

public class StalkerMover : MonoBehaviour
{
    [SerializeField] private float _searchRadius;
    [SerializeField] private float _maxDistance;

    private Stalker _stalker;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _stalker = GetComponent<Stalker>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _searchRadius);

        if(colliders.Length > 0)
        {
            foreach(Collider collider in colliders)
            {
                if (collider.TryGetComponent<Player>(out Player player))
                    Move(player.transform.position);
            }
        }
    }

    private void Move(Vector3 target)
    {
        if(target != Vector3.zero)
        {
            Vector3 moveTarget = new Vector3((target.x - transform.position.x - _maxDistance) * _stalker.StalkerSpeed, target.y - transform.position.y,
                (target.z - transform.position.z - _maxDistance) * _stalker.StalkerSpeed);

            _rigidbody.velocity = moveTarget;
            _rigidbody.velocity += Physics.gravity;
        }    
    }
}
