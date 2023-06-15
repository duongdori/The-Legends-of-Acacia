using UnityEngine;

public class WeaponHitboxToWeapon : MonoBehaviour
{
        private AggressiveWeapon weapon;

        private void Awake()
        {
                weapon = GetComponentInParent<AggressiveWeapon>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
                weapon.AddToDetected(col);
        }

        private void OnTriggerExit2D(Collider2D col)
        {
                weapon.RemoveFromDetected(col);
        }
}