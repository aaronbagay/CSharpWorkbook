using System;

namespace Chapter04.Activities.Activity4_01
{
    internal enum FilterCriteriaType
    {
        Class,
        Origin,
        Destination
    }

    internal record FilterCriteria(FilterCriteriaType Filter, string Operand);

}