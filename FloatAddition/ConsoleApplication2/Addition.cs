using System;
public class Addition
{/// <summary>
/// this method takes two double values containing binary numbers as input,
/// performs binary addition on the numbers and return the binary sum
/// </summary>
/// <param name="x"></param>
/// <param name="y"></param>
/// <returns></returns>
    public double Add(double firstNumber, double secondNumber)
    {
        double binarySum;
        long tempVar = 1, firstInt, secondInt;
        long carryVar = 0;
        firstInt = Convert.ToInt64(firstNumber * Math.Pow(10, 4));
        secondInt = Convert.ToInt64(secondNumber * Math.Pow(10, 4));
        while (firstInt != 0 && secondInt != 0)
        {
            if (firstInt % 10 == 0 && secondInt % 10 == 0)
            {
                if (carryVar == 0)
                {
                    tempVar = tempVar * 10;
                }
                else
                {
                    tempVar = (tempVar * 10) + 1;
                    carryVar = 0;
                }
            }
            else if ((firstInt % 10 == 1 && secondInt % 10 == 0) || (firstInt % 10 == 0 && secondInt % 10 == 1))
            {
                if (carryVar == 0)
                {
                    tempVar = (tempVar * 10) + 1;
                }
                else
                {
                    tempVar = tempVar * 10;
                    carryVar = 1;
                }
            }
            else if (firstInt % 10 == 1 && secondInt % 10 == 1)
            {
                if (carryVar == 1)
                {
                    tempVar = (tempVar * 10) + 1;
                }
                else
                {
                    tempVar = tempVar * 10;
                    carryVar = 1;
                }
            }
            firstInt = firstInt / 10;
            secondInt = secondInt / 10;
        }
        tempVar = tempVar * 10 + carryVar;
        binarySum = 0;
        while (tempVar != 0)
        {
            carryVar = tempVar % 10;
            binarySum = binarySum * 10 + carryVar;
            tempVar = tempVar / 10;
        }
        binarySum = binarySum / 100000;
        return binarySum;
    }
}