using UnityEngine;
using UnityEngine.AI;

namespace CraftingAnims
{
	public class CrafterNavigation:MonoBehaviour
	{
		// Components.
		[HideInInspector] public CrafterController crafterController;
		[HideInInspector] public NavMeshAgent navMeshAgent;
		[HideInInspector] public GameObject nav;

		// Variables.
		public bool isNavigating;

		private void Awake()
		{
			crafterController = GetComponent<CrafterController>();

			// Setup NavMeshAgent
			gameObject.AddComponent<NavMeshAgent>();
			navMeshAgent = GetComponent<NavMeshAgent>();
			navMeshAgent.enabled = false;
			navMeshAgent.speed = crafterController.walkSpeed;
			navMeshAgent.baseOffset = -0.05f;
			navMeshAgent.acceleration = 80f;

			// Find Nav object for visualizing navpoint.
			nav = GameObject.Find("Nav");
			nav.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
			nav.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
		}

		private void Update()
		{
			if (crafterController.navMeshNavigation) {
				nav.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
				nav.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = true;
				RaycastHit hit;
				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
					nav.transform.position = hit.point;
					if (Input.GetMouseButtonDown(0)) { MeshNavToPoint(hit.point); }
				}
				// If in active NavMeshNavigation.
				if (isNavigating) {
					Navigating();
				}
			}
			else {
				nav.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
				nav.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
				StopNavigating();
			}

		}

		/// <summary>
		/// Navigate towards the destiniation using NavMeshAgent.
		/// </summary>
		private void Navigating()
		{
			RotateTowardsMovementDir();

			// Animator settings.
			if (navMeshAgent.velocity.sqrMagnitude > 0) {
				crafterController.animator.SetBool("Moving", true);
				if (crafterController.navMeshRun) {
					navMeshAgent.speed = crafterController.runSpeed;
					crafterController.animator.SetFloat("Velocity Y", 1f);
				}
				else {
					navMeshAgent.speed = crafterController.walkSpeed;
					crafterController.animator.SetFloat("Velocity Y", 0.5f);
				}
			}
			else { crafterController.animator.SetFloat("Velocity Y", 0); }

			// Check if we've reached the destination
			if (!navMeshAgent.pathPending) {
				if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
					if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f) {
						StopNavigating();
					}
				}
			}
		}

		/// <summary>
		/// Navigate to the destination using Unity's NavMeshAgent.
		/// </summary>
		/// <param name="destination">Point in world space to navigate to.</param>
		public void MeshNavToPoint(Vector3 destination)
		{
			//Debug.Log("MeshNavToPoint: " + destination);
			navMeshAgent.enabled = true;
			isNavigating = true;
			navMeshAgent.SetDestination(destination);
		}

		/// <summary>
		/// Stop navigating to the current destination.
		/// </summary>
		public void StopNavigating()
		{
			//Debug.Log("StopNavigating");
			isNavigating = false;
			navMeshAgent.enabled = false;
		}

		private void RotateTowardsMovementDir()
		{
			if (navMeshAgent.velocity.magnitude > 0.01f) {
				transform.rotation = Quaternion.Slerp(transform.rotation,
					Quaternion.LookRotation(navMeshAgent.velocity),
					Time.deltaTime * navMeshAgent.angularSpeed);
			}
		}
	}
}