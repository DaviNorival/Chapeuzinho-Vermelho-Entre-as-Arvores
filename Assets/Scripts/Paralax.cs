using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public Transform[] backgrounds; // Array para armazenar os planos de fundo
    private float[] parallaxScales; // A proporcao do movimento do plano de fundo em relacao a camera
    public float smoothing = 1f; // Quao suavemente o plano de fundo se movera
 
    private Transform cam; // Referencia a camera principal
    private Vector3 previousCamPos; // A posicao da camera na frame anterior
 
    void Awake()
    {
        // Configurando a referencia da camera
        cam = Camera.main.transform;
    }
 
    void Start()
    {
        // Armazenando as posicoes iniciais da camera
        previousCamPos = cam.position;
 
        // Configurando a proporcao do parallax para cada plano de fundo
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }
 
    void Update()
    {
        // Para cada plano de fundo
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // O parallax e o oposto do movimento da camera, multiplicado pelo parallaxScale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
 
            // Definindo uma posicao alvo x que e a posiaco atual mais o parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
 
            // Criando uma posicao alvo que e a posicao atual com a posicao x alvo
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
 
            // Suavizando a transicaoo entre a posicao atual e a posicao alvo
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
 
        // Atualizando a posicao da camera anterior para a posicao da camera atual no final do frame
        previousCamPos = cam.position;
    }
}