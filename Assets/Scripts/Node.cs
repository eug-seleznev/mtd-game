using UnityEngine;

public class Node : MonoBehaviour
{
    public Transform nodePos;
    public Color hoverColor;
    public GameObject TowerPrefab;
    private Renderer rend;
    private Color currentColor;
    private Vector3 offsetTowerHill = new Vector3(0f, 2f, 0f);
    private Vector3 offsetTowerLand = new Vector3(0f, 0.5f, 0f);
    private bool alreadyBuild = false;

    [Header("Level Unit Prefab")]
    [SerializeField]private GameObject hill;
    [SerializeField]GameObject land;


    void Start ()
    {
        nodePos = transform.transform;
        rend = GetComponent<Renderer>();
        currentColor = rend.material.color;

        
    }

    void OnMouseDown()
    {
        // if (alreadyBuild)
        // {
        //     Debug.Log("Can't build there!");
        //     return;
        // }

        // if (this.tag == "Hill")
        // {
        //     Instantiate(TowerPrefab, transform.position + offsetTowerHill, Quaternion.identity);
        //     alreadyBuild = true;
        // } else if (this.tag == "Land")
        // {
        //     Instantiate(TowerPrefab, transform.position + offsetTowerLand, Quaternion.identity);
        //     alreadyBuild = true;
        // }

        if (this.tag == "Hill")
        {
            Destroy(gameObject);
            Instantiate(land, new Vector3(transform.position.x, -0.5f, transform.position.z), Quaternion.identity);
        }else if (this.tag == "Land")
        {
            Destroy(gameObject);
            Instantiate(hill, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
        }

    }

    void OnMouseEnter ()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit ()
    {
        rend.material.color = currentColor;
    }
}
