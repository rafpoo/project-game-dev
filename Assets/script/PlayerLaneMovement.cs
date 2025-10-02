using UnityEngine;

public class PlayerLaneMovement : MonoBehaviour
{
    public float laneDistance = 2.5f;   // jarak antar lane
    public float moveSpeed = 10f;       // kecepatan pindah lane
    public float jumpForce = 7f;        // kekuatan lompat
    private int currentLane = 0;        // -1 = kiri, 0 = tengah, 1 = kanan
    private Vector3 targetPosition;

    private Rigidbody rb;               // buat lompat
    private bool isGrounded = true;     // cek kalau di tanah

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // ambil rigidbody
        targetPosition = transform.position;
    }

    void Update()
    {
        // Input kanan (D)
        if (Input.GetKeyDown(KeyCode.D) && currentLane < 1)
        {
            currentLane++;
            targetPosition = new Vector3(currentLane * laneDistance, transform.position.y, transform.position.z);
        }

        // Input kiri (A)
        if (Input.GetKeyDown(KeyCode.A) && currentLane > -1)
        {
            currentLane--;
            targetPosition = new Vector3(currentLane * laneDistance, transform.position.y, transform.position.z);
        }

        // Input lompat (Space)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Gerakin ke lane target secara smooth
        Vector3 newPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }

    // Cek kalau nyentuh tanah biar bisa lompat lagi
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
