using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    [SerializeField] private GameObject turret;
    [SerializeField] private Vector3 positionOffset;
    private Renderer rend;
    public Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {

        //Checks if the tile the player clicks on is a placable area
        if (gameObject.tag =="Turret Node")
        {
            //Checks if there is already a turret placed on the tile
            if (turret != null)
            {
                Debug.Log("Cant't build there!"); //Display on screen'
                return;
            }
            //Grabs the selected tower
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            if (turretToBuild== null)
            {
                return;
            }
            if (turretToBuild.tag == "Turret")
            {
                gameObject.transform.localScale += new Vector3(0, 20f, 0);
                transform.Translate(0, 0.2f, 0);
                turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            }  
        }

        //Checks if the tile the player clicks is an enemy tile to place a trap
        if (gameObject.tag == "Enemy Node")
        {
            //checks if a trap is already placed there
            if (turret != null)
            {
                Debug.Log("Cant't build there!"); //Display on screen'
                return;
            }
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            if (turretToBuild == null)
            {
                return;
            }
            if (turretToBuild.tag == "Trap")
            {
                turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            }
        }

    }
    private void OnMouseEnter()
    {
        //This will change the color of the tile tha tthe player hovers over
        //it will change to a different color depending on if the tile is a
        //enemy tile or a turret tile
        if (gameObject.tag == "Turret Node")
        {
            hoverColor = new Color(0.33f, 0.33f, 0.33f, 0.7f);
            Debug.Log("Turret Tile");
        }
        if (gameObject.tag == "Enemy Node")
        {
            hoverColor = new Color(0.8f, 0.82f, 0.24f, 0.7f);
            Debug.Log("Enemy Tile");
        }
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()  
    {
        rend.material.color = startColor;
    }
}
