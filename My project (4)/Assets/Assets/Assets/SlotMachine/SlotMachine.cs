using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [Header("Configura��es")]
    [SerializeField] private RectTransform content;        // Refer�ncia ao conte�do da ScrollView
    [SerializeField] private ScrollRect scrollRect;        // Refer�ncia ao ScrollRect
    [SerializeField] private float imageHeight = 200f;      // Altura das imagens (ajuste conforme necess�rio)
    [SerializeField] private float spinSpeed = 1000f;       // Velocidade do giro
    [SerializeField] private float deceleration = 2000f;    // Desacelera��o

    public List<UIPrize> uiPrizes;

    private bool isSpinning = false;
    public bool isStopping = false;

    public int prizeID = 0;
    public bool endedTurning = false;
    // Come�ar o giro
    [ContextMenu("Start")]
    public void StartSpin()
    {
        endedTurning = false ;
        isSpinning = true;
        isStopping = false;
        spinSpeed = 1000f;  // Velocidade inicial

        StartCoroutine(Turning());
    }

    // Parar o giro
    public void StopSpin()
    {
        isStopping = true;
    }

    private IEnumerator Turning()
    {
        while (isSpinning)
        {
            // Move o Content
            content.anchoredPosition += Vector2.up * spinSpeed * Time.deltaTime;

            // Verifica se ultrapassou a altura total e reseta a posi��o para o in�cio
            if (content.anchoredPosition.y >= content.rect.height)
            {
                content.anchoredPosition = Vector2.zero;
            }

            // Se estiver parando
            if (isStopping)
            {
                spinSpeed -= deceleration * Time.deltaTime;
                if (spinSpeed <= 0f)
                {
                    spinSpeed = 0f;
                    isSpinning = false;
                    isStopping = false;
                    StartCoroutine(LerpToCentralize());
                }
            }

            yield return null;
        }
    }

    private IEnumerator LerpToCentralize()
    {
        float factor = 0;
        Vector2 startPosition = content.anchoredPosition;
        Vector2 center = AlignToCenter();

        while(factor < 1f)
        {
            content.anchoredPosition = Vector2.Lerp(startPosition, center, factor);
            factor += 0.001F;
            yield return null;
        }
        content.anchoredPosition = Vector2.Lerp(startPosition, center, 1);
        endedTurning = true;
    }

    // Alinha o Content de forma que a imagem centralizada seja a mais pr�xima do centro
    private Vector2 AlignToCenter()
    {
        float viewportHeight = scrollRect.viewport.rect.height;      // Altura da viewport
        float currentContentY = content.anchoredPosition.y;          // Posi��o Y atual do Content

        // Calculando a posi��o centralizada levando em conta a metade da altura da imagem
        float centerOffset = currentContentY + (viewportHeight / 2f);

        // Encontrar o �ndice da imagem mais pr�xima do centro
        int nearestIndex = Mathf.RoundToInt(centerOffset / imageHeight);
        Debug.Log($"O INDEX FOI {nearestIndex-1}");

        prizeID = uiPrizes[nearestIndex-1].prizeID;

        // Ajustando a posi��o do Content considerando a metade da altura da imagem
        float targetContentY = nearestIndex * imageHeight - (viewportHeight / 2f) - (imageHeight / 2f);

        // Ajusta a posi��o do Content para centralizar a imagem levando em considera��o a metade da altura da imagem
        return new Vector2(content.anchoredPosition.x, targetContentY);
    }

    public void ConfigUI(List<Prize> prizes)
    {
        for (int i = 0; i < prizes.Count; i++)
        {
            uiPrizes[i].SetPrizeText(prizes[i].prizeID, prizes[i].iconPrize);
        }
        uiPrizes[uiPrizes.Count - 1].SetPrizeText(prizes[0].prizeID, prizes[0].iconPrize);
    }
}
