using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    private GameObject defendersParent;
    private StarDisplay starDisplay;

    private void Start()
    {
        defendersParent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        if (!defendersParent)
        {
            defendersParent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateMouseClick();
        Vector2 position = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;

        int defenderCost = defender.GetComponent<Defender>().starCost;
        if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(position, defender);
        }
        else
        {
            Debug.Log("Insuccificent Funds");
        }
        
    }

    private void SpawnDefender(Vector2 position, GameObject defender)
    {
        GameObject newDef = Instantiate(defender, position, Quaternion.identity) as GameObject;
        newDef.transform.parent = defendersParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawPosition)
    {
        float newX = Mathf.RoundToInt(rawPosition.x);
        float newY = Mathf.RoundToInt(rawPosition.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 position = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(position);
        return worldPos;
    }
}
