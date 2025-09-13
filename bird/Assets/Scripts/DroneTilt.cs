using UnityEngine;

public class DroneTilt : MonoBehaviour
{
    public Transform drone;
    public float TiltAmount;
    public float TiltSpeed;

    private Vector3 targetTilt;

    // Update is called once per frame
    void Update()
    {
        MovementScript movement = drone.GetComponent<MovementScript>();
        Vector2 rotation = movement.Steer.action.ReadValue<Vector2>();

        float tiltX = -rotation.y * TiltAmount;
        float tiltZ = -rotation.x * TiltAmount;
        targetTilt = new Vector3(tiltX, 0, tiltZ);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(targetTilt), Time.deltaTime*TiltSpeed);
        
    }
}
