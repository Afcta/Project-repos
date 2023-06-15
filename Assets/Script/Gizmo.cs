using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public float radius = 0.1f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
