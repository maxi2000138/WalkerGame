using UnityEngine;

namespace Player
{
    public class PlayerGunRotater : MonoBehaviour
    {
        [SerializeField] private GameObject _gun;

        public void Rotate(Vector2 lookVector)
        {
            Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * lookVector;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, rotatedVectorToTarget);
            _gun.transform.rotation = targetRotation;
        }
    }
}
