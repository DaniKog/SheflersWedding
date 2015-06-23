using UnityEngine;
using System.Collections;

public class ScreenShaker : Singleton<ScreenShaker>
{
	[SerializeField] private float shakeTime = 1f;
	[SerializeField] private float shakeAmount = 0.7f;
	[SerializeField] private float decreaseFactor = 1.0f;

	private Vector3 originalPos;

	private void Start()
	{
		originalPos = transform.position;
	}

	private IEnumerator Shaking() 
	{
		while (shakeTime > 0f)
		{
			transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shakeTime -= Time.deltaTime * decreaseFactor;
			yield return new WaitForSeconds(0.001f);
		} 

		shakeTime = 0.0f;
		transform.localPosition = originalPos;
	}


	public void Shake(float time, float amount)
	{
		shakeTime = time;
		shakeAmount = amount;

		StopAllCoroutines();
		StartCoroutine(Shaking());
	}

}
