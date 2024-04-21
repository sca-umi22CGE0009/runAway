using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManager;
using UnityEngine.Networking;
using System.IO;
using DesignPattern;



public class ScenarioManager : Singleton<ScenarioManager>,ISingleton,IUpdateManager
{


    [SerializeField,Header("���͒[��")]
    InputType inputType;
    [SerializeField, Header("google�X�v���b�g�V�[�g��ID")]
    string SHEET_ID = "ID������";

    [SerializeField, Header("�V�[�g��")] 
    string SHEET_NAME = "�V�[�g��������";

    //�������e�L�X�g�ɏ������܂�鑬��
    private float textInterval = 0f;
    [SerializeField, Header("�\�������e�L�X�g")]
    Text displayText;
    [SerializeField, Header("�������\������鑬��")]
    float charaSpeed = 0f;
    [SerializeField, Header("�b�����Ă���L�����̖��O")]
    Text talkingCharaName = null;
    [SerializeField,Header("�L�����摜�f�[�^")]
    SetDisplayImage setImage;
    //google�X�v���b�g�V�[�g�̃f�[�^�ۊǗp
    string[][] arrayTwo;
    //�b���Ă���L�����̖��O�ۊǗp
    List<string> charaName;
    //��ʂɕ\������L�����摜�ۊǗp
    List<string> displayCharaImage;
    //���ʉ�se�ۊǗp
    List<string> soundSe;
    //���͕ۊǗp
    List<string> texts;
    //�w�i�摜�ۊǗp
    List<string> backGroundImage;
    //�e�L�X�g�\�����I����Ă��邩�̃`�F�b�N
    bool checkIfTheStoryIsOver = false;
    //��s�̕�����
    int currentCharNum = 0;
    //�s��
    int currentLineNum = 0;
    //�I���̍s
    int lineIsTheEnd = 0;
    //�ǂݍ��݂̃`�F�b�N
    bool loadCheck = false;
    public int CurrentLineNum => currentLineNum;
    public bool LoadCheck 
    {
       get {return loadCheck; }
       internal set {loadCheck = value;}
    }

    private void Start()
    {
        
        charaName = new List<string>();
        displayCharaImage = new List<string>();        
        backGroundImage = new List<string>();       
        soundSe = new List<string>();       
        texts = new List<string>();
        
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
       if(LineEndCheck()) TextController();
    }

    private IEnumerator Method(string _SHEET_NAME)
    {

        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + SHEET_ID + "/gviz/tq?tqx=out:csv&sheet=" + _SHEET_NAME);
        yield return request.SendWebRequest();

        switch (request.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log("<color=Cyan><size=13><b>���N�G�X�g��...</b></size></color>");
                break;

            case UnityWebRequest.Result.Success:
                Debug.Log("<color=Lime><size=13><b>���N�G�X�g����!</b></size></color>");
                break;

            ///<summary>
            ///�`���l���Ƃ͈��pURL
            /// https://e-words.jp/w/%E3%83%81%E3%83%A3%E3%83%8D%E3%83%AB.html#:~:text=%E3%83%86%E3%83%AC%E3%83%93%E3%81%AE%E3%83%81%E3%83%A3%E3%83%B3%E3%83%8D%E3%83%AB%E3%81%AE%E3%82%88%E3%81%86,%E3%82%92%E8%A1%A8%E3%81%99%E3%81%93%E3%81%A8%E3%82%82%E3%81%82%E3%82%8B%E3%80%82
            /// </summary>
            case UnityWebRequest.Result.ConnectionError:
                Debug.LogError("<color=Red><size=13><b>�T�[�o�[�Ƃ̒ʐM�Ɏ��s���܂����B���N�G�X�g���ڑ��ł��Ȃ��������A���S�ȃ`���l�����m���ł��Ȃ������\��������܂��B</b></size></color>");
                break;

            ///<summary>
            ///�v���g�R���Ƃ͈��pURL(�����ł���https�̂��Ƃł��B)
            ///�@https://www.keyence.co.jp/ss/general/iot-glossary/protocol.jsp#:~:text=%E3%83%97%E3%83%AD%E3%83%88%E3%82%B3%E3%83%AB%E3%82%88%E3%81%BF%EF%BC%9A%E3%81%B7%E3%82%8D%E3%81%A8%E3%81%93%E3%82%8B%E3%80%81%E8%8B%B1%E5%AD%97%EF%BC%9A,%E3%81%8C%E5%8F%AF%E8%83%BD%E3%81%AB%E3%81%AA%E3%82%8A%E3%81%BE%E3%81%99%E3%80%82
            /// </summary>
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("<color=Red><size=13><b>�T�[�o�[���G���[������Ԃ��܂����B���N�G�X�g�̓T�[�o�[�Ƃ̒ʐM�ɐ������܂������A�ڑ��v���g�R���Œ�`����Ă���G���[���󂯎��܂����B</b></size></color>");
                break;

            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("<color=Red><size=13><b>�f�[�^�������ɃG���[���������܂����B���N�G�X�g�̓T�[�o�[�Ƃ̒ʐM�ɐ������܂������A��M�����f�[�^�̏������ɃG���[���������܂����B�f�[�^���j�����Ă��邩�A�������`���ł͂���܂���B</b></size></color>");
                break;

            //�����̒l���A�Ăяo���ꂽ���\�b�h�Œ�`����Ă��鋖�e�͈͊O�ł���ꍇ�ɃX���[������O�B(microsoft�����p)
            default: throw new ArgumentOutOfRangeException();

        }

        arrayTwo = ConvertCSVtoArray(request.downloadHandler.text);

        for (int i = 0; i < arrayTwo.Length; i++)
        {
            charaName.Add(arrayTwo[i][0]);

            backGroundImage.Add(arrayTwo[i][1]);

            //��l��
            displayCharaImage.Add(arrayTwo[i][2]);

/*            //��l��
            displayCharaImage.Add(arrayTwo[i][2]);
            //�O�l��
            displayCharaImage.Add(arrayTwo[i][3]);
            //�l�l��
            displayCharaImage.Add(arrayTwo[i][4]);
            //�ܐl��
            displayCharaImage.Add(arrayTwo[i][5]);*/

            /*            //��l��
                        setImage.charaImageDatas[0] = arrayTwo[i][1];
                        //��l��
                        setImage.charaImageDatas[1] = arrayTwo[i][2];
                        //�O�l��
                        setImage.charaImageDatas[2] = arrayTwo[i][3];
                        //�l�l��
                        setImage.charaImageDatas[3] = arrayTwo[i][4];
                        //�ܐl��
                        setImage.charaImageDatas[4] = arrayTwo[i][5];*/


            soundSe.Add(arrayTwo[i][7]);

            texts.Add(arrayTwo[i][8]);
        }

    }

    private void TextController()
    {
        if (currentCharNum < texts[currentLineNum].Length) DisplayText();
        else 
        {
            switch(inputType)
            {
                case InputType.InputPC : NextLineWhenButton(Input.GetMouseButtonDown(0));
                    break;
                case InputType.MobileInput: NextLineWhenButton(MobileInput.InputState(TouchPhase.Began));
                    break;
            }            
        } 
    }

    private string[][] ConvertCSVtoArray(string s)
    {
        StringReader reader = new StringReader(s);
        reader.ReadLine();  //�w�b�_�ǂݔ�΂�
        reader.ReadLine();  //�w�b�_�ǂݔ�΂�
        List<string[]> rows = new List<string[]>();
        while (reader.Peek() >= 0)
        {
            string line = reader.ReadLine();        // ��s���ǂݍ���
            string[] elements = line.Split(',');    // �s�̃Z����,�ŋ�؂���
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            rows.Add(elements);
        }
        return rows.ToArray();
    }

    private void DisplayText()
    {
        if (textInterval <= 0)
        {
            
            displayText.text += texts[currentLineNum][currentCharNum];
            Debug.Log(displayText.text);
            talkingCharaName.text = charaName[currentLineNum];

            setImage.ImageDatas[0] = backGroundImage[currentLineNum];
            setImage.ImageDatas[1] = displayCharaImage[currentLineNum];
            loadCheck = true;
           
            currentCharNum++;
            textInterval = charaSpeed * Time.deltaTime;
        }
        else textInterval--;
    }

    private void NextLineWhenButton(bool input)
    {
        if (input && !checkIfTheStoryIsOver)
        {
            SoundManager.Instance.PlaySE(0);
            currentLineNum++;

            if (currentLineNum >= lineIsTheEnd)
            {
                checkIfTheStoryIsOver = true; 
            }
            else
            {

               

                //��������0�ɂ���
                currentCharNum = 0;
                displayText.text = "";
            }
        }
    }

    /// <summary>
    /// �V�i���I�̊J�n
    /// </summary>
    public void PlayScenario(int startLine, int endLine)
    {
        currentLineNum = startLine - 3;
        lineIsTheEnd = endLine - 2;
        currentCharNum = 0;
        displayText.text = "";
        checkIfTheStoryIsOver = false;
        
        StartCoroutine(Method(SHEET_NAME));
    }

    public bool LineEndCheck()
    {
        //Debug.Log(currentLineNum + 3);
        return lineIsTheEnd > currentLineNum;
    }
}
