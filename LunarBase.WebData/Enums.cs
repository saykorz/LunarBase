namespace LunarBase.WebData
{
    class Enums
    {
    }

    public enum UsefullTypes
    {
        ForBuilding, //resource nujni za da se proizvede zgradata
        ForProduction, // resursi koyto tq shte obrabotva. ne e zadaljitelno da obrabotva neshto. primerno solarnite paneli nqmat nujda ot tova.
        Production // kakvo tq shte proizvejda
    }

    public enum  BuildingStatuses
    {
        InProduction,
        Completed,
        Damaged,
        InQuery
    }
}
