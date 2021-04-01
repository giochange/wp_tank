using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct Link
{
 //   nós de ligamento dos pontos em forma de grafo fazendo a possibilidade de ligação de um ponto ao outro apenas ou a mais de um.
    public enum direction { UNI, BI }
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}
public class WpManager : MonoBehaviour
{
    //lista dos pontos a ser direcionado
    public GameObject[] waypoints;
    // lista dos nós de ligação
    public Link[] links;
    // grafo
    public Graph graph = new Graph();


    // Start is called before the first frame update
    void Start()
    { // estrutura de repetição para ser verificação de passagem do WPpoint fazendo assim direcionar-se a outro ponto
        if (waypoints.Length > 0)
        {
            foreach(GameObject wp in waypoints)
            {
                graph.AddNode(wp);
            }
            // "l" indexador de sujestionamento
            foreach (Link l in links)
            {
                graph.AddEdge(l.node1, l.node2);
                if(l.dir == Link.direction.BI)
                graph.AddEdge(l.node2, l.node1);

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        graph.debugDraw();
    }
}
