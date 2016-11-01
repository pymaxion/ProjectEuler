using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public static class Problem61
    {
        public static string Solve()
        {
            HashSet<string> possTriangles = new HashSet<string>(SequenceUtils.GenerateTriangleNumbersLessThanN(10000)
                .Where(n => n >= 1000 && n < 10000).Select(n => n.ToString()).ToList());
            HashSet<string> possSquares = new HashSet<string>(SequenceUtils.GenerateSquareNumbersLessThanN(10000)
                .Where(n => n >= 1000 && n < 10000).Select(n => n.ToString()).ToList());
            HashSet<string> possPentagons = new HashSet<string>(SequenceUtils.GeneratePentagonNumbersLessThanN(10000)
                .Where(n => n >= 1000 && n < 10000).Select(n => n.ToString()).ToList());
            HashSet<string> possHexagons = new HashSet<string>(SequenceUtils.GenerateHexagonNumbersLessThanN(10000)
                .Where(n => n >= 1000 && n < 10000).Select(n => n.ToString()).ToList());
            HashSet<string> possHeptagons = new HashSet<string>(SequenceUtils.GenerateHeptagonNumbersLessThanN(10000)
                .Where(n => n >= 1000 && n < 10000).Select(n => n.ToString()).ToList());
            HashSet<string> possOctagons = new HashSet<string>(SequenceUtils.GenerateOctagonNumbersLessThanN(10000)
                .Where(n => n >= 1000 && n < 10000).Select(n => n.ToString()).ToList());

            Dictionary<int, HashSet<string>> polygonalNumberDict = new Dictionary<int, HashSet<string>>
            {
                { 3, possTriangles },
                { 4, possSquares },
                { 5, possPentagons },
                { 6, possHexagons },
                { 7, possHeptagons },
                { 8, possOctagons },
            };

            List<List<string>> finalAnswerCandidates = new List<List<string>>();

            var polygonalPermutations = Combinatorics.GetFullPermutations(polygonalNumberDict.Keys);
            foreach (var permutation in polygonalPermutations)
            {
                List<List<string>> sequences = new List<List<string>>();
                var permutationKeys = permutation.ToArray();
                var startSet = polygonalNumberDict[permutationKeys[0]];

                // initialize sequences
                foreach (string polygNum in new List<string>(startSet))
                {
                    sequences.Add(new List<string> { polygNum });
                }

                // loop and expand sequences if possible
                bool quitEarly = false;
                for (int i = 1; i < permutationKeys.Length; i++)
                {
                    var nextSet = polygonalNumberDict[permutationKeys[i]];
                    List<List<string>> nextSequences = new List<List<string>>();
                    foreach (List<string> sequence in sequences) 
                    {
                        var nextSetCandidates = nextSet.Where(x => sequence.Last().IsCyclicWith(x)).ToList();
                        if (nextSetCandidates.Count > 0)
                        {
                            foreach (string nextSetFound in nextSetCandidates)
                            {
                                sequence.Add(nextSetFound);
                                nextSequences.Add(sequence);
                            }
                        }
                    }

                    if (nextSequences.Count == 0)
                    {
                        quitEarly = true;
                        break;
                    }
                    else
                    {
                        sequences = nextSequences;
                    }
                }

                if (!quitEarly)
                {
                    finalAnswerCandidates.AddRange(sequences);
                }
            }

            var finalAnswer = finalAnswerCandidates.Where(x => x.Last().IsCyclicWith(x.First())).First();
            return finalAnswer.Sum(x => Int32.Parse(x)).ToString();
        }

        public static bool IsCyclicWith(this string firstNum, string secondNum)
        {
            return secondNum.StartsWith(firstNum.Substring(2, 2));
        }
    }
}
