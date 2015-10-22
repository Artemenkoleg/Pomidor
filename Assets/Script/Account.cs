using UnityEngine;
using System.Collections;

public class Account : MonoBehaviour
{
    public string[] nameNumb = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    public Sprite[] sprite;
    public SpriteRenderer spritRend;
    public static int accountNum = 0;
    int[] number = new int[4];
    public static bool changeAccount = false;

    void Start ()
    {
        sprite = LoadSprite();
        spritRend = GetComponent<SpriteRenderer>();//LoadSprite();
        renderNewSprite();
    }
	
	void Update ()
    {
        if(changeAccount == true)
        {
            renderNewSprite();
            changeAccount = false;
        }
	}

    void renderNewSprite()
    {
        Read_number();
        GameObject.Find("Account1").GetComponent<SpriteRenderer>().sprite = sprite[number[0]];
        GameObject.Find("Account2").GetComponent<SpriteRenderer>().sprite = sprite[number[1]];
        GameObject.Find("Account3").GetComponent<SpriteRenderer>().sprite = sprite[number[2]];
        GameObject.Find("Account4").GetComponent<SpriteRenderer>().sprite = sprite[number[3]];
    }

    Sprite[] LoadSprite()
    {
        Sprite[] sprite = new Sprite[10];
        for(int i = 0; i < sprite.Length; i++)
        {
            sprite[i] = GameObject.Find(nameNumb[i]).GetComponent <SpriteRenderer>().sprite;// Resources.Load<Sprite>(nameNumb[i]);
        }
        return sprite;
    }

    void Read_number()
    {
        string str = accountNum.ToString();

        if ((accountNum > 0) && (accountNum < 100))
        {
            number[2] = int.Parse(str.Substring(0,1));
            number[3] = int.Parse(str.Substring(1));
        }
        else if ((accountNum > 100) && (accountNum < 1000))
        {
            number[1] = int.Parse(str.Substring(0,1));
            number[2] = int.Parse(str.Substring(1,1));
            number[3] = int.Parse(str.Substring(2));
        }
        else if (accountNum > 1000)
        {
            number[0] = int.Parse(str.Substring(0,1));
            number[1] = int.Parse(str.Substring(1,1));
            number[2] = int.Parse(str.Substring(2,1));
            number[3] = int.Parse(str.Substring(3));
        }
    }

    /*
    public class Account extends Actor
{
	MyLetter myLetter;
	TextureRegion[] letterWord = new TextureRegion[10];
	TextureRegion textureRegionOne;
	TextureRegion textureRegionTwo;
	TextureRegion textureRegionThree;
	TextureRegion textureRegionFour;
	TextureRegion textureZero;
	TextureRegion textureOne;
	TextureRegion textureTwo;
	TextureRegion textureThree;
	TextureRegion textureFour;
	TextureRegion textureFive;
	TextureRegion textureSix;
	TextureRegion textureSeven;
	TextureRegion textureEight;
	TextureRegion textureNine;
	public static int Number_account;
	public static int Number_account_game;
	Vector2 size;
	public static Vector2 position;
	public static Vector2[] posLetter = new Vector2[15];
	
	public Account(Texture texture,String atlas_name,int accountSize,Vector2 position,Vector2 size)
	{
		myLetter = new MyLetter(texture,atlas_name);
		InitLetterWord();
		Number_account = accountSize;
		Number_account_game = 0;
		
		textureRegionOne   = myLetter.stringRegions.get("0");
		textureRegionTwo   = myLetter.stringRegions.get("0");
		textureRegionThree = myLetter.stringRegions.get("0");
		textureRegionFour  = myLetter.stringRegions.get("0");
		
		this.size = new Vector2(size);
		this.position = new Vector2(position);
		
		setSize(15 * size.x, size.y);
		setPosition(position.x,position.y);
		
		PosLetter();
	}
	@Override
	public void draw(Batch batch,float parentAlpfa)
	{
		Read_number();
		for(int i = 0;i < MyGame.namePlayer.length(); i++)
		{
			batch.draw(letterWord[i], posLetter[i].x, posLetter[i].y, size.x, size.y);
		}
		batch.draw( textureRegionOne, posLetter[11].x, posLetter[11].y, size.x, size.y);
		batch.draw( textureRegionTwo, posLetter[12].x, posLetter[12].y, size.x, size.y);
		batch.draw( textureRegionThree, posLetter[13].x, posLetter[13].y, size.x, size.y);
		batch.draw( textureRegionFour, posLetter[14].x, posLetter[14].y, size.x, size.y);
	}
	
	void PosLetter()
	{
		for(int i = 0;i < posLetter.length; i++)
		{
			posLetter[i] = new Vector2(position.x + i * size.x,position.y);
		}
		
	}
	
	void InitLetterWord()
	{
		for(int i = 0;i < MyGame.namePlayer.length(); i++)
		{
			letterWord[i] = myLetter.stringRegions.get(Character.toString(MyGame.namePlayer.charAt(i)));
		}
	}
	
	void Read_number()
	{
		String str = Integer.toString(Number_account);
		
		if((Number_account > 0) && (Number_account < 100))
		{
			int f = Integer.parseInt(str.substring(1));
			textureRegionFour = Converter_number(f);
			f = Integer.parseInt(str.substring(0,1));
			textureRegionThree = Converter_number(f);
		}
		else  if((Number_account > 100) && (Number_account < 1000))
		{
			int f = Integer.parseInt(str.substring(2));
			textureRegionFour = Converter_number(f);
			f = Integer.parseInt(str.substring(1,2));
			textureRegionThree = Converter_number(f);
			f = Integer.parseInt(str.substring(0,1));
			textureRegionTwo = Converter_number(f);
		}
		else  if(Number_account > 1000)
		{
			int f = Integer.parseInt(str.substring(3));
			textureRegionFour = Converter_number(f);
			f = Integer.parseInt(str.substring(2,3));
			textureRegionThree = Converter_number(f);
			f = Integer.parseInt(str.substring(1,2));
			textureRegionTwo = Converter_number(f);
			f = Integer.parseInt(str.substring(0,1));
			textureRegionOne = Converter_number(f);
		}
	}
	TextureRegion Converter_number(int help)
	{
		TextureRegion textureRegion = new TextureRegion();
		switch(help)
		{
		case 0:
			textureRegion = myLetter.stringRegions.get("0");//textureZero;
			break;
		case 1:
			textureRegion = myLetter.stringRegions.get("1");//textureOne;
			break;
		case 2:
			textureRegion = myLetter.stringRegions.get("2");//textureTwo;
			break;
		case 3:
			textureRegion = myLetter.stringRegions.get("3");//textureThree;
			break;
		case 4:
			textureRegion = myLetter.stringRegions.get("4");//textureFour;
			break;
		case 5:
			textureRegion = myLetter.stringRegions.get("5");//textureFive;
			break;
		case 6:
			textureRegion = myLetter.stringRegions.get("6");//textureSix;
			break;
		case 7:
			textureRegion = myLetter.stringRegions.get("7");//textureSeven;
			break;
		case 8:
			textureRegion = myLetter.stringRegions.get("8");//textureEight;
			break;
		case 9:
			textureRegion = myLetter.stringRegions.get("9");//textureNine;
			break;
		}
		return textureRegion;
	}
	
	public static void UpDATE()
	{
		Number_account += 10;
		Number_account_game += 10;
	}
}
    */
}
