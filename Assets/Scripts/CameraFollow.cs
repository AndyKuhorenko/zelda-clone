using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public float time = 10f;
    [SerializeField] public Vector3 offset;
    [SerializeField] public AnimationCurve AnimCurve;
    [SerializeField] private Player player;

    private Transform target;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        target = player.transform;
    }

    private void LateUpdate()
    {
        Vector3 desiredPos = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, time);
    }
}