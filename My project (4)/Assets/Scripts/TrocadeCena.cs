using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocadeCena : MonoBehaviour
{
    [SerializeField] private string Principal;
    [SerializeField] private string Loja;
    [SerializeField] private string Eventos;
    [SerializeField] private string Roleta;
    [SerializeField] private string Slot;
    [SerializeField] private string Magias;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MudarparaLoja()
    {
        SceneManager.LoadScene(Loja);
    }

    public void MudarparaPrincipal()
    {
        SceneManager.LoadScene(Principal);
    }

    public void MudarparaEvento()
    {
        SceneManager.LoadScene(Eventos);
    }

    public void MudarparaMagias()
    {
        SceneManager.LoadScene(Magias);
    }

    public void MudarparaRoleta()
    {
        SceneManager.LoadScene(Roleta);
    }

    public void MudarparaSlot()
    {
        SceneManager.LoadScene(Slot);
    }

}
