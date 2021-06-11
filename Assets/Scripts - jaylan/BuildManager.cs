using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static BuildManager instance;

    public GameObject turret1;
    public GameObject turret2;
    public GameObject turret3;
    public GameObject turret4;

    [SerializeField] private GameObject turretToBuild;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

    //private void Start()
   // {
   //     turretToBuild = turret1;
   // }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void SetTurretToBuild(GameObject _turret)
    {
        turretToBuild = _turret;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException(); // todo UI elements
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException(); // todo UI element de-transition.
    }
}
