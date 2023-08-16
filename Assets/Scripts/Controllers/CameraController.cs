using TankGame.Managers;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform tank;
    [SerializeField] private float smoothing;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - tank.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.instance.GetTankState() == TankGame.Models.TankState.MOVING)
        {
            Vector3 targetPosition = tank.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
