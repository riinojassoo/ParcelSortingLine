namespace ParcelSortingLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!"); 
            bool result = ParcelLineFitController(BoxSizes);

            // Output the result
            Console.WriteLine($"Does the parcel fit through all sorting lines? {result}");
        }

        public static bool ParcelLineFitController(List<BoxSize> boxSizes)
        {
            bool parcelFits = false;

            foreach (BoxSize boxSize in boxSizes) 
            {
                Console.WriteLine("New sorting line starts here: ");
                //kast - võta esimesed kaks arvu; listist boxsize võta boxsize
                //double boxDiagonal = Math.Sqrt(Math.Pow(boxSize.Length, 2) + Math.Pow(boxSize.Width, 2));
                //double halfparcelDiagonal = boxDiagonal / 2;

                var boxLengthInHalf = boxSize.Length / 2;
                var halfBoxDiagonalNotSqrt = (boxLengthInHalf * boxLengthInHalf) + (boxSize.Width * boxSize.Width);
                var halfparcelDiagonal = Math.Sqrt(halfBoxDiagonalNotSqrt);

                var lineWidth = 0;



                foreach (SortingLineParam sortingLine in boxSize.SortingLineParams)
                {
                    //toru  - sorting line-is olemas 

                    if (sortingLine.LineWidth >= halfparcelDiagonal)
                    {
                        Console.WriteLine($"Sorting line width is {sortingLine.LineWidth} and it fits (halfparcelDiagonal is {halfparcelDiagonal})");
                        parcelFits = true;

                        //d = a2 + b2 ruutjuur ja jagada 2; kui boxsize diagonaal sobib toruga ss fits mine edasi,  muidu ei

                    }
                    else
                        {
                        Console.WriteLine($"Sorting line width is {sortingLine.LineWidth} and the parcel does not fit.");
                        parcelFits = false;
           
                    }
                }
                //if (!parcelFits)
                //{
                //    Console.WriteLine("Sorting line width is {0} and the parcel does not fit.");
                //    return false;
                //}
            }


            return parcelFits;
        }


        public static readonly List<BoxSize> BoxSizes = new List<BoxSize>
        {
            new BoxSize
            {
                Length = 120,
                Width = 60,
                SortingLineParams = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        LineWidth = 100
                    },
                    new SortingLineParam
                    {
                        LineWidth = 75
                    }
                }
            },
            new BoxSize
            {
                Length = 100,
                Width = 35,
                SortingLineParams = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        LineWidth = 75
                    },
                    new SortingLineParam
                    {
                        LineWidth = 50
                    },
                    new SortingLineParam
                    {
                        LineWidth = 80
                    },
                    new SortingLineParam
                    {
                        LineWidth = 100
                    },
                    new SortingLineParam
                    {
                        LineWidth = 37
                    },
                }
            },
             new BoxSize
            {
                Length = 70,
                Width = 50,
                SortingLineParams = new List<SortingLineParam>
                {
                    new SortingLineParam
                    {
                        LineWidth = 60
                    },
                    new SortingLineParam
                    {
                        LineWidth = 60
                    },
                    new SortingLineParam
                    {
                        LineWidth = 55
                    },
                    new SortingLineParam
                    {
                        LineWidth = 90
                    },
                }
            },
        };
    }

    public class BoxSize
    {
        public int Length { get; set; }
        public int Width { get; set; }

        public List<SortingLineParam> SortingLineParams { get; set; }
            = new List<SortingLineParam>();
    }

    public class SortingLineParam
    {
        public int LineWidth { get; set; }
    }
}