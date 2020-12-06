using System.Linq;
using System.Collections.Generic;

namespace BinaryBoarding
{
    public record Boarding(IEnumerable<int> SeatIds){

            public Boarding(IEnumerable<BoardingPass> boardingPasses):this(boardingPasses.Select(_ => _.GetSeatId()))
            {}
            
            public int GetHighestSeatId() => SeatIds.OrderByDescending(_ => _).First();
        
            public int GetMissingSeat(){
                var orderedList = SeatIds.OrderBy(x => x).ToList();

                for (var i = 1; i < orderedList.Count() - 1; i++)
                {
                    if (orderedList[i] - 1 != orderedList[i - 1])
                    {
                        return orderedList[i] - 1;
                    }
                    if (orderedList[i] + 1 != orderedList[i + 1])
                    {
                        return orderedList[i] + 1;
                    }
                }

                return 0;
            }
        }    
}
