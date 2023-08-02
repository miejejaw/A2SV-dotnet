using System;
using System.Collections.Generic;

public class Program
{
    public static bool IsPalindrom(string word){
        int length = word.Length;
        int beg=0,end=length-1;
        while(beg<end){
            while(beg<end && !Char.IsLetter(word[beg])) beg++;
            while(beg<end && !Char.IsLetter(word[end])) end--;

            if(word[beg] != word[end]){
                return false;
            }
            beg++;
            end--;
        }

        return true;
    }

    public static void Main()
    {
        Console.WriteLine("Enter word: ");
        string word = Console.ReadLine().ToUpper();

        if(IsPalindrom(word)){
            Console.WriteLine("Yes it is palindrom");
        }else{
            Console.WriteLine("No it not palindrom");
        }

    }
}
