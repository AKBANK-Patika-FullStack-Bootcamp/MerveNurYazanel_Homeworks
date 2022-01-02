using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi
{
    public class Car
    {

        //        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//id nin auto increment olmasi icin
        public int Id { get; set; }
        public string NumberPlate { get; set; }
        public int ModelCode { get; set; }
        public DateTime ModelYear { get; set; }
        public int UserId { get; set; }
    }
}