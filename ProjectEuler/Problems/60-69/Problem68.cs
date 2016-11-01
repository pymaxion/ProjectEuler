using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public static class Problem68
    {
        private static readonly int[] Nodes = Enumerable.Range(1, 10).ToArray();
        private static readonly int BranchLen = 3;
        private static readonly int BranchNum = Nodes.Length / 2;
        private static readonly int MinSum = Nodes[0] + Nodes[1] + Nodes[Nodes.Length - 1];
        private static readonly int MaxSum = Nodes[0] + Nodes[Nodes.Length - 2] + Nodes[Nodes.Length - 1];
        
        public static string Solve()
        {
            var combos = Combinatorics.GetCombinations(Nodes, BranchLen);
            Dictionary<int, List<int[]>> possibleSums = new Dictionary<int, List<int[]>>();
            foreach (var combo in combos)
            {
                int comboSum = combo.Sum();
                if (!possibleSums.ContainsKey(comboSum))
                {
                    possibleSums.Add(comboSum, new List<int[]>());
                }
                possibleSums[comboSum].Add(combo.ToArray());
            }

            // filter possible sums
            List<int> entriesToRemove = new List<int>();
            foreach (KeyValuePair<int, List<int[]>> kvp in possibleSums)
            {
                if (kvp.Key < MinSum || kvp.Key > MaxSum)
                {
                    entriesToRemove.Add(kvp.Key);
                }
            }
            foreach (int entry in entriesToRemove)
            {
                possibleSums.Remove(entry);
            }

            // GO!
            //List<KeyValuePair<string, List<int[]>>> magicGons = new List<KeyValuePair<string, List<int[]>>>();
            Dictionary<string, List<int[]>> magicGons = new Dictionary<string, List<int[]>>();
            foreach (KeyValuePair<int, List<int[]>> kvp in possibleSums)
            {
                int sum = kvp.Key;
                List<int[]> branches = kvp.Value;
                List<int[]> possibleInnerCircles = GetPossibleInnerCircleVals(branches);
                foreach (int[] innerVals in possibleInnerCircles)
                {
                    List<int> outerVals = Nodes.Where(n => !innerVals.Contains(n)).ToList();
                    List<int[]> magicGon = new List<int[]>();
                    for (int i = 0; i < innerVals.Length; i++)
                    {
                        int a = innerVals[i];
                        int b = innerVals[(i + 1) % innerVals.Length];
                        int o = sum - (a + b);
                        if (!outerVals.Contains(o))
                        {
                            break;
                        }
                        else
                        {
                            outerVals.Remove(o);
                        }
                        magicGon.Add(new int[] { o, a, b });
                    }
                    if (magicGon.Count == BranchNum)
                    {
                        string gonString = GetGonString(magicGon);
                        if (!magicGons.ContainsKey(gonString))
                        {
                            magicGons.Add(gonString, magicGon);
                        }
                       
                    }
                }
            }

            string[] gonStrings = magicGons.Keys.OrderByDescending(s => s).Where(s => s.Length == 16).ToArray();
            return gonStrings[0];
        }

        private static List<int[]> GetPossibleInnerCircleVals(List<int[]> branches)
        {
            Dictionary<int, List<int[]>> branchesWithNum = new Dictionary<int, List<int[]>>();
            foreach (int[] branch in branches)
            {
                foreach (int num in branch)
                {
                    if (!branchesWithNum.ContainsKey(num))
                    {
                        branchesWithNum.Add(num, new List<int[]>());
                    }
                    branchesWithNum[num].Add(branch);
                }
            }

            int[] possibleVals = branchesWithNum.Where(kvp => kvp.Value.Count > 1).Select(kvp => kvp.Key).ToArray();
            List<int[]> perms = Combinatorics.GetPermutations(possibleVals, BranchNum).Select(v => v.ToArray()).ToList();
            return perms;
        }

        private static string GetGonString(List<int[]> magicGon)
        {
            int minStart = Int32.MaxValue;
            int minIdx = -1;
            int idx;
            for (idx = 0; idx < magicGon.Count; idx++)
            {
                if (magicGon[idx][0] < minStart)
                {
                    minStart = magicGon[idx][0];
                    minIdx = idx;
                }
            }

            List<int[]> orderedGon = magicGon.Skip(minIdx).Take(magicGon.Count - minIdx).Concat(magicGon.Take(minIdx)).ToList();
            string gonString = String.Empty;
            foreach (int[] branch in orderedGon)
            {
                foreach (int num in branch)
                {
                    gonString += num;
                }
            }
            return gonString;
        }
    }
}
