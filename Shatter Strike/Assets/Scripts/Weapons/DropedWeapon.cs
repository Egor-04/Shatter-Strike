using UnityEngine;

public class DropedWeapon : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        if (gameObject.CompareTag("Player"))
        {

        }
    }
}
