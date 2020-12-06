using System.Collections.Generic;
using System.Linq;

namespace ReportRepair
{
    public record Report(List<int> ReportEntry){
        private const int TargetValue = 2020;

        public Report(IEnumerable<string> reportEntry):this(reportEntry.Select(_ => int.Parse(_)).ToList())
        {}

        public int FindPairMatching(){
            for (var i = 0; i < ReportEntry.Count; i++)
            {
                for (var j = 0; j < ReportEntry.Count; j++)
                {
                    if (i == j) continue;

                    if (ReportEntry[i] + ReportEntry[j] == TargetValue)
                        return ReportEntry[i] * ReportEntry[j];
                }
            }

            return 0;
        }

        public int FindTripletMatching(){
            for (var i = 0; i < ReportEntry.Count; i++)
            {
                for (var j = 0; j < ReportEntry.Count; j++)
                {

                    for (var k = 0; k < ReportEntry.Count; k++)
                    {
                        if (i == j || i == k || j == k) continue;

                        if (ReportEntry[i] + ReportEntry[j] + ReportEntry[k] == TargetValue)
                            return ReportEntry[i] * ReportEntry[j] * ReportEntry[k];
                    }
                }
            }

            return 0;
        }
        
    }
}
