using TankGame.Managers;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform tank;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.instance.GetTankState() == TankGame.Models.TankState.MOVING)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, tank.transform.position.z);
        }
    }
}
