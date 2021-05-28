using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    //For each button on the shop, they will spawn corresponding turret
    public void PurchaceTurret1()
    {
        buildManager.SetTurretToBuild(buildManager.turret1);
    }
    public void PurchaceTurret2()
    {
        buildManager.SetTurretToBuild(buildManager.turret2);
    }
    public void PurchaceTurret3()
    {
        buildManager.SetTurretToBuild(buildManager.turret3);
    }
    public void PurchaceTurret4()
    {
        buildManager.SetTurretToBuild(buildManager.turret4);
    }
}
