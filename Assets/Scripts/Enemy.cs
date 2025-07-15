using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("shot");
        Destroy(this.gameObject);
    }
}
