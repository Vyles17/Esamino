using UnityEngine;
using UnityEngine.UI;


public class NemiciUI : MonoBehaviour
{
    //mini-scriptino per la UI della vita del nemico
    [SerializeField] public Image vitaNemico;
    public Nemici nemico;

    void Start()
    {
        //getto lo script Nemico
        nemico = GetComponent<Nemici>();
    }
    void Update()
    {
        VitaUpdate();
    }

    public void VitaUpdate()
    {
        //setto che il fillamount dipende dalla vita corrente e poi la check/aggiorno in update
        vitaNemico.fillAmount = nemico.vitaCorrente / nemico.vitaMax;
    }
}
