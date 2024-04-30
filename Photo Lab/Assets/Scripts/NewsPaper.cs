using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class NewsPaper : MonoBehaviour
{
    public int actualNewsPaperID;

    [Header("Article 1")]
    public TMP_Text textHeadLine1;
    public TMP_Text textArticle1;
    public GameObject imageArticle1;
    
    [Header("Article 2")]
    public TMP_Text textHeadLine2;
    public TMP_Text textArticle2;
    public GameObject imageAd;

    [Header("Images Lists")]
    public Sprite[] allArticleImages;
    public Sprite[] allAdImages;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        textHeadLine1.text = LocalizationSettings.StringDatabase.GetLocalizedString("DialogTable", "ManPrin_Jornal_" + actualNewsPaperID.ToString());
        textArticle1.text = LocalizationSettings.StringDatabase.GetLocalizedString("DialogTable", "MatPrin_Jornal_" + actualNewsPaperID.ToString());
        textHeadLine2.text = LocalizationSettings.StringDatabase.GetLocalizedString("DialogTable", "ManSec_Jornal_" + actualNewsPaperID.ToString());
        textArticle2.text = LocalizationSettings.StringDatabase.GetLocalizedString("DialogTable", "MatSec_Jornal_" + actualNewsPaperID.ToString());
        imageArticle1.GetComponent<Image>().sprite = allArticleImages[0]; //#G: No futuro usar o actualNewsPaperID para puxar a foto 
        imageAd.GetComponent<Image>().sprite = allArticleImages[0]; //#G: No futuro usar o actualNewsPaperID para puxar a foto

    }

        // Update is called once per frame
        void Update()
    {
        
    }
}