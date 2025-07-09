using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xMin = -10f;
    [SerializeField] private float xMax = 10f;
    [SerializeField] private float yMin = -10f;
    [SerializeField] private float yMax = 10f;
    [SerializeField] private float rollAngle = 10f;
    [SerializeField] private float pitchAngle = 10f;
    [SerializeField] private float rotationSpeed = 10f;
 


    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    
    // OnMove is called by the Player Input component on the Player Ship game object
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }


    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y  * controlSpeed * Time.deltaTime;

        float xPosRaw = transform.localPosition.x + xOffset;
        float yPosRaw = transform.localPosition.y + yOffset;

        float xPosClamped = Mathf.Clamp(xPosRaw, xMin, xMax);
        float yPosClamped = Mathf.Clamp(yPosRaw, yMin, yMax);

        transform.localPosition = new Vector3(xPosClamped, yPosClamped, 0f);
    }

    private void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(-movement.y * pitchAngle, 0f, -movement.x * rollAngle); // negate movement.x to rotate the correct direction
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);        
    }


}
