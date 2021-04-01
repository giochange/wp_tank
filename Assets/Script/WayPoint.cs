using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    //list dos pontos-é aqui que vai ser listados os destinos
    public GameObject[] waypoints;
    int currentWP = 0;

    
    float speed = 1.0f;
    float accuracy = 1.0f;
    float rotSpeed = 0.4f;

    // inicia junto ao play da unity
     void Start()
    {
        // é aqui que vai ser analisado quais objetos serão points- decorentes de suas tags
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // funciona a cada frame
     void LateUpdate()
    {
        //condicionamento  é uma função que retorna o tamanho / quantidade de caracteres de uma variavel
        if (waypoints.Length == 0) return;

        // faz um calcula entre o ponto "final- o inicial, somando 1 a lista fazendo assim aterar o ponto final
        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x,
 

// faz um referenciamento ao proprio objeto setando sua posição conforme o list"Y"
            this.transform.position.y,
             // faz um referenciamento ao proprio objeto setando sua posição conforme o list"Z"
             waypoints[currentWP].transform.position.z);
// equaliza um vetor como sendo ele resultante da subtração de um " vetor - o vetor do proprio objeto
        Vector3 direction = lookAtGoal - this.transform.position;
        // diz a equidade do objeto com  a interpolação entre orientações
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            //seta a rotação com relação do vetor "direction"
            Quaternion.LookRotation(direction),
        // mantem a velocidade de rotação constante durate o funcionamento do codigo
            Time.deltaTime * rotSpeed);
        //cria um condicionamento de subtração para obter resultado
        if(direction.magnitude < accuracy)
        {
            //soma  1 espaço a list a cada processo do repetição
            currentWP++;
            // condicionamento de comparação entre o tamanho da lista e a variavel onde fica alocado, analizando assim se "current W é >= a currentWP,
            if (currentWP >= waypoints.Length)
                //fazendo assim se isto acontecer seta o valor de" cuurntWP para 0
            { currentWP = 0; }
        }
        // realiza uma multiplica de velocida de movimentação no eixo"Z"setando o valor de speed como de "Z" 
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

}
