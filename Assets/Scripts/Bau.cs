using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    [SerializeField] GameObject particulas;
    [SerializeField] private bool ehMagico;
    [SerializeField] private int numeroChave;
    [SerializeField] private List<GameObject> itens = new List<GameObject>();
    [SerializeField] private int ouro;
    private bool pegouOuro = false;
    // Start is called before the first frame update
    void Start()
    {
        if (ehMagico)
        {
            particulas.SetActive(true);
            ouro = Random.Range(100, 500);
        }
        else
        {
            particulas.SetActive(false);
            ouro = Random.Range(0, 100);
        }
    }

    private void DesativaParticulas()
    {
        particulas.GetComponent<ParticleSystem>().Stop();
    }

    public int PegarOuro()
    {
        if (!pegouOuro)
        {
            DesativaParticulas();
            StartCoroutine(ZerarBau());
            pegouOuro = true;
            return ouro;
        }
        return ouro = 0;
    }

    IEnumerator ZerarBau()
    {
        yield return new WaitForSeconds(2.5f);
        ouro = 0;
    }
    public int PegarNumeroFechadura()
    {
        return numeroChave;
    }
    public List<GameObject> AcessarConteudoBau()
    {
        Debug.Log("Você coletouos Itens do Bau");
        return itens;
    }
    public void RemoverConteudoBau()
    {
        itens.Clear();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(GetComponent<Player>().pegando = true)
            {
                GetComponent<Animator>().SetBool("Abrir", true);
            }
        }
    }
}
