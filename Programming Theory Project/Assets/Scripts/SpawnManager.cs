using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject prefab; // Le prefab à instancier
    public int rows = 5; // Nombre de lignes
    public int columns = 15; // Nombre de colonnes
    public float spacing = 0.8f; // Espacement entre les objets

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Vector3 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.nearClipPlane));
        startPosition.z = 0; // Assurez-vous que la position z est correcte pour votre scène
        startPosition.x += 3.5f;
        startPosition.y -= 0.5f;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Calculer la position de chaque instance
                Vector3 position = new Vector3(startPosition.x + j * spacing, startPosition.y - i * spacing, startPosition.z);
                // Instancier le prefab à la position calculée
                Instantiate(prefab, position, Quaternion.identity);
            }
        }

    }
 }
