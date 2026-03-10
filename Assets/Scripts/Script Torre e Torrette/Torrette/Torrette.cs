using System.Threading;
using UnityEngine;
public abstract class Torrette : MonoBehaviour
{
    //script madre per le torrette
    [SerializeField] public int costoTorretta = 10;
    [SerializeField] private int danniProiettili = 3;
    [SerializeField] private float areaProiettili = 1f;
    [SerializeField] private int velocitàProiettili = 1;
    [SerializeField] public int costoUpgrade =10;

    private float timer;

    public void Attacco()
    {
        timer += Time.fixedDeltaTime;
    }

    

}
