using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    public float FlyAmplitude;
    public float FlyFrequency;

    
    public float FlyFrequencey;
    public float WingFrequency;


    Vector3 Position;

    GameObject RearWingL;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Position = transform.position;
        RearWingL = GameObject.Find("RearWingL");
    }

    // Update is called once per frame
    void Update()
    {
         FlyMotion();
    }

    void WingMotion()
    {
        //RearWingL.transform.rotation.eulerAngles.z;
    }

    void FlyMotion()
    {
        Position.y = FlyAmplitude * Mathf.Sin(2*Mathf.PI*FlyFrequencey*Time.time);

        transform.position = Position;
    }
}
