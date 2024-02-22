using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	private Transform tr;
	private bool holding = false;
	private Vector3 startMousePosition;
	private Vector3 startPosition;
	[SerializeField] private bool shouldReturn;

	private void Awake() =>
		tr = transform;

	public void OnPointerDown(PointerEventData dt) {
		holding = true;

		startPosition = tr.position;
		startMousePosition = Input.mousePosition;
	}

	public void OnPointerUp(PointerEventData dt) {
		holding = false;

		if (shouldReturn) 
			tr.position = startPosition;
	}

	private void Update () {
		if (!holding)
			return;

		Vector3 currentPosition = Input.mousePosition;
		Vector3 diff = currentPosition - startMousePosition;
		Vector3 pos = startPosition + diff;
		tr.position = pos;
	}
}