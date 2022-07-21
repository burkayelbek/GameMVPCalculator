namespace GameMVPCalculator.Models
{
    public class PointEntity
    {
        public string DisplayName { get; set; } = default!;
        public string? ReferenceName { get; set; } = default!;

        // Based on the game the role for this point (guard, center, goal keeper etc)
        public string Position { get; set; } = default!;
        public decimal Value { get; set; }


        public int Priority { get; set; }


        /*
         * Display Name, int -> (value), reference name, int -> (işlem önceliği) 1,2,3,4,5 şeklinde yazılacak. 
         * İşlem yapmak istediğin şeyin stringini verecek. İşlem önceliğine göre toplama çarpma yapılarak aggregate edilecek.
         */
    }
}
