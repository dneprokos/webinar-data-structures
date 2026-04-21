using DataStructuresQA.Arrays;
using DataStructuresQA.Challenges;
using DataStructuresQA.Dictionaries;
using DataStructuresQA.Generics;
using DataStructuresQA.LinkedLists;
using DataStructuresQA.Linq;
using DataStructuresQA.Lists;
using DataStructuresQA.Queues;
using DataStructuresQA.Sets;
using DataStructuresQA.Stacks;
using DataStructuresQA.Trees;
using DataStructuresQA.Tuples;

// Each demo entry: CLI key, title, and an action that runs a representative file from that module.
// To run a full module, open the individual files under each folder and run them independently.
var demos = new (string Key, string Title, Action Run)[]
{
    ("arrays",      "01 — Arrays (initialization, access, methods, QA)",         () => { DataStructuresQA.Arrays.Initialization.Run(); DataStructuresQA.Arrays.AccessingElements.Run(); DataStructuresQA.Arrays.CommonMethods.Run(); DataStructuresQA.Arrays.QaExample.Run(); }),
    ("generics",    "02 — Generics (basic, constraints, QA wrapper)",             () => { BasicGenerics.Run(); Constraints.Run(); DataStructuresQA.Generics.QaExample.Run(); }),
    ("lists",       "03 — Lists (init, methods, QA patterns)",                   () => { DataStructuresQA.Lists.Initialization.Run(); DataStructuresQA.Lists.CommonMethods.Run(); DataStructuresQA.Lists.QaExample.Run(); }),
    ("tuples",      "04 — Tuples (init, access, QA patterns)",                   () => { DataStructuresQA.Tuples.Initialization.Run(); DataStructuresQA.Tuples.AccessingElements.Run(); DataStructuresQA.Tuples.QaExample.Run(); }),
    ("sets",        "05 — Sets (init, operations, QA patterns)",                 () => { DataStructuresQA.Sets.Initialization.Run(); DataStructuresQA.Sets.CommonMethods.Run(); DataStructuresQA.Sets.QaExample.Run(); }),
    ("dicts",       "06 — Dictionaries (init, methods, QA patterns)",            () => { DataStructuresQA.Dictionaries.Initialization.Run(); DataStructuresQA.Dictionaries.CommonMethods.Run(); DataStructuresQA.Dictionaries.QaExample.Run(); }),
    ("stacks",      "07 — Stacks (init, methods, QA patterns)",                  () => { DataStructuresQA.Stacks.Initialization.Run(); DataStructuresQA.Stacks.CommonMethods.Run(); DataStructuresQA.Stacks.QaExample.Run(); }),
    ("queues",      "08 — Queues (init, methods, QA patterns)",                  () => { DataStructuresQA.Queues.Initialization.Run(); DataStructuresQA.Queues.CommonMethods.Run(); DataStructuresQA.Queues.QaExample.Run(); }),
    ("linked",      "09 — Linked List (init, methods, QA patterns)",             () => { DataStructuresQA.LinkedLists.Initialization.Run(); DataStructuresQA.LinkedLists.CommonMethods.Run(); DataStructuresQA.LinkedLists.QaExample.Run(); }),
    ("trees",       "10 — Binary Search Tree (init, traversals, QA patterns)",   () => { DataStructuresQA.Trees.Initialization.Run(); DataStructuresQA.Trees.AccessingElements.Run(); DataStructuresQA.Trees.QaExample.Run(); }),
    ("linq",        "11 — LINQ (filter, project, aggregate, sort, group)",       () => { Filtering.Run(); Projection.Run(); Aggregation.Run(); SortingAndPaging.Run(); GroupingAndJoining.Run(); DataStructuresQA.Linq.QaExample.Run(); }),
    ("challenge",   "12 — Challenge: most frequent character",                    MostFrequentChar.Run),
};

var key = args.Length > 0 ? args[0].Trim() : "all";
if (key.Equals("help", StringComparison.OrdinalIgnoreCase) || key.Equals("-h", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Usage: dotnet run -- [key|all]");
    Console.WriteLine("Keys:  " + string.Join(", ", demos.Select(d => d.Key)));
    return;
}

if (key.Equals("all", StringComparison.OrdinalIgnoreCase))
{
    foreach (var (_, title, run) in demos)
    {
        Console.WriteLine();
        Console.WriteLine(new string('=', 60));
        Console.WriteLine(title);
        Console.WriteLine(new string('=', 60));
        run();
    }
}
else
{
    var found = demos.FirstOrDefault(d => d.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
    if (found.Key is null)
    {
        Console.WriteLine($"Unknown key '{key}'. Use: dotnet run -- help");
        return;
    }

    found.Run();
}
