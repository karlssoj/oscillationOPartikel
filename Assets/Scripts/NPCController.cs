using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    // Referens till NavMeshAgent-komponenten
    NavMeshAgent Agent;

    // Referenser till de två waypoints som NPC:n ska röra sig mellan
    GameObject Waypoint, Waypoint2;

    // Referens till Animator-komponenten för att hantera animationer
    Animator Anim;

    // Start körs en gång innan den första körningen av Update
    void Start()
    {
        // Hämta NavMeshAgent-komponenten från objektet
        Agent = GetComponent<NavMeshAgent>();

        // Hämta Animator-komponenten från objektet
        Anim = GetComponent<Animator>();

        // Hitta waypoints i scenen baserat på deras namn
        Waypoint = GameObject.Find("Waypoint");
        Waypoint2 = GameObject.Find("Waypoint2");

        // Sätt den initiala destinationen till Waypoint
        Agent.SetDestination(Waypoint.transform.position);
    }

    // Update körs en gång per bildruta
    void Update()
    {
        // Kontrollera om NPC:n är på väg mot sin destination
        if (Agent.remainingDistance > Agent.stoppingDistance)
        {
            // Sätt Walking-variabeln i Animator till true (NPC:n går)
            Anim.SetBool("Walking", true);
        }
        else
        {
            // Sätt Walking-variabeln i Animator till false (NPC:n står still)
            Anim.SetBool("Walking", false);

            // Starta en fördröjd funktion för att sätta nästa destination
            StartCoroutine(DelayedFunctionCall(Random.Range(3, 6)));    
        }
    }

    // Coroutine som väntar en viss tid innan nästa funktion körs
    IEnumerator DelayedFunctionCall(float delay)
    {
        // Vänta i ett antal sekunder baserat på delay
        yield return new WaitForSeconds(delay);

        // Anropa funktionen för att sätta nästa destination
        SetNextDestination();
    }

    // Sätt nästa destination för NPC:n
    void SetNextDestination()
    {
        // Ändra destinationen till Waypoint2
        Agent.SetDestination(Waypoint2.transform.position);
    }
}