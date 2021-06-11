using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    [SerializeField] private GameObject turret;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Text text;

    private Renderer rend;
    public Color startColor;
    [SerializeField]private float timer = 2;
    private bool cantPlace;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        if (turretToBuild == null)
        {
            return;
        }
        //Checks if there is already a turret placed on the tile
        if (turret != null)
        {
            cantPlace = true;
            Debug.Log("Cant't build there!"); //Display on screen'
            return;
        }
        //Checks if the tile the player clicks on is a placable area
        if (gameObject.tag =="Turret Node")
        {       
            //Grabs the selected tower
            if(turretToBuild.tag == "Turret")
            {
                //Makes the turret tile raise when the player places the turret
                transform.Translate(0, 0.20f, 0);
                //Spawns the turret
                turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

            }
        }

        //Checks if the tile the player clicks is an enemy tile to place a trap
        if (gameObject.tag == "Enemy Node")
        {
            if (turretToBuild.tag == "Trap")
            {
                //Spawns the trap
                turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            }
        }

    }
    private void OnMouseEnter()
    {
        //This will change the color of the tile tha the player hovers over
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
    private void Update()
    {
        if (cantPlace == true)
        {
            timer -= Time.deltaTime;
            text.gameObject.SetActive(true);
        }
        if (timer <= 0)
        {
            text.gameObject.SetActive(false);
            cantPlace = false;
            timer = 2;
        }
    }

}
