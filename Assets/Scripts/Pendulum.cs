using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    LineRenderer Arm;
    GameObject Pivot;

    public float Damping; 

    float AngularVelocity = 0;
    float r;

    float g = -9.82f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Arm = GetComponent<LineRenderer>();   
        Pivot = GameObject.Find("Pivot");

        r = Vector3.Distance(transform.position, Pivot.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //Ritar en linje mellan upphängningspunkten (Pivot) och vikten (Bob). 
        Arm.SetPosition(0, transform.position);
        Arm.SetPosition(1, Pivot.transform.position);

        //Beräknar skillnaden i X-led mellan upphängningspunkten och vikten
        float DeltaX = transform.position.x - Pivot.transform.position.x;
        
        //Utgående från x-skillnaden och armlängden kan vinkeln beräknas genom
        //att tillämpa trigonometri
        float Angle = Mathf.Asin(DeltaX/r);

        //När vinkeln är bekant kan vi beräkna vinkelaccelerationen
        float AngularAcceleration = (Mathf.Sin(Angle) * g)/r;

        //Adderar vinkelaccelerationen till vinkelhastigheten (som är noll vid)
        //simuleringens början 
        AngularVelocity += AngularAcceleration * Time.deltaTime;
        
        //Multiplicerar vinkelhastigheten med "Damping" för att bromsa upp pendeln
        AngularVelocity *= Damping;
        
        //Adderar vinkelhastigheten för vinkeln
        Angle += AngularVelocity * Time.deltaTime;

        //Beräknar x- och y-koordinater för vikten (Adderar med upphängningspunktens
        //position för annars utgår formeln ifrån att upphängningspunkten är
        //vid origo vilket den inte är i det här fallet)
        float x = Mathf.Sin(Angle) * r + Pivot.transform.position.x;
        float y = -Mathf.Cos(Angle) * r + Pivot.transform.position.y;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
