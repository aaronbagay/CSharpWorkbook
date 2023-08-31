namespace Activity4_01
{
    internal enum FilterCriteriaType
    {
        Class,
        Origin,
        Destination
    }

    internal record FilterCriteria(FilterCriteriaType Filter, string Operand);

}