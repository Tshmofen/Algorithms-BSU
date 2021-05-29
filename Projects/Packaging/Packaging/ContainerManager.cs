using System.Collections.Generic;
using System.Linq;

namespace Packaging
{
    public static class ContainerManager
    {
        public static List<Container> PerformNextFit(IEnumerable<double> numbers)
        {
            var containers = new List<Container> { new() };
            
            foreach (var number in numbers)
            {
                if (!containers.Last().Add(number))
                {
                    var newContainer = new Container();
                    newContainer.Add(number);
                    containers.Add(newContainer);
                }
            }

            return containers;
        }

        public static List<Container> PerformFirstFit(IEnumerable<double> numbers)
        {
            var containers = new List<Container> { new() };
            
            foreach (var number in numbers)
            {
                for (var i = 0; i < containers.Count; i++)
                {
                    if (containers[i].Add(number)) break;
                    if (i == containers.Count - 1)
                    {
                        var newContainer = new Container();
                        newContainer.Add(number);
                        containers.Add(newContainer);
                        break;
                    }
                }
            }

            return containers;
        }

        public static List<Container> PerformFirstFitDecrease(IEnumerable<double> numbers) 
            => PerformFirstFit(numbers.OrderByDescending(number => number));
        
        public static List<Container> PerformBestFit(IEnumerable<double> numbers) 
        {
            var containers = new List<Container> { new() };
            
            foreach (var number in numbers)
            {
                var bestContainerIndex = 0;
                var minDifference = double.MaxValue;

                for (var i = 0; i < containers.Count; i++)
                {
                    var difference = containers[i].Available - number;
                    if (difference >= 0 && difference < minDifference)
                    {
                        bestContainerIndex = i;
                        minDifference = difference;
                    }
                }
                
                if (!containers[bestContainerIndex].Add(number))
                {
                    var newContainer = new Container();
                    newContainer.Add(number);
                    containers.Add(newContainer);
                }
            }

            return containers;
        }
    }
}