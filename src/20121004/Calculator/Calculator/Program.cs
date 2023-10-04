using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var selection = 0;

            Console.WriteLine("Please enter the number of the shape or body you want to calculate and hit enter...\n");
            Console.WriteLine("1 ... square");
            Console.WriteLine("2 ... rectangle");
            Console.WriteLine("3 ... triangle");
            Console.WriteLine("4 ... circle\n");

            Console.WriteLine("5 ... cube");
            Console.WriteLine("6 ... cuboid");
            Console.WriteLine("7 ... cylinder");
            Console.WriteLine("8 ... pyramid");
            Console.WriteLine("9 ... cone");
            Console.WriteLine("10... sphere\n");

            try
            {
                selection = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"{selection} is not a number!");
            }

            if (selection < 1 || selection > 10)
            {
                Console.WriteLine($"{selection} is not a valid selection!");
            }

            switch (selection)

            {
                case 1:

                    var squareSidelenght = 0;
                    Console.Clear();
                    Console.WriteLine("...square calculation...\n");
                    Console.WriteLine("please enter the sidelenght in mm:");

                    try
                    {
                        squareSidelenght = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 1;
                    }

                    Console.WriteLine($"\nperimeter: {squareSidelenght * 4} mm");
                    Console.WriteLine($"surface:   {squareSidelenght * 2} mm2\n");
                    break;

                case 2:

                    var rectangleSideA = 0;
                    var rectangleSideB = 0;

                    Console.Clear();
                    Console.WriteLine("...rectangle calculation...\n");
                    Console.WriteLine("please enter sidelenght A in mm:");

                    try
                    {
                        rectangleSideA = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 2;
                    }

                    Console.WriteLine("please enter sidelenght B in mm:");

                    try
                    {
                        rectangleSideB = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 2;
                    }

                    Console.WriteLine($"\nperimeter: {(rectangleSideA * 2) + (rectangleSideB * 2)} mm");
                    Console.WriteLine($"surface:   {rectangleSideA * rectangleSideB} mm2\n");
                    break;

                case 3:

                    var triangleSideA = 0;
                    var triangleSideB = 0;
                    var triangleSideC = 0;
                    var triangleAlpha = 0;
                    var triangleHeight = 0.0;

                    Console.Clear();
                    Console.WriteLine("...triangle calculation...\n");
                    Console.WriteLine("please enter sidelenght A in mm:");

                    try
                    {
                        triangleSideA = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 3;
                    }

                    Console.WriteLine("please enter sidelenght B in mm:");

                    try
                    {
                        triangleSideB = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 3;
                    }

                    Console.WriteLine("please enter sidelenght C in mm:");

                    try
                    {
                        triangleSideC = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 3;
                    }

                    Console.WriteLine("please enter angle alpha in degree:");

                    try
                    {
                        triangleAlpha = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 3;
                    }

                    triangleHeight = triangleSideB * Math.Sin(triangleAlpha);

                    Console.WriteLine($"\nheight:    {triangleHeight} mm");
                    Console.WriteLine($"perimeter: {triangleSideA + triangleSideB + triangleSideC} mm");
                    Console.WriteLine($"surface:   {0.5 * triangleHeight * triangleSideC} mm2\n");
                    break;

                case 4:

                    var circleRadius = 0;
                    const double pi = 3.14159265359;

                    Console.Clear();
                    Console.WriteLine("...circle calculation...\n");
                    Console.WriteLine("please enter the radius in mm:");

                    try
                    {
                        circleRadius = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 4;
                    }

                    Console.WriteLine($"\ndiameter:  {2 * circleRadius} mm");
                    Console.WriteLine($"perimeter: {2 * circleRadius * pi} mm");
                    Console.WriteLine($"surface:   {Math.Pow(circleRadius, 2) * pi} mm2\n");
                    break;

                case 5:

                    var cubeSidelenght = 0;

                    Console.Clear();
                    Console.WriteLine("...cube calculation...\n");
                    Console.WriteLine("please enter the sidelenght in mm:");

                    try
                    {
                        cubeSidelenght = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 5;
                    }

                    Console.WriteLine($"\nsurface:  {Math.Pow(cubeSidelenght, 2) * 6} mm2");
                    Console.WriteLine($"volume:   {Math.Pow(cubeSidelenght, 3)} mm3\n");
                    break;

                case 6:

                    var cuboidSidelenghtA = 0;
                    var cuboidSidelenghtB = 0;
                    var cuboidSidelenghtC = 0;

                    Console.Clear();
                    Console.WriteLine("...cube calculation...\n");
                    Console.WriteLine("please enter sidelenght A in mm:");

                    try
                    {
                        cuboidSidelenghtA = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 6;
                    }

                    Console.WriteLine("please enter sidelenght B in mm:");

                    try
                    {
                        cuboidSidelenghtB = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 6;
                    }

                    Console.WriteLine("please enter sidelenght C in mm:");

                    try
                    {
                        cuboidSidelenghtC = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 6;
                    }

                    Console.WriteLine($"\nsurface:  {2 * (cuboidSidelenghtA * cuboidSidelenghtB + cuboidSidelenghtA * cuboidSidelenghtC + cuboidSidelenghtB * cuboidSidelenghtC)} mm2");
                    Console.WriteLine($"volume:   {cuboidSidelenghtA * cuboidSidelenghtB * cuboidSidelenghtC} mm3\n");
                    break;

                case 7:

                    var cylinderRadius = 0;
                    var cylinderHeight = 0;

                    Console.Clear();
                    Console.WriteLine("...cylinder calculation...\n");
                    Console.WriteLine("please enter the radius in mm:");

                    try
                    {
                        cylinderRadius = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 7;
                    }

                    Console.WriteLine("please enter the height in mm:");

                    try
                    {
                        cylinderHeight = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 7;
                    }

                    Console.WriteLine($"\nvolume:         {(Math.Pow(cylinderRadius, 2) * pi) * cylinderHeight} mm3");
                    Console.WriteLine($"surface:        {(Math.Pow(cylinderRadius, 2) * pi * 2) + (2 * pi * cylinderRadius * cylinderHeight)} mm2");
                    Console.WriteLine($"base surface:   {Math.Pow(cylinderRadius, 2) * pi} mm2");
                    Console.WriteLine($"shell surface:  {2 * pi * cylinderRadius * cylinderHeight} mm2\n");
                    break;

                case 8:

                    var pyramidSideA = 0;
                    var pyramidHeight = 0;
                    var pyramidHeightA = 0.0;

                    Console.Clear();
                    Console.WriteLine("...pyramid calculation...\n");
                    Console.WriteLine("please enter side A in mm:");

                    try
                    {
                        pyramidSideA = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 8;
                    }

                    Console.WriteLine("please enter the height in mm:");

                    try
                    {
                        pyramidHeight = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 8;
                    }

                    pyramidHeightA = Math.Sqrt(Math.Pow(pyramidHeight, 2) + (Math.Pow(pyramidSideA, 2) / 4));

                    Console.WriteLine($"\nvolume:         {1.0 / 3.0 * Math.Pow(pyramidSideA, 2) * pyramidHeight} mm3");
                    Console.WriteLine($"surface:        {Math.Pow(pyramidSideA, 2) + 2 * pyramidSideA * pyramidHeightA} mm2");
                    Console.WriteLine($"base surface:   {Math.Pow(pyramidSideA, 2)} mm2");
                    Console.WriteLine($"shell surface:  {2 * pyramidSideA * pyramidHeightA} mm2\n");
                    break;

                case 9:

                    var coneRadius = 0;
                    var coneHeight = 0;

                    Console.Clear();
                    Console.WriteLine("...cone calculation...\n");
                    Console.WriteLine("please enter the radius in mm:");

                    try
                    {
                        coneRadius = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 9;
                    }

                    Console.WriteLine("please enter the height in mm:");

                    try
                    {
                        coneHeight = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 9;
                    }

                    var coneS = Math.Sqrt(Math.Pow(coneHeight, 2) + Math.Pow(coneRadius, 2));

                    Console.WriteLine($"\nvolume:         {1.0 / 3.0 * (Math.Pow(coneRadius, 2) * pi) * coneHeight} mm3");
                    Console.WriteLine($"surface:        {(Math.Pow(coneRadius, 2) * pi) + (pi * coneRadius * coneS)} mm2");
                    Console.WriteLine($"base surface:   {Math.Pow(coneRadius, 2) * pi} mm2");
                    Console.WriteLine($"shell surface:  {pi * coneRadius * coneS} mm2\n");
                    break;

                case 10:

                    var sphereRadius = 0;

                    Console.Clear();
                    Console.WriteLine("...sphere calculation...\n");
                    Console.WriteLine("please enter the radius in mm:");

                    try
                    {
                        sphereRadius = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("the entered value is not valid.....hit enter to repeat");
                        Console.ReadLine();
                        goto case 10;
                    }

                    Console.WriteLine($"\nvolume:    {4.0 / 3.0 * Math.Pow(sphereRadius, 3) * pi} mm3");
                    Console.WriteLine($"surface:   {Math.Pow(sphereRadius, 2) * pi * 4} mm2\n");
                    break;
            }
        }
    }
}
