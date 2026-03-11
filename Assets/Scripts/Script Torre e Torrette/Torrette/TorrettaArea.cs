using Unity.VisualScripting;
using UnityEngine;

public class TorrettaArea : Torrette
{
    //rispetto alle altre torrette, questa ha la stat dell'area del proiettile
    //quindi overridiamo la funz Attacco per inserire questa variabile in più

    //le sue stats in più
    [SerializeField] private float areaProiettile = 5f;
    [SerializeField] private float areaUpgrade = 1.25f;


    //in questo scriptino della torretta area, modifico i danni del proiettile e gli aggiungo il danno ad area
    protected override void ModificaProiettile(GameObject proiettile)
    {
        // setto che i danni dei proiettili appena spawnati sovrascrivono quelli dello script Proiettili
        Proiettili pro = proiettile.GetComponent<Proiettili>();
        pro.DanniProiettili = danniProiettili;

        // aumento la dimensione del collider del proiettile
        CircleCollider2D col = proiettile.GetComponent<CircleCollider2D>();
        col.radius = areaProiettile;
    }

    public override void UpgradeTorretta()
    {
        //il suo upgrade moltiplica l'area
        areaProiettile *= areaUpgrade;
    }
}
