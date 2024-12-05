using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private BasicPacManMovement pacManScript;
    public Transform pacMan;
    public float fleeDistance = 10f;
    public float detectionRadius = 0.1f;
    private bool isFleeing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pacMan = GameObject.FindWithTag("player").transform;
        pacManScript = pacMan.GetComponent<BasicPacManMovement>();


        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;
    }

    void Update()
    {
        if (pacManScript.isPoweredUp && !isFleeing)
        {
            isFleeing = true;
            FleeFromPacMan();
        }
        else if (!pacManScript.isPoweredUp && isFleeing)
        {
            isFleeing = false;
            ChasePacMan();
        }
        else if (!pacManScript.isPoweredUp)
        {
            ChasePacMan();
        }

        if (isFleeing)
        {
            System.Collections.Generic.List<Material> materials = new System.Collections.Generic.List<Material>();
            this.gameObject.GetComponent<SkinnedMeshRenderer>().GetMaterials(materials);
            materials[0].SetColor(Shader.PropertyToID(name), new Color(0, 37, 204));
            this.gameObject.GetComponent<SkinnedMeshRenderer>().SetMaterials(materials);
        }
        DetectPacMan();
    }

    void FleeFromPacMan()
    {
        Vector3 directionToPacMan = transform.position - pacMan.position;
        Vector3 fleePosition = transform.position + directionToPacMan.normalized * fleeDistance;
        agent.SetDestination(fleePosition);
    }

    void ChasePacMan()
    {
        agent.SetDestination(pacMan.position);
    }

    void DetectPacMan()
    {
        float distanceToPacMan = Vector3.Distance(this.transform.position, pacMan.position);

        if (distanceToPacMan <= detectionRadius)
        {
            if (pacManScript.isPoweredUp)
            {
                Debug.Log("Pac-Man ate a ghost!");
                Destroy(gameObject);  // Remove the ghost
            }
            else
            {
                Debug.Log("Pac-Man touched a ghost! Lose a life.");
                pacManScript.LoseLife();  // Pac-Man loses a life
            }
        }
    }
}
