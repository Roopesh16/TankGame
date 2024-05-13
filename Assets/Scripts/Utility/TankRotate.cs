using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class TankRotate : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 60f;

        void Update()
        {
            transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);
        }
    }
}