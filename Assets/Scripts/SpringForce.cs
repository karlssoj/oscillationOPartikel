using UnityEngine;

public class SpringForce : MonoBehaviour
{
    public float Mass;
    public float K;
    public float Damping;
    float G = -9.82f;
    float Y0;

    Vector3 Velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Velocity = new Vector3(0, 0, 0);
        Y0 = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Beräknar tyngkraften
        float Fg = Mass * G;

        //Beräknar fjäderkraften
        float DeltaY = Y0 - transform.position.y;
        float Ff = DeltaY * K;

        //BEräknar den resulterande kraften
        float Fr = Ff + Fg;

        //Omvandlar resulterande kraften i acceleration
        float acceleration = Fr/Mass * Time.deltaTime;

        //Adderar accelerationen till hastigheten
        Velocity.y += acceleration;

        //Friktion
        Velocity *= Damping;
        
        //Adderar hastigheten till positionen
        transform.Translate(Velocity * Time.deltaTime);
    }
}
