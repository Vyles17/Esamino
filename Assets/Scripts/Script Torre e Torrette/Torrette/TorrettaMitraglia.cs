using System;
using UnityEngine;

public class TorrettaMitraglia : Torrette
{
    //stats per l'upgrade
    [SerializeField] float rateoUpgrade = 0.15f;
    private float rateoUpgradeLimite = 0.30f;

    //in questo scriptino della torretta mitraglia, modifico i danni del proiettile
    protected override void ModificaProiettile(GameObject proiettile)
    {
        // setto che i danni dei proiettili appena spawnati sovrascrivono quelli dello script Proiettili
        Proiettili pro = proiettile.GetComponent<Proiettili>();
        pro.DanniProiettili = danniProiettili;
    }

    public override void UpgradeTorretta()
    {
        // se non è più upgradeabile, non si può far niente
        if (!èUpgradeabile) return;

        //se siamo sopra al limite..
        if (rateoProiettili > rateoUpgradeLimite)
        {
            //al suo upgrade, viene sottratto un valore custom dal rateoProiettili
            rateoProiettili -= rateoUpgrade;

            //se siamo al limite dopo l'ultimo upgrade, disattiviamo l'opzione di cliccare la torretta per upgradearla
            if (rateoProiettili <= rateoUpgradeLimite)
            {
                // e se è andato più sotto del limite, lo riportiamo al limite
                rateoProiettili = rateoUpgradeLimite;

                //lo coloriamo di grigio
                SpriteRenderer torrettaSprite = GetComponent<SpriteRenderer>();
                torrettaSprite.color = Color.gray7;

                //non è più upgradeabile
                èUpgradeabile = false;
            }
        }

    }
}
