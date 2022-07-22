namespace GameMVPCalculator.Models
{
    public class PointEntity
    {
        // Based on the game the role for this point (guard, center, goal keeper etc)
        public char PositionLetter { get; set; } = default!;
        public string PositionText { get; set; } = default!;
        public Dictionary<string, decimal> Values { get; set; }


        /*
         * Display Name, int -> (value), reference name, int -> (işlem önceliği) 1,2,3,4,5 şeklinde yazılacak. 
         * İşlem yapmak istediğin şeyin stringini verecek. İşlem önceliğine göre toplama çarpma yapılarak aggregate edilecek.
         */
    }
}
