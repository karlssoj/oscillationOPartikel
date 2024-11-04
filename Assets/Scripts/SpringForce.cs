using UnityEngine;

public class SpringForce : MonoBehaviour
{
    public float Mass;
    public float K;
    float G = -9.82f;

    Vector3 Velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float Fg = Mass * G;
        float acceleration = Fg/Mass * Time.deltaTime;

        Velocity.y += acceleration;
        transform.Translate(Velocity * Time.deltaTime);
    }
}
