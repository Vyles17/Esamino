using UnityEngine;

public class TorrettaNormale : Torrette
{
    //in questo scriptino della torretta normale, modifico i danni del proiettile
    protected override void ModificaProiettile(GameObject proiettile)
    {
        // setto che i danni dei proiettili appena spawnati sovrascrivono quelli dello script Proiettili
        Proiettili pro = proiettile.GetComponent<Proiettili>();
        pro.DanniProiettili = danniProiettili;
    }

    public override void UpgradeTorretta()
    {
        //il suo upgrade duplica i danni
        danniProiettili *= 2;
    }
}
