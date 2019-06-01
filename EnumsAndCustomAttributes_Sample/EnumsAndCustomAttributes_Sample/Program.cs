namespace EnumsAndCustomAttributes_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Character Character = new Character();

            Character.AddMove(Character.DIRECTION.North);
            Character.AddMove(Character.DIRECTION.NorthWest);

            Character.DoMove();
        }
    }
}
