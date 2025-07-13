using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    private bool isFiring;
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crossHair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        UpdateCrossHair();
        UpdateTargetPoint();
        ProcessFiring();
        AimLasers();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission; //emissionModule is of type ParticleSystem.EmissionModule
            emissionModule.enabled = isFiring;
        }
    }

    private void UpdateCrossHair()
    {
        crossHair.position = Input.mousePosition;
    }

    private void UpdateTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    private void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
        
    }

}
