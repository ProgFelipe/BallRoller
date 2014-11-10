using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public GUIText txtCount;
	public GUIText txtWin;
	private int count;
	public  AudioClip[] audioClip;
	
	void Start(){
		count = 0;
		SetCountText();
		txtWin.text = "";
	}
	
	void Update () {  
		if (Input.GetKeyDown (KeyCode.Return)) {  
				Application.LoadLevel(Application.loadedLevel);
				}
	}  
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "PickUp"){
				other.gameObject.SetActive(false);
				count = count + 1;
				if(count < 17){
				PlaySound(0);
				SetCountText();
				}else{
				PlaySound(2);
				SetCountText();
				txtWin.text = "¡Congrats YOU WIN!";
				}
		}
		if(other.gameObject.tag == "Floor"){
				PlaySound(1);
				txtWin.text = "¡Opps YOU LOSE! Press Enter to Restart";
		}
	}
	void SetCountText(){
				txtCount.text = "Count: "+ count.ToString();
	}
	
	void PlaySound(int clip){
		audio.clip = audioClip[clip];
		audio.Play();
	}
}