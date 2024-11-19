using UnityEngine;

public class HumanController : MonoBehaviour
{
    // Referens till Animator-komponenten för att hantera animationer
    Animator Anim;

    // Variabler för att kontrollera rörelsehastighet och rotationshastighet
    public float Speed, RotationSpeed;

    // Start körs en gång innan den första körningen av Update
    void Start()
    {
        // Hämta Animator-komponenten från objektet
        Anim = GetComponent<Animator>();
    }

    // Update körs en gång per bildruta
    void Update()
    {
        // Kontrollera om pil upp är nedtryckt
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Sätt animationens "Walking"-bool till true (karaktären går)
            Anim.SetBool("Walking", true);

            // Flytta karaktären framåt baserat på hastighet och tid
            transform.Translate(0, 0, Speed * Time.deltaTime);
        }
        else
        {
            // Om pil upp inte är nedtryckt, sätt "Walking"-bool till false (karaktären står still)
            Anim.SetBool("Walking", false);
        }

        // Kontrollera om pil vänster är nedtryckt
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotera karaktären åt vänster baserat på rotationshastighet och tid
            transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0);
        }

        // Kontrollera om pil höger är nedtryckt
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Rotera karaktären åt höger baserat på rotationshastighet och tid
            transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
        }
    }
}
