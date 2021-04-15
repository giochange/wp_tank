using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{//declaração de variavel de utilização direta
   // Transform goal;
   // float speed= 10.0f;
   // float accuracy= 1.0f;
   // float rotSpeed= 2.0f;


    public GameObject wpManager;
    GameObject[] wps;

    UnityEngine.AI.NavMeshAgent agente;
    //GameObject currentNode;
    //int currentWP= 0;
   // Graph g;


    // Start is called before the first frame update
    void Start()
    {
        // pegada do componente WpManager= pontos e o graph
        wps = wpManager.GetComponent<WpManager>().waypoints;
        agente = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        //g = wpManager.GetComponent<WpManager>().graph;
        //currentNode = wps[0];
    }

    // Update is called once per frame
   
    // metodo de procura do heliporto
    public void GoToHeli()
    {
        agente.SetDestination(wps[1].transform.position);
        //g.AStar(currentNode, wps[1]);
        //currentWP = 0;
    }
    // metodo de procura das ruinas
    public void GoToRuin()
    {
        agente.SetDestination(wps[6].transform.position);
        //g.AStar(currentNode, wps[6]);
        //currentWP = 0;
    }
    //metodo de chamafda do ponto das usinas
    public void GoTousin()
    {
        agente.SetDestination(wps[8].transform.position);
        //g.AStar(currentNode, wps[8]);
        //currentWP = 0;
    }
    private void LateUpdate()
    {
        /* codigo utilizado para waypoint
        // condição perante o tamanho "g" igual a 0  ou currentwp = g.getpathlenght
        if (g.getPathLength() == 0 || currentWP == g.getPathLength())
            return;
        // O nó que estará mais próximo neste momento currentNode =
        g.getPathPoint(currentWP);
        //se estivermos mais próximo bastante do nó o tanque se moverá para o próximo

        //condicioname de que se a distancia do ponto for menor do que o value de accuracy somo 1 ao array
        if(Vector3.Distance(g.getPathPoint(currentWP).transform.position,
            transform.position) < accuracy)
        {
            currentWP++;
        }

        //currentwp for menor que getpathlength faz com que o tank vá até o ponto
        if (currentWP < g.getPathLength())
        {
            //valor igual ao do waypoint
            goal = g.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x,
                this.transform.position.y,
                goal.position.z);
            //direcionamento entre o destino e o tank
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * rotSpeed);

            
        }
        //movimentação do tank utilizando o translate
        this.transform.Translate(0, 0, speed * Time.deltaTime);
        */

    }
}
