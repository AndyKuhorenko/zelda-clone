using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public float time = 10f;
    [SerializeField] public Vector3 offset;
    [SerializeField] public AnimationCurve AnimCurve;
    private ThirdPersonCharacter player;

    private Vector3 velocity = Vector3.zero;
    private float timer = 0f;
    private float cameraSpeed;

    private void Start()
    {
        player = target.GetComponent<ThirdPersonCharacter>();
    }

    void LateUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, player.isMoving ? time / AnimCurve.Evaluate(timer) : time);

        smoothedPos.y = target.position.y + offset.y;

        transform.position = smoothedPos;

        if (player.isMoving)
        {
            timer = Time.deltaTime * 15;
        }
        else
        {
            timer = 0f;
        }
    }
}