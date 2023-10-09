using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Calculator_V2._0
{
    class Calculator
    {
        const double pi = 3.14159265359;

        public void Start()
        {
            Title = "GEOMETRIC CALCULATOR";
            RunMainMenu();

            
        }

        private void RunMainMenu()
        {
            string prompt = @"
   ______                          __       _         ______      __           __      __            
  / ____/__  ____  ____ ___  ___  / /______(_)____   / ____/___ _/ /______  __/ /___ _/ /_____  _____
 / / __/ _ \/ __ \/ __ `__ \/ _ \/ __/ ___/ / ___/  / /   / __ `/ / ___/ / / / / __ `/ __/ __ \/ ___/
/ /_/ /  __/ /_/ / / / / / /  __/ /_/ /  / / /__   / /___/ /_/ / / /__/ /_/ / / /_/ / /_/ /_/ / /    
\____/\___/\____/_/ /_/ /_/\___/\__/_/  /_/\___/   \____/\__,_/_/\___/\__,_/_/\__,_/\__/\____/_/     
                                                                                                                                                                                                    
"; //Slant
            string[] options =
            {
                "square", "rectangle", "triangle", "circle", "cube", "cuboid", "cylinder", "pyramid", "cone", "Sphere"
            };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Square();
                    break;
                case 1:
                    Rectangle();
                    break;
                case 2:
                    Triangle();
                    break;
                case 3:
                    Circle();
                    break;
                case 4:
                    Cube();
                    break;
                case 5:
                    Cuboid();
                    break;
                case 6:
                    Cylinder(); 
                    break;
                case 7:
                    Pyramid();
                    break;
                case 8:
                    Cone();
                    break;
                case 9:
                    Sphere();
                    break;
            }
        }

        private void Square()
        {
            Square:
            var squareSidelenght = 0.0;
            Console.Clear();

            //Program Header
            string titel1 = @"
   _____                           
  / ___/____ ___  ______ _________ 
  \__ \/ __ `/ / / / __ `/ ___/ _ \
 ___/ / /_/ / /_/ / /_/ / /  /  __/
/____/\__, /\__,_/\__,_/_/   \___/ 
        /_/                        
";
            Console.Write(titel1);

            Console.Write("\nPlease enter the sidelenght in mm:");

            try
            {
                squareSidelenght = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Square;
            }

            if (squareSidelenght <= 0)
            {
                Console.WriteLine("sidelenght is <= 0!");
            }
            else
            {
                Console.WriteLine($"\n\tperimeter: {(squareSidelenght * 4):f2} mm");
                Console.WriteLine($"\tsurface:   {(squareSidelenght * 2):f2} mm2\n");
            }
        }

        private void Rectangle()
        {
            Rectangle:
            var rectangleSideA = 0.0;
            var rectangleSideB = 0.0;

            Console.Clear();

            //Program Header
            string titel1 = @"
    ____            __                    __   
   / __ \___  _____/ /_____ _____  ____ _/ /__ 
  / /_/ / _ \/ ___/ __/ __ `/ __ \/ __ `/ / _ \
 / _, _/  __/ /__/ /_/ /_/ / / / / /_/ / /  __/
/_/ |_|\___/\___/\__/\__,_/_/ /_/\__, /_/\___/ 
                                /____/                              
";
            Console.Write(titel1);

            Console.Write("\nPlease enter sidelenght A in mm:");

            try
            {
                rectangleSideA = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Rectangle;
            }

            Console.Write("please enter sidelenght B in mm:");

            try
            {
                rectangleSideB = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Rectangle;
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
                Console.WriteLine($"\n\tperimeter: {((rectangleSideA * 2) + (rectangleSideB * 2)):f2} mm");
                Console.WriteLine($"\tsurface:   {(rectangleSideA * rectangleSideB):f2} mm2\n");
            }
        }

        private void Triangle()
        {
            Triangle:
            var triangleSideA = 0.0;
            var triangleSideB = 0.0;
            var triangleSideC = 0.0;
            var triangleAlpha = 0.0;
            var triangleHeight = 0.0;

            Console.Clear();

            //Program Header
            string titel1 = @"
  ______     _                   __   
 /_  __/____(_)___ _____  ____ _/ /__ 
  / / / ___/ / __ `/ __ \/ __ `/ / _ \
 / / / /  / / /_/ / / / / /_/ / /  __/
/_/ /_/  /_/\__,_/_/ /_/\__, /_/\___/ 
                       /____/                                    
";
            Console.Write(titel1);

            Console.Write("\nPlease enter sidelenght A in mm:");

            try
            {
                triangleSideA = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Triangle;
            }

            Console.Write("please enter sidelenght B in mm:");

            try
            {
                triangleSideB = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Triangle;
            }

            Console.Write("please enter sidelenght C in mm:");

            try
            {
                triangleSideC = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Triangle;
            }

            Console.Write("please enter angle alpha in degree:");

            try
            {
                triangleAlpha = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Triangle;
            }

            if (triangleSideA <= 0)
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
            else if (triangleAlpha <= 0)
            {
                Console.WriteLine("\nangle Alpa is <= 0!");
            }
            else
            {
                triangleHeight = triangleSideB * Math.Sin(triangleAlpha);

                Console.WriteLine($"\n\theight:    {triangleHeight:f2} mm");
                Console.WriteLine($"\tperimeter: {(triangleSideA + triangleSideB + triangleSideC):f2} mm");
                Console.WriteLine($"\tsurface:   {(0.5 * triangleHeight * triangleSideC):f2} mm2\n");
            }
        }

        private void Circle()
        {
            Circle:
            var circleRadius = 0.0;

            Console.Clear();

            //Program Header
            string titel1 = @"
   _______           __   
  / ____(_)_________/ /__ 
 / /   / / ___/ ___/ / _ \
/ /___/ / /  / /__/ /  __/
\____/_/_/   \___/_/\___/                                                         
";
            Console.Write(titel1);

            Console.Write("\nPlease enter the radius in mm:");

            try
            {
                circleRadius = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Circle;
            }

            if (circleRadius <= 0)
            {
                Console.WriteLine("\nradius is <= 0!");
            }
            else
            {
                Console.WriteLine($"\n\tdiameter:  {(2 * circleRadius):f2} mm");
                Console.WriteLine($"\tperimeter: {(2 * circleRadius * pi):f2} mm");
                Console.WriteLine($"\tsurface:   {(Math.Pow(circleRadius, 2) * pi):f2} mm2\n");
            }
        }

        private void Cube()
        {
            Cube:
            var cubeSidelenght = 0.0;

            Console.Clear();

            //Program Header
            string titel1 = @"
   ______      __       
  / ____/_  __/ /_  ___ 
 / /   / / / / __ \/ _ \
/ /___/ /_/ / /_/ /  __/
\____/\__,_/_.___/\___/                                                    
";
            Console.Write(titel1);

            Console.Write("\nPlease enter the sidelenght in mm:");

            try
            {
                cubeSidelenght = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Cube;
            }

            if (cubeSidelenght <= 0)
            {
                Console.WriteLine("\nsidelenght is <= 0!");
            }
            else
            {
                Console.WriteLine($"\n\tsurface:  {(Math.Pow(cubeSidelenght, 2) * 6):f2} mm2");
                Console.WriteLine($"\tvolume:   {(Math.Pow(cubeSidelenght, 3)):f2)} mm3\n");
            }
        }

        private void Cuboid()
        {
            Cuboid:
            var cuboidSidelenghtA = 0.0;
            var cuboidSidelenghtB = 0.0;
            var cuboidSidelenghtC = 0.0;

            Console.Clear();

            //Program Header
            string titel1 = @"
   ______      __          _     __
  / ____/_  __/ /_  ____  (_)___/ /
 / /   / / / / __ \/ __ \/ / __  / 
/ /___/ /_/ / /_/ / /_/ / / /_/ /  
\____/\__,_/_.___/\____/_/\__,_/                                                   
";
            Console.Write(titel1);

            Console.Write("\nPlease enter sidelenght A in mm:");

            try
            {
                cuboidSidelenghtA = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Cuboid;
            }

            Console.Write("please enter sidelenght B in mm:");

            try
            {
                cuboidSidelenghtB = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Cuboid;
            }

            Console.Write("please enter sidelenght C in mm:");

            try
            {
                cuboidSidelenghtC = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Cuboid;
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
                Console.WriteLine($"\n\tsurface:  {(2 * (cuboidSidelenghtA * cuboidSidelenghtB + cuboidSidelenghtA * cuboidSidelenghtC + cuboidSidelenghtB * cuboidSidelenghtC)):f2} mm2");
                Console.WriteLine($"\tvolume:   {(cuboidSidelenghtA * cuboidSidelenghtB * cuboidSidelenghtC):f2} mm3\n");
            }
        }

        private void Cylinder()
        {
            Cylinder:
            var cylinderRadius = 0.0;
            var cylinderHeight = 0.0;

            Console.Clear();

            //Program Header
            string titel1 = @"
   ______      ___           __         
  / ____/_  __/ (_)___  ____/ /__  _____
 / /   / / / / / / __ \/ __  / _ \/ ___/
/ /___/ /_/ / / / / / / /_/ /  __/ /    
\____/\__, /_/_/_/ /_/\__,_/\___/_/     
     /____/                                                                              
";
            Console.Write(titel1);

            Console.Write("\nPlease enter the radius in mm:");

            try
            {
                cylinderRadius = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Cylinder;
            }

            Console.Write("please enter the height in mm:");

            try
            {
                cylinderHeight = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Cylinder;
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
                Console.WriteLine($"\n\tvolume:         {((Math.Pow(cylinderRadius, 2) * pi) * cylinderHeight):f2} mm3");
                Console.WriteLine($"\tsurface:        {((Math.Pow(cylinderRadius, 2) * pi * 2) + (2 * pi * cylinderRadius * cylinderHeight)):f2} mm2");
                Console.WriteLine($"\tbase surface:   {(Math.Pow(cylinderRadius, 2) * pi):f2} mm2");
                Console.WriteLine($"\tshell surface:  {(2 * pi * cylinderRadius * cylinderHeight):f2} mm2\n");
            }
        }

        private void Pyramid()
        {
            Pyramid:
            var pyramidSideA = 0.0;
            var pyramidHeight = 0.0;
            var pyramidHeightA = 0.0;

            Console.Clear();

            //Program Header
            string titel1 = @"
    ____                             _     __
   / __ \__  ___________ _____ ___  (_)___/ /
  / /_/ / / / / ___/ __ `/ __ `__ \/ / __  / 
 / ____/ /_/ / /  / /_/ / / / / / / / /_/ /  
/_/    \__, /_/   \__,_/_/ /_/ /_/_/\__,_/   
      /____/                                                                                                           
";
            Console.Write(titel1);

            Console.Write("\nPlease enter side A in mm:");

            try
            {
                pyramidSideA = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Pyramid;
            }

            Console.Write("please enter the height in mm:");

            try
            {
                pyramidHeight = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Pyramid;
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

                Console.WriteLine($"\n\tvolume:         {(1.0 / 3.0 * Math.Pow(pyramidSideA, 2) * pyramidHeight):f2} mm3");
                Console.WriteLine($"\tsurface:        {(Math.Pow(pyramidSideA, 2) + 2 * pyramidSideA * pyramidHeightA):f2} mm2");
                Console.WriteLine($"\tbase surface:   {(Math.Pow(pyramidSideA, 2)):f2)} mm2");
                Console.WriteLine($"\tshell surface:  {(2 * pyramidSideA * pyramidHeightA):f2} mm2\n");
            }
        }

        private void Cone()
        {
            Cone:
            var coneRadius = 0.0;
            var coneHeight = 0.0;

            Console.Clear();

            //Program Header
            string titel1 = @"
   ______               
  / ____/___  ____  ___ 
 / /   / __ \/ __ \/ _ \
/ /___/ /_/ / / / /  __/
\____/\____/_/ /_/\___/                                                                                                          
";
            Console.Write(titel1);

            Console.Write("\nPlease enter the radius in mm:");

            try
            {
                coneRadius = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Cone;
            }

            Console.Write("please enter the height in mm:");

            try
            {
                coneHeight = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Cone;
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

                Console.WriteLine($"\n\tvolume:         {(1.0 / 3.0 * (Math.Pow(coneRadius, 2) * pi) * coneHeight):f2} mm3");
                Console.WriteLine($"\tsurface:        {((Math.Pow(coneRadius, 2) * pi) + (pi * coneRadius * coneS)):f2} mm2");
                Console.WriteLine($"\tbase surface:   {(Math.Pow(coneRadius, 2) * pi):f2} mm2");
                Console.WriteLine($"\tshell surface:  {(pi * coneRadius * coneS):f2} mm2\n");
            }
        }

        private void Sphere()
        {
            Sphere:
            var sphereRadius = 0.0;

            Console.Clear();

            //Program Header
            string titel1 = @"
   _____       __                 
  / ___/____  / /_  ___  ________ 
  \__ \/ __ \/ __ \/ _ \/ ___/ _ \
 ___/ / /_/ / / / /  __/ /  /  __/
/____/ .___/_/ /_/\___/_/   \___/ 
    /_/                                                                                                                           
";
            Console.Write(titel1);

            Console.Write("\nPlease enter the radius in mm:");

            try
            {
                sphereRadius = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("\nEnter to repeat....!");
                Console.ReadLine();
                goto Sphere;
            }

            if (sphereRadius <= 0)
            {
                Console.WriteLine("\nradius is <= 0!");
            }
            else
            {
                Console.WriteLine($"\n\tvolume:    {(4.0 / 3.0 * Math.Pow(sphereRadius, 3) * pi):f2} mm3");
                Console.WriteLine($"\tsurface:   {(Math.Pow(sphereRadius, 2) * pi * 4):f2} mm2\n");
            }
        }

    }
}
