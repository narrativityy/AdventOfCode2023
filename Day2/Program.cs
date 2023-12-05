
int PossibleGames(List<string> Input) {
    int Sum = 0;

    int PossibleRed = 12;
    int PossibleGreen = 13;
    int PossibleBlue = 14;

    int RedCounter = 0;
    int GreenCounter = 0;
    int BlueCounter = 0;

    int MaxRed = 0;
    int MaxGreen = 0;
    int MaxBlue = 0;

    int Power = 0;
    int PowerSum = 0;

    int Num;
    int Id;
    int Counter;
    Boolean Flag;

    foreach (string Game in Input) {
        RedCounter = 0;
        GreenCounter = 0;
        BlueCounter = 0;

        MaxRed = 0;
        MaxGreen = 0;
        MaxBlue = 0;

        Num = 0;
        Id = 0;
        Counter = 5;
        Flag = true;

        while (Char.IsNumber(Game[Counter])) {
            Id *= 10;
            Id += Game[Counter] - '0';
            Counter++;
        }
        
        for (int i = Counter; i < Game.Length; i++) {
            if (Game[i] == ';' || i == Game.Length - 1) {
                if ((RedCounter <= PossibleRed && GreenCounter <= PossibleGreen && BlueCounter <= PossibleBlue)) {
                    RedCounter = 0;
                    GreenCounter = 0;
                    BlueCounter = 0;
                }
                else {
                    Flag = false;
                    RedCounter = 0;
                    GreenCounter = 0;
                    BlueCounter = 0;
                }
            }
            else {
                while (Char.IsNumber(Game[i])) {
                    Num *= 10;
                    Num += Game[i] - '0';
                    i++;
                }
                if (Char.IsNumber(Game[i - 1])) {
                    if (Game[i + 1] == 'r') {
                        RedCounter += Num;
                        if (RedCounter > MaxRed) {
                            MaxRed = RedCounter;
                        }
                    }
                    else if (Game[i + 1] == 'g') {
                        GreenCounter += Num;
                        if (GreenCounter > MaxGreen) {
                            MaxGreen = GreenCounter;
                        }
                    }
                    else {
                        BlueCounter += Num;
                        if (BlueCounter > MaxBlue) {
                            MaxBlue = BlueCounter;
                        }
                    }
                    Num = 0;
                }
            }
        }
        PowerSum += (MaxRed * MaxGreen * MaxBlue);
        System.Console.WriteLine($"MaxRed: {MaxRed} MaxGreen: {MaxGreen} MaxBlue: {MaxBlue}");
        if (Flag) {
            Sum += Id;
        }


    }
    System.Console.WriteLine(PowerSum);
    return Sum;
}

List<string> Input1 = new List<string>() {
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
    "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
    "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
    "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
    "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
};

List<string> Input2 = new List<string>();
string? line;

StreamReader file = new StreamReader("Input.txt");

while ((line = file.ReadLine()) != null) {
    Input2.Add(line);
}

System.Console.WriteLine(PossibleGames(Input2));