using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int xTitelPos = 0;
            var selection = 0;

            Console.Clear();

            //Program Header
            string titel = "  Calculator v1.0  ";
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));

            //cursor position for title
            xTitelPos = (Console.WindowWidth - titel.Length) / 2;
            Console.SetCursorPosition(xTitelPos, 1);
            Console.Write(titel);

            //reset cursor position
            Console.SetCursorPosition(0, 4);
            //set console title
            Console.Title = titel;


            
            //Menu
            Console.Write("please enter the number of the shape or body you want to calculate and hit enter...\n");
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

            Console.Write("==> ");

            //check menu input
            try
            {
                selection = int.Parse(Console.ReadLine());
            }
            catch 
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

                    //Program Header
                    string titel1 = "  square calculation  ";
                    Console.WriteLine(new string('*', Console.WindowWidth - 1));

                    //cursor position for title
                    xTitelPos = (Console.WindowWidth - titel.Length) / 2;
                    Console.SetCursorPosition(xTitelPos, 0);
                    Console.Write(titel1);

                    //reset cursor position
                    Console.SetCursorPosition(0, 3);

                    Console.Write("please enter the sidelenght in mm:");

                    try
                    {
                        squareSidelenght = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    if (squareSidelenght <= 0)
                    {
                        Console.WriteLine("sidelenght is <= 0!");
                    }
                    else 
                    {
                        Console.WriteLine($"\n\tperimeter: {squareSidelenght * 4} mm");
                        Console.WriteLine($"\tsurface:   {squareSidelenght * 2} mm2\n");
                    }
                    Console.ReadLine();
                    break;

                case 2:

                    var rectangleSideA = 0;
                    var rectangleSideB = 0;

                    Console.Clear();

                    //Program Header
                    string titel2 = "  rectangle calculation  ";
                    Console.WriteLine(new string('*', Console.WindowWidth - 1));

                    //cursor position for title
                    xTitelPos = (Console.WindowWidth - titel.Length) / 2;
                    Console.SetCursorPosition(xTitelPos, 0);
                    Console.Write(titel2);

                    //reset cursor position
                    Console.SetCursorPosition(0, 3);

                    Console.Write("please enter sidelenght A in mm:");

                    try
                    {
                        rectangleSideA = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    Console.Write("please enter sidelenght B in mm:");

                    try
                    {
                        rectangleSideB = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    if (rectangleSideA <= 0)
                    {
                        Console.WriteLine("\nsidelenght A is <= 0!");
                    }
                    else if (rectangleSideB <= 0)
                    {
                        Console.WriteLine("\nsidelenght B is <= 0!");
                    }
                    else
                    {
                        Console.WriteLine($"\n\tperimeter: {(rectangleSideA * 2) + (rectangleSideB * 2)} mm");
                        Console.WriteLine($"\tsurface:   {rectangleSideA * rectangleSideB} mm2\n");
                    }
                    Console.ReadLine();
                    break;

                case 3:

                    var triangleSideA = 0;
                    var triangleSideB = 0;
                    var triangleSideC = 0;
                    var triangleAlpha = 0;
                    var triangleHeight = 0.0;

                    Console.Clear();

                    //Program Header
                    string titel3 = "  triangle calculation  ";
                    Console.WriteLine(new string('*', Console.WindowWidth - 1));

                    //cursor position for title
                    xTitelPos = (Console.WindowWidth - titel.Length) / 2;
                    Console.SetCursorPosition(xTitelPos, 0);
                    Console.Write(titel3);

                    //reset cursor position
                    Console.SetCursorPosition(0, 3);

                    Console.Write("please enter sidelenght A in mm:");

                    try
                    {
                        triangleSideA = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    Console.Write("please enter sidelenght B in mm:");

                    try
                    {
                        triangleSideB = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    Console.Write("please enter sidelenght C in mm:");

                    try
                    {
                        triangleSideC = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    Console.Write("please enter angle alpha in degree:");

                    try
                    {
                        triangleAlpha = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    if(triangleSideA <= 0)
                    {
                        Console.WriteLine("\nsidelenght A is <= 0!");
                    }
                    else if (triangleSideB <= 0)
                    {
                        Console.WriteLine("\nsidelenght B is <= 0!");
                    }
                    else if (triangleSideC <= 0)
                    {
                        Console.WriteLine("\nsidelenght C is <= 0!");
                    }
                    else if (triangleAlpha <=0)
                    {
                        Console.WriteLine("\nangle Alpa is <= 0!");
                    }
                    else
                    {
                        triangleHeight = triangleSideB * Math.Sin(triangleAlpha);

                        Console.WriteLine($"\n\theight:    {triangleHeight} mm");
                        Console.WriteLine($"\tperimeter: {triangleSideA + triangleSideB + triangleSideC} mm");
                        Console.WriteLine($"\tsurface:   {0.5 * triangleHeight * triangleSideC} mm2\n");
                    }
                    Console.ReadLine();
                    break;

                case 4:

                    var circleRadius = 0;
                    const double pi = 3.14159265359;

                    Console.Clear();

                    //Program Header
                    string titel4 = "  circle calculation  ";
                    Console.WriteLine(new string('*', Console.WindowWidth - 1));

                    //cursor position for title
                    xTitelPos = (Console.WindowWidth - titel.Length) / 2;
                    Console.SetCursorPosition(xTitelPos, 0);
                    Console.Write(titel4);

                    //reset cursor position
                    Console.SetCursorPosition(0, 3);

                    Console.Write("please enter the radius in mm:");

                    try
                    {
                        circleRadius = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    if (circleRadius <= 0)
                    {
                        Console.WriteLine("\nradius is <= 0!");
                    }
                    else
                    {
                        Console.WriteLine($"\ndiameter:  {2 * circleRadius} mm");
                        Console.WriteLine($"perimeter: {2 * circleRadius * pi} mm");
                        Console.WriteLine($"surface:   {Math.Pow(circleRadius, 2) * pi} mm2\n");
                    }
                    Console.ReadLine();
                    break;

                case 5:

                    var cubeSidelenght = 0;

                    Console.Clear();

                    //Program Header
                    string titel5 = "  cube calculation  ";
                    Console.WriteLine(new string('*', Console.WindowWidth - 1));

                    //cursor position for title
                    xTitelPos = (Console.WindowWidth - titel.Length) / 2;
                    Console.SetCursorPosition(xTitelPos, 0);
                    Console.Write(titel5);

                    //reset cursor position
                    Console.SetCursorPosition(0, 3);

                    Console.Write("please enter the sidelenght in mm:");

                    try
                    {
                        cubeSidelenght = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    if (cubeSidelenght <= 0)
                    {
                        Console.WriteLine("\nsidelenght is <= 0!");
                    }
                    else
                    {
                        Console.WriteLine($"\n\tsurface:  {Math.Pow(cubeSidelenght, 2) * 6} mm2");
                        Console.WriteLine($"\tvolume:   {Math.Pow(cubeSidelenght, 3)} mm3\n");
                    }
                    Console.ReadLine();
                    break;

                case 6:

                    var cuboidSidelenghtA = 0;
                    var cuboidSidelenghtB = 0;
                    var cuboidSidelenghtC = 0;

                    Console.Clear();

                    //Program Header
                    string titel6 = "  cuboid calculation  ";
                    Console.WriteLine(new string('*', Console.WindowWidth - 1));

                    //cursor position for title
                    xTitelPos = (Console.WindowWidth - titel.Length) / 2;
                    Console.SetCursorPosition(xTitelPos, 0);
                    Console.Write(titel6);

                    //reset cursor position
                    Console.SetCursorPosition(0, 3);

                    Console.Write("please enter sidelenght A in mm:");

                    try
                    {
                        cuboidSidelenghtA = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    Console.Write("please enter sidelenght B in mm:");

                    try
                    {
                        cuboidSidelenghtB = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    Console.Write("please enter sidelenght C in mm:");

                    try
                    {
                        cuboidSidelenghtC = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    if (cuboidSidelenghtA <= 0)
                    {
                        Console.WriteLine("\nsidelenght A is <= 0!");
                    }
                    else if (cuboidSidelenghtB <= 0)
                    {
                        Console.WriteLine("\nsidelenght B is <= 0!");
                    }
                    else if (cuboidSidelenghtC <= 0)
                    {
                        Console.WriteLine("\nsidelenght C is <= 0!");
                    }
                    else
                    {
                        Console.WriteLine($"\n\tsurface:  {2 * (cuboidSidelenghtA * cuboidSidelenghtB + cuboidSidelenghtA * cuboidSidelenghtC + cuboidSidelenghtB * cuboidSidelenghtC)} mm2");
                        Console.WriteLine($"\tvolume:   {cuboidSidelenghtA * cuboidSidelenghtB * cuboidSidelenghtC} mm3\n");
                    }
                    Console.ReadLine();
                    break;

                case 7:

                    var cylinderRadius = 0;
                    var cylinderHeight = 0;

                    Console.Clear();

                    //Program Header
                    string titel7 = "  cylinder calculation  ";
                    Console.WriteLine(new string('*', Console.WindowWidth - 1));

                    //cursor position for title
                    xTitelPos = (Console.WindowWidth - titel.Length) / 2;
                    Console.SetCursorPosition(xTitelPos, 0);
                    Console.Write(titel7);

                    //reset cursor position
                    Console.SetCursorPosition(0, 3);

                    Console.Write("please enter the radius in mm:");

                    try
                    {
                        cylinderRadius = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    Console.Write("please enter the height in mm:");

                    try
                    {
                        cylinderHeight = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    if (cylinderRadius <= 0)
                    {
                        Console.WriteLine("\nradius is <= 0!");
                    }
                    else if (cylinderHeight <= 0)
                    {
                        Console.WriteLine("\nheight is <= 0!");
                    }
                    else
                    {
                        Console.WriteLine($"\n\tvolume:         {(Math.Pow(cylinderRadius, 2) * pi) * cylinderHeight} mm3");
                        Console.WriteLine($"\tsurface:        {(Math.Pow(cylinderRadius, 2) * pi * 2) + (2 * pi * cylinderRadius * cylinderHeight)} mm2");
                        Console.WriteLine($"\tbase surface:   {Math.Pow(cylinderRadius, 2) * pi} mm2");
                        Console.WriteLine($"\tshell surface:  {2 * pi * cylinderRadius * cylinderHeight} mm2\n");
                    }
                    Console.ReadLine();
                    break;

                case 8:

                    var pyramidSideA = 0;
                    var pyramidHeight = 0;
                    var pyramidHeightA = 0.0;

                    Console.Clear();

                    //Program Header
                    string titel8 = "  pyramid calculation  ";
                    Console.WriteLine(new string('*', Console.WindowWidth - 1));

                    //cursor position for title
                    xTitelPos = (Console.WindowWidth - titel.Length) / 2;
                    Console.SetCursorPosition(xTitelPos, 0);
                    Console.Write(titel8);

                    //reset cursor position
                    Console.SetCursorPosition(0, 3);

                    Console.Write("please enter side A in mm:");

                    try
                    {
                        pyramidSideA = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    Console.Write("please enter the height in mm:");

                    try
                    {
                        pyramidHeight = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    if (pyramidSideA <= 0)
                    {
                        Console.WriteLine("\nsidelenght A is <= 0!");
                    }
                    else if (pyramidHeight <= 0)
                    {
                        Console.WriteLine("\nheight is <= 0!");
                    }
                    else
                    {
                        pyramidHeightA = Math.Sqrt(Math.Pow(pyramidHeight, 2) + (Math.Pow(pyramidSideA, 2) / 4));

                        Console.WriteLine($"\n\tvolume:         {1.0 / 3.0 * Math.Pow(pyramidSideA, 2) * pyramidHeight} mm3");
                        Console.WriteLine($"\tsurface:        {Math.Pow(pyramidSideA, 2) + 2 * pyramidSideA * pyramidHeightA} mm2");
                        Console.WriteLine($"\tbase surface:   {Math.Pow(pyramidSideA, 2)} mm2");
                        Console.WriteLine($"\tshell surface:  {2 * pyramidSideA * pyramidHeightA} mm2\n");
                    }
                    Console.ReadLine();
                    break;

                case 9:

                    var coneRadius = 0;
                    var coneHeight = 0;

                    Console.Clear();

                    //Program Header
                    string titel9 = "  cone calculation  ";
                    Console.WriteLine(new string('*', Console.WindowWidth - 1));

                    //cursor position for title
                    xTitelPos = (Console.WindowWidth - titel.Length) / 2;
                    Console.SetCursorPosition(xTitelPos, 0);
                    Console.Write(titel9);

                    //reset cursor position
                    Console.SetCursorPosition(0, 3);

                    Console.Write("please enter the radius in mm:");

                    try
                    {
                        coneRadius = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    Console.Write("please enter the height in mm:");

                    try
                    {
                        coneHeight = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    if (coneRadius <= 0)
                    {
                        Console.WriteLine("\nradius is <= 0!");
                    }
                    else if (coneHeight <= 0)
                    {
                        Console.WriteLine("\nheight is <= 0!");
                    }
                    else
                    {
                        var coneS = Math.Sqrt(Math.Pow(coneHeight, 2) + Math.Pow(coneRadius, 2));

                        Console.WriteLine($"\n\tvolume:         {1.0 / 3.0 * (Math.Pow(coneRadius, 2) * pi) * coneHeight} mm3");
                        Console.WriteLine($"\tsurface:        {(Math.Pow(coneRadius, 2) * pi) + (pi * coneRadius * coneS)} mm2");
                        Console.WriteLine($"\tbase surface:   {Math.Pow(coneRadius, 2) * pi} mm2");
                        Console.WriteLine($"\tshell surface:  {pi * coneRadius * coneS} mm2\n");
                    }
                    Console.ReadLine();
                    break;

                case 10:

                    var sphereRadius = 0;

                    Console.Clear();

                    //Program Header
                    string titel10 = "  sphere calculation  ";
                    Console.WriteLine(new string('*', Console.WindowWidth - 1));

                    //cursor position for title
                    xTitelPos = (Console.WindowWidth - titel.Length) / 2;
                    Console.SetCursorPosition(xTitelPos, 0);
                    Console.Write(titel10);

                    //reset cursor position
                    Console.SetCursorPosition(0, 3);

                    Console.Write("please enter the radius in mm:");

                    try
                    {
                        sphereRadius = int.Parse(Console.ReadLine());
                    }
                    catch 
                    {
                        Console.WriteLine("the entered value is not valid!");
                        Console.ReadLine();
                        break;
                    }

                    if (sphereRadius <= 0)
                    {
                        Console.WriteLine("\nradius is <= 0!");
                    }
                    else
                    {
                        Console.WriteLine($"\n\tvolume:    {4.0 / 3.0 * Math.Pow(sphereRadius, 3) * pi} mm3");
                        Console.WriteLine($"\tsurface:   {Math.Pow(sphereRadius, 2) * pi * 4} mm2\n");
                    }
                    Console.ReadLine();
                    break;
            }
        }
    }
}