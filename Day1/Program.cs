using System.Data;

string? line;
string[] alphaNums = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
int[] nums = {1, 2, 3, 4, 5, 6, 7, 8, 9};
int firstNumber = -1;
int lastNumber = -1;
int sum = 0;

System.IO.StreamReader file =  new System.IO.StreamReader("input.txt");

while((line = file.ReadLine()) != null)
{
    firstNumber = -1;
    lastNumber = -1;
    foreach (char Character in line) {
        if (Char.IsNumber(Character)) {
            if (firstNumber == -1) {
                firstNumber = (Character - '0') * 10;
            }
            lastNumber = Character - '0';
        }
   }
   sum += (firstNumber + lastNumber);
}

file.Close();

System.Console.WriteLine(sum);