using UnityEngine;

public class MineView : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tank")
        {
            other.gameObject.SetActive(false);
        }
    }
}
