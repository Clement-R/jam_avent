using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{

    private static string[] wordList = { "chocolate",
"truck",
"doll",
"candys",
"socks",
"helicopter",
"sweat",
"money",
"dinosaures",
"peluche",
"games",
"computer",
"pens",
"books",
"dvd",
"scarf",
"gloves",
"glasses",
"hat",
"necklace",
"legos",
"hut",
"puzzle",
"guitar",
"robot",
"bag", "flowers",
"bookmark",
"lamp",
"sandal",
"shoes",
"pants",
"piano",
"pillow",
"bow",
"mirror",
"candle",
"rug",
"flag",
"camera",
"cards",
"phone",
"bananas",
"train",
"purse",
"clothes",
"canvas",
"speakers",
"helmet",
"box",
"perfume",
"radio",
"puppet",
"ball",
"trampoline",
"pool",
"castle",
"figurines"};

    public static string GetRandomWord ()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }

}
