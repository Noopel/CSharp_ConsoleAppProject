using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_CSharpProject
{
    internal class SchoolGradingSystem
    {
        public static void Start() 
        {
            // We prompt the user to enter the student name 
            Console.WriteLine("Enter student name:");
            Console.Write("> ");

            string? name = Console.ReadLine();
            int[] grades = new int[5];
            int sumOfGrades = 0;

            // We make the user enter 5 grades and then store that in an int array
            Console.WriteLine("Enter the students grades for 5 subjects");

            for (int i = 0; i < 5; i++) 
            {
                Console.Write($"[{i+1}] > ");
                int grade = Convert.ToInt32(Console.ReadLine());

                grades[i] = grade;
                sumOfGrades += grade;
            }

            // We then calculate the average grade based on the sum collected in the loop
            int averageGrade = sumOfGrades / 5;

            Console.WriteLine("");

            // We use the averageGrade in a switch case to tell the user how they performed
            switch (averageGrade) 
            { 
                case < 4: // Anything less than 4
                    Console.WriteLine("Under passed");
                    break;
                case < 7: // Between 4-6
                    Console.WriteLine("Passed");
                    break;
                case < 10: // Between 7-9
                    Console.WriteLine("Above average");
                    break;
                case > 10: // Anything 10 and above
                    Console.WriteLine("Excellent!");
                    break;

            }

            // Lastly we show the user their average, highest and lowest grade and tell them how many grades were above their average
            Console.WriteLine("");
            Console.WriteLine($"Student: {name}");
            Console.WriteLine("");
            Console.WriteLine($"Average grade: {averageGrade}");
            Console.WriteLine($"Highest grade: {grades.Max()}");
            Console.WriteLine($"Lowest grade: {grades.Min()}");

            int gradesAboveAverage = 0;

            for (int i = 0; i < 5; i++) 
            {
                int grade = grades[i];
                if (grade > averageGrade) 
                {
                    gradesAboveAverage++;
                    Console.WriteLine($"Your grade {grade} in [{i+1}] is above average!");
                }
            }

            Console.WriteLine($"You have a total of {gradesAboveAverage} grades above average");
        }
    }
}
