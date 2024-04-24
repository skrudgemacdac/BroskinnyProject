using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour {

	[SerializeField]
	private TMP_Text _txt;

	[SerializeField]
	private GameObject _flashOnTxt;

	public int Energy;

	[SerializeField]
	private GameObject _Light;

    [SerializeField]
    private bool onLight;

    [SerializeField] 
	private GameObject _startTxt;



	private float scet;

    //public TMP_Text Txt { get => _txt; set => _txt = value; }
    //public GameObject FlashOnTxt { get => _flashOnTxt; set => _flashOnTxt = value; }
    //public int Energy { get => _Energy; set => _Energy = value; }
    //public GameObject Light { get => _Light; set => _Light = value; }
    //public bool OnLight { get => onLight; set => onLight = value; }
    //public GameObject StartTxt { get => _startTxt; set => _startTxt = value; }

    // Use this for initialization
    void Start () 
	{
		Invoke("DestroyTXT", 3f);
	}
	
	// Update is called once per frame
	void Update () {
		_txt.text = Energy + "%";
		if (onLight == true) {
			scet += 1 * Time.deltaTime;
			if (scet >= 2) {
				Energy -= 3;
				scet = 0;
			}
		}
		if (Energy >= 100) {
			Energy = 100;
		}
		if (Energy <= 0) {
			onLight = false;
			_Light.SetActive (false);
			Energy = 0;
		}
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			if (onLight == false && Energy >0) 
			{
				_Light.SetActive (true);
				onLight = true;
				_flashOnTxt.SetActive(false);
			}
			else 
			{
				_Light.SetActive (false);
				onLight = false;
			}
		}
	}

	void DestroyTXT() 
	{
		_startTxt.SetActive(false);
	}
}
