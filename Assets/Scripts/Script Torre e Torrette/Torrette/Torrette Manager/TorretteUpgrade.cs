using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TorretteUpgrade : MonoBehaviour, IPointerClickHandler
{
    //script per upgradeare le torrette quando sono piazzate e ci clicchiamo sopra

    public static event Action OnTorretteUpgrade;

    public void OnPointerClick(PointerEventData eventData)
    {
        //ci gettiamo lo script torrette dalla torretta quando viene spawnata 
        Torrette torretta = GetComponentInChildren<Torrette>();

        //se la torretta non è upgradeabile..
        if (!torretta.èUpgradeabile)
        {
            //non si può più cliccare
            return;
        }

        if (torretta.CostoTorretta <= DimDollaroniManager.Instance.portafoglio)
        {

            //scaliamo i DimDollaroni dal portafoglio
            int dimDollaroni = torretta.costoTorretta;
            DimDollaroniManager.Instance.Spesa(dimDollaroni);

            //il costo del prossimo upgrade viene raddoppiato
            torretta.CostoTorretta *= 2;

            //invochiamo l'azione
            OnTorretteUpgrade?.Invoke();

            //accediamo al metodo di ciascuna torretta
            torretta.UpgradeTorretta();
        }

    }
}
