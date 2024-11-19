using UnityEngine;

public class CharachterSpawner : MonoBehaviour
{
    // Referens till det prefab som ska instansieras (t.ex. en karaktär)
    public GameObject Prefab;

    // Antalet karaktärer som ska skapas
    public int Characters;

    // Start körs en gång innan den första körningen av Update
    void Start()
    {
        // Loopa för att skapa det antal karaktärer som är specificerat i 'Characters'
        for (int i = 0; i < Characters; i++)
        {
            // Generera en slumpmässig position inom specificerade gränser
            Vector3 Position = new Vector3(
                Random.Range(-16, 16), // Slumpmässig X-koordinat mellan -16 och 16
                0,                    // Y-koordinaten sätts till 0 (marknivå)
                Random.Range(-10, -20) // Slumpmässig Z-koordinat mellan -10 och -20
            );

            // Skapa en instans av prefaben vid den genererade positionen
            Instantiate(Prefab, Position, Prefab.transform.rotation);
        }
    }
}
