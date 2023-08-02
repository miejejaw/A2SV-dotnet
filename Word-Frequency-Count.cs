using System;
using System.Collections.Generic;

public class Program
{
    public static Dictionary<string, int> CountWord(string word){

        int length = word.Length;
        Dictionary<string, int> wordFreq = new Dictionary<string,int>();

        for(int i = 0; i < length; i++){
            string temp = "";
            while(i < length && word[i] != ' '){
                if(Char.IsLetter(word[i])){
                    temp += word[i];
                }
                i++;
            }

            if (wordFreq.ContainsKey(temp)){
                wordFreq[temp]++;
            }else
            {
                wordFreq[temp] = 1;
            }
        }
        return wordFreq;
    }

    public static void Main()
    {
        Console.WriteLine("Enter word: ");
        string sentence = Console.ReadLine().ToUpper();

        Dictionary<string, int> wordFreq = CountWord(sentence);

        Console.WriteLine("word     count");
        foreach (KeyValuePair<string, int> entry in wordFreq)
        {
            Console.WriteLine("{0,-12} {1}", entry.Key, entry.Value);
        }
    }
}
