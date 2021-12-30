using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController Controller;
    public float speed;
    float turningVelocity;
    public float turningTime = 0.1f;
    float timer = 0;
    int counter;
    public Canvas canvas;
    [HideInInspector] public int finalTime;
    public Text currentTime;

    void Update()
    {
        timer += Time.deltaTime;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turningVelocity, turningTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Controller.Move(direction * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flag"))
        {
            other.gameObject.SetActive(false);
            counter++;
            if (counter >= 5)
            {
                finalTime = (int) timer;
                currentTime.text = finalTime.ToString();
                canvas.gameObject.SetActive(true);
            }
        }
    }
}