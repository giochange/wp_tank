using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{//declaração de variavel de utilização direta
    Transform goal;
    float speed= 10.0f;
    float accuracy= 1.0f;
    float rotSpeed= 8.0f;


    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP= 0;
    Graph g;


    // Start is called before the first frame update
    void Start()
    {
        // pegada do componente WpManager= pontos e o graph
        wps = wpManager.GetComponent<WpManager>().waypoints;
        g = wpManager.GetComponent<WpManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame
   
    // metodo de procura do heliporto
    public void GoToHeli()
    {
        g.AStar(currentNode, wps[1]);
        currentWP = 0;
    }
    // metodo de procura das ruinas
    public void GoToRuin()
    {
        g.AStar(currentNode, wps[6]);
        currentWP = 0;
    }
    private void LateUpdate()
    {
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
            goal = g.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x,
                this.transform.position.y,
                goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * rotSpeed);

            
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);

    }
}
