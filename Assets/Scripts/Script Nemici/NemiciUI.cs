using UnityEngine;
using UnityEngine.UI;


public class NemiciUI : MonoBehaviour
{
    [SerializeField] public Image vitaNemico;
    public Nemici nemico;

    void Update()
    {
        VitaUpdate();
    }

    public void VitaUpdate()
    {
        vitaNemico.fillAmount = nemico.vitaCorrente / nemico.vitaMax;

    }
}
