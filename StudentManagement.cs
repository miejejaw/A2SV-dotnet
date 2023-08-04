using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
public class Student
{
    public string? Name { get; set;}
    public int Age { get; set;} 
    [DataMember]
    public readonly string RollNumber;
    public double Grade { get; set;}
     public Student(string rollNumber)
    {
        RollNumber = rollNumber;
    }
}
public class StudentList
{
    private string fileName = "JsonFile.json";
    public List<Student> studentList;
    public StudentList(){
        studentList = new List<Student>();
        DeserializeFromFile();
    }

    private void SerializeToFile(){
        using (var stream = new FileStream(fileName, FileMode.Truncate)){stream.SetLength(0);}
        string jsonString = JsonConvert.SerializeObject(studentList);
        File.WriteAllText(fileName, jsonString);
    }
    private void DeserializeFromFile(){
        string jsonString = File.ReadAllText(fileName);
        List<Student>? deserializedFile = JsonConvert.DeserializeObject<List<Student>>(jsonString);
        if(deserializedFile != null)
            studentList = deserializedFile;
    }
    public void AddStudent(string name, int age, string rollNumber, double grade){
        studentList.Add(new Student(rollNumber){Name = name,Age = age,Grade = grade});
        SerializeToFile();
    }

    public void SearchStudent(string name){
       
        List<Student> students = (from student in studentList where student.Name == name select student).ToList();

        DisplayStudents(students);
    }

    public void DisplayStudents(List<Student>? students = null){
        if(students == null) 
            students = studentList;
        Console.WriteLine("STUDENTS LIST:");
        Console.WriteLine("{0,-10}{1,-10}{2,-15}{3}","NAME","AGE","ROLL NUMBER","GRADE");
        foreach (Student student in students)
        {
            Console.WriteLine("{0,-10}{1,-10}{2,-15}{3}",student.Name,student.Age,student.RollNumber,student.Grade);
        }

    }
}

public class Program
{
    public static void Main(string[] args){

        StudentList students = new StudentList();

        students.AddStudent("AAA",23,"AA4565",3.4);
        students.AddStudent("BBB",22,"BB4565",2.4);

        students.SearchStudent("AAA");
        
        students.DisplayStudents();
    }
}
