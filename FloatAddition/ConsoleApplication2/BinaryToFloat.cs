using System;
public class BinaryToFloat
{/// <summary>
/// this method takes the resultant binary sum as input 
/// and converts it back to Float value
/// </summary>
/// <param name="x"></param>
/// <returns></returns>
    public double ReverseConversion(double binaryNumber)
    {
        int tempVar = 0;
        double resultFloat = 0, intPart = 0, floatPart = 0;
        long binaryInt;
        double binaryFraction;
        binaryInt = (int)binaryNumber;
        binaryFraction = binaryNumber - binaryInt;
        binaryFraction = Convert.ToInt64(binaryFraction * Math.Pow(10, 4));
        while (binaryInt != 0)
        {
            intPart = intPart + ((binaryInt % 10) * Math.Pow(2, tempVar));
            binaryInt = binaryInt / 10;
            tempVar++;
        }
        for (tempVar = 4; tempVar >= 1; tempVar--)
        {
            floatPart = floatPart + ((binaryFraction % 10) / Math.Pow(2, tempVar));
            binaryFraction = binaryFraction / 10;
        }
        resultFloat = intPart + floatPart;
        return resultFloat;
    }
}