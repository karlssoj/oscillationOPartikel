using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ButterflyController : MonoBehaviour
{
    public float FlyAmplitude;
    public float FlyFrequency;

    
    public float WingAmplitude;
    public float WingFrequency;


    Vector3 Position;
    Vector3 Rotation;

    GameObject RearWingL;
    GameObject RearWingR;
    GameObject FrontWingL;
    GameObject FrontWingR;
    

    float InitalPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Position = transform.position;
        RearWingL = GameObject.Find("RearWingL");
        RearWingR = GameObject.Find("RearWingR");
        FrontWingL = GameObject.Find("FrontWingL");
        FrontWingR = GameObject.Find("FrontWingR");
        Rotation = RearWingL.transform.rotation.eulerAngles;
        InitalPosition = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
         FlyMotion();
         WingMotion();

         transform.Translate(0, 0, 1 * Time.deltaTime);
    }

    void WingMotion()
    {
        Rotation.z = WingAmplitude * Mathf.Sin(2*Mathf.PI*WingFrequency*Time.time);

        RearWingL.transform.eulerAngles = -Rotation;
        RearWingR.transform.eulerAngles = Rotation;
        FrontWingL.transform.eulerAngles = -Rotation;
        FrontWingR.transform.eulerAngles = Rotation;
    }

    void FlyMotion()
    {
        Position.y = FlyAmplitude * Mathf.Sin(2*Mathf.PI*FlyFrequency*Time.time) + InitalPosition;

        transform.position = Position;
    }
}
