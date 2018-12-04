using System;
public class FloatTobinary
{/// <summary>
/// this method takes a float value as input and 
/// converts into binary and returns the binary values
/// </summary>
/// <param name="xy"></param>
/// <returns></returns>
    public double Conversion(double floatNumber)
    {
        double binaryNumber = 0, binaryFraction = 1;
        long binaryInt = 0, tempVar = 1;
        long intPart = (int)floatNumber;
        double fractionPart = floatNumber - intPart;

        while (intPart > 0)
        {
            if (intPart % 2 == 0)
            {
                intPart = intPart / 2;
                tempVar = tempVar * 10;
            }
            else
            {
                intPart = intPart / 2;
                tempVar = (tempVar * 10) + 1;
            }
        }
        binaryInt = 0;
        while (tempVar != 0)
        {
            binaryInt = binaryInt * 10 + tempVar % 10;
            tempVar = tempVar / 10;
        }
        binaryInt = binaryInt / 10;
        tempVar = 0;
        int[] Bif = new int[4];
        while (tempVar < 4)
        {
            if (fractionPart * 2 < 1.0)
            {
                fractionPart = fractionPart * 2;
                Bif[tempVar] = 0;
                tempVar++;
            }
            else if (fractionPart * 2 > 1.0)
            {
                fractionPart = (fractionPart * 2) - 1;
                Bif[tempVar] = 1;
                tempVar++;
            }
            else if (fractionPart * 2 == 1.0)
            {
                fractionPart = fractionPart * 2 - 1;
                Bif[tempVar] = 1;
                tempVar++;
            }
        }
        tempVar = 0;
        binaryFraction = 1;
        while (tempVar < 4)
        {
            binaryFraction = binaryFraction * 10 + Bif[tempVar];
            tempVar++;
        }
        binaryFraction = binaryFraction / Math.Pow(10, 4);
        binaryNumber = binaryInt + binaryFraction - 1;
        return binaryNumber;
    }
}