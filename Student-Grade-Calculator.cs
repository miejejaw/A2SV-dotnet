using System;
using System.Collections.Generic;

public class Student
{
    public string Name { get; set; }
    public float SubjectCount { get; set; }
    public Dictionary<string, float> Grade;

    public Student(string name, int subjCount)
    {
        Name = name;
        SubjectCount = subjCount;
        Grade = new Dictionary<string, float>();
    }

    public float CalAvg()
    {
        float total = 0f;
        foreach (KeyValuePair<string, float> entry in Grade)
        {
            total += entry.Value;
        }
        return total / SubjectCount;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter your name: ");
        string studentName = Console.ReadLine();

        Console.WriteLine("Enter the number of subjects you have taken: ");
        int subjectCount = int.Parse(Console.ReadLine());

        Student stud = new Student(studentName, subjectCount);

        while (subjectCount > 0)
        {
            Console.WriteLine("Enter name of the subject: ");
            string subjectName = Console.ReadLine();

            Console.WriteLine($"Enter your {subjectName} grade: ");
            float subjectGrade = float.Parse(Console.ReadLine());

            while(subjectGrade>4 || subjectGrade<0){
                Console.WriteLine($"Invalid grade Enter your {subjectName} grade again: ");
                subjectGrade = float.Parse(Console.ReadLine());
            }

            stud.Grade[subjectName] = subjectGrade;
            subjectCount--;
        }

        Console.WriteLine($"Student Name: {stud.Name}");
        Console.WriteLine("Subject Name   Grade");
        foreach (KeyValuePair<string, float> entry in stud.Grade)
        {
            Console.WriteLine("{0,-15} {1}", entry.Key, entry.Value);
        }
        Console.WriteLine($"Average: {stud.CalAvg()}");
    }
}


// Write test for your code [Optional]






