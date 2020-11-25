using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour
{

    [SerializeField] private int nbrRay;

    [SerializeField] private float angle;

    private float stepAngle;
    [SerializeField] private float maxDistance;

    [SerializeField] private Vector3 initDir;

    [SerializeField] private bool showRay;

    [SerializeField] private MeshFilter meshFilter;

    [SerializeField] private Renderer meshRenderer;

    private int nbrVertices;
    private int nbrTriangle;
    private Vector3 dir;

    private void Start() {
        dir = Quaternion.Euler(0,-angle,0) * initDir;
        angle *= 2;
        stepAngle = angle / nbrRay;
        nbrVertices = nbrRay + 1;
        nbrTriangle = (nbrRay - 1) * 3;

    }

    private void Update() {
        meshFilter.mesh = GenerateMesh();

        if(showRay)
            ShowRay();
    }

    private Mesh GenerateMesh(){
        Vector3[] vertices = new Vector3[nbrVertices];
        int[] triangle = new int[nbrTriangle];

        // vertices[0] = transform.position;
        vertices[0] = Vector3.zero;

        RaycastHit[] raycastHits = new RaycastHit[nbrRay];

        //Generate
        for (int i = 0; i < nbrRay; i++)
        {
            Vector3 stepDir = Quaternion.Euler(0,stepAngle * i,0) * dir;

            if(Physics.Raycast(transform.position, stepDir, out raycastHits[i],maxDistance)){
                vertices[i+1] = raycastHits[i].point - transform.position;

                if (raycastHits[i].collider.GetComponent<Player>())
                {
                    raycastHits[i].collider.GetComponent<Player>().SendMessage("Dead");
                }

            }
            else {
                vertices[i+1] = transform.position + stepDir * maxDistance - transform.position;
            }
        }

        

        for (int i = 0; i < (nbrRay - 1); i++)
        {
            triangle[3*i] = 0;
            triangle[3*i + 1] = i + 1;
            triangle[3*i + 2] = i + 2;
        }

        Mesh output = new Mesh();
        output.vertices = vertices;
        output.triangles = triangle;

        output.name = "Ray";

        output.RecalculateNormals();

        return output;
    }

    private void ShowRay(){
        RaycastHit[] raycastHits = new RaycastHit[nbrRay];

        //Generate
        for (int i = 0; i < nbrRay; i++)
        {
            Vector3 stepDir = Quaternion.Euler(0,stepAngle * i,0) * dir;

            if(Physics.Raycast(transform.position, stepDir, out raycastHits[i],maxDistance)){
                Debug.DrawLine(transform.position, raycastHits[i].point, Color.green);
            }else {
                Debug.DrawLine(transform.position,transform.position + stepDir * maxDistance, Color.red);
            }
        }

    }



}
