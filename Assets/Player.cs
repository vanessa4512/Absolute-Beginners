using UnityEngine;

public class Player : MonoBehaviour
{
    public float movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement * Time.deltaTime,0f,0f);
    }
}
