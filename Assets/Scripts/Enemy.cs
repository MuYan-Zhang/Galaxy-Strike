using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedShipVFX;
    [SerializeField] int hitPoints = 1;
    [SerializeField] int scoreValue = 1;
    Scoreboard scoreboard;

    private void Start() 
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            scoreboard.IncrementScore(scoreValue);
            Instantiate(destroyedShipVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
