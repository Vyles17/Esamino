using TMPro;
using UnityEngine;
public class TorretteUI : MonoBehaviour
{
    [SerializeField] public TMP_Text costoUpgrade;
    public Torrette torretta;

    void FixedUpdate()
    {
        CostoUpdate();
    }

    public void CostoUpdate()
    {
        costoUpgrade.text = torretta.costoUpgrade.ToString();
    }
}
