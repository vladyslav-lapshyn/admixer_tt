class Program
{
    static int ChangeColor(int[] population, int chosenColor)
    {
        int meetings = 0;

        while (!IsMonochrome(population, chosenColor))
        {
            int colorToChange = FindColorToChange(population, chosenColor);
            int otherColor = FindOtherColor(colorToChange, chosenColor);

            if (population[colorToChange] > 0 && population[otherColor] > 0)
            {
                population[colorToChange]--;
                population[otherColor]--;
                population[chosenColor] += 2;
            }
            else if (population[colorToChange] > 1)
            {
                population[colorToChange] -= 2;
                population[chosenColor] += 2;
            }
            else
            {
                return -1;
            }

            meetings++;
        }

        return meetings;
    }

    static bool IsMonochrome(int[] population, int chosenColor)
    {
        for (int i = 0; i < population.Length; i++)
        {
            if (i != chosenColor && population[i] > 0)
            {
                return false;
            }
        }
        return true;
    }

    static int FindColorToChange(int[] population, int chosenColor)
    {
        for (int i = 0; i < population.Length; i++)
        {
            if (i != chosenColor && population[i] > 0)
            {
                return i;
            }
        }
        return -1;
    }

    static int FindOtherColor(int color1, int color2)
    {
        return 3 - color1 - color2;
    }

    static void Main()
    {
        int[] population = [8, 1, 9];
        int chosenColor = 0;
        // 0 - red
        // 1 - green
        // 2 - blue

        int result = ChangeColor(population, chosenColor);

        Console.WriteLine(result);
    }
}
