using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	//Buyable Items
	public Button HealthDrink;
	public RoteBeeteSettings roteBeete;
	public int roteBeetePrice = 10;

	public Button ManaDrink;
	public PowerBankSettings powerBank;
	public int powerBankPrice = 5;

	//Gold vom Spieler nehmen
	public CharacterSheet playerSheet;
	public Text money;

	public void Start() {
		HealthDrink.onClick.AddListener(BuyHealth);
		ManaDrink.onClick.AddListener(BuyMana);
	}

	private void UpdateMoney() {
		money.text = "Money: " + playerSheet.Money;
	}

	private void BuyHealth() {
		roteBeete.Count += 1;
		playerSheet.Money -= roteBeetePrice;
		UpdateMoney();

	}


	private void BuyMana() {
		powerBank.Count += 1;
		playerSheet.Money -= powerBankPrice;
		UpdateMoney();
	}
}
