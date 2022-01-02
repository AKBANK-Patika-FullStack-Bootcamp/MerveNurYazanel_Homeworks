Simulated a little part of "rent a car system". The part which considered below is Car table responding pseudo database (a generic list for this case).
```ruby
public class Car
    {

        //        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//id nin auto increment olmasi icin
        public int Id { get; set; }
        public string NumberPlate { get; set; }
        public int ModelCode { get; set; }
        public DateTime ModelYear { get; set; }
        public int UserId { get; set; }
    }

```

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

First a Car list created manually for testing the CRUD operations.

```ruby
private static List<Car> CarList = new List<Car>()
        {
            new Car{
               Id=1,
                NumberPlate="NW5I STY",
                ModelCode=1, //personal growth et cetera
                ModelYear=new DateTime(2001,06,12),
                UserId=3,
            },

            new Car{
               Id=2,
                NumberPlate="P3 FIX",
                ModelCode=1, //personal growth et cetera
                ModelYear=new DateTime(2001,06,12),
                UserId=3,
            },
            new Car{
                Id=3,
                NumberPlate="SUF I23X",
                ModelCode=1, //personal growth et cetera
                ModelYear=new DateTime(2001,06,12),
                UserId=3,
            },
        };

```

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Get request for listing all car objects.
```ruby
 [HttpGet]
        public List<Car> GetCars()
        {
            var carList = CarList.OrderBy(x => x.Id).ToList<Car>();

            return carList;
        }
```
![get_cars](https://user-images.githubusercontent.com/54467555/147885356-c1e52e5d-bd63-4fd7-ad62-d66e066e24f7.png)

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


Get request for listing a car object according to given id.
```ruby
[HttpGet("{id}")]
        public Car GetById(int id)//route'tan

        {
            var car = CarList.Where(car => car.Id == id).SingleOrDefault();
            return car;
        }
```
![get_cards_by_id](https://user-images.githubusercontent.com/54467555/147885363-5ebb3af6-2695-415d-993c-6872f95708ef.png)


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Post request for creating a new car object.
```ruby
[HttpPost]
        public IActionResult AddBook([FromBody] Car newCar)
        {
            var car = CarList.SingleOrDefault(x => x.Id == newCar.Id);

            if (car is not null)
            {
                return BadRequest();
            }

            CarList.Add(newCar);
            // _context.SaveChanges();
            return Ok();
        }
```
![post_cards](https://user-images.githubusercontent.com/54467555/147885377-494a17b6-383b-4e5d-b195-2ff6624e8ab2.png)
![output_post](https://user-images.githubusercontent.com/54467555/147885380-e8385397-99ce-42a7-ad7b-257a2c45dc90.png)

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



Put request for updating a car object according to given id.
```ruby
[HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Car updatedCar)
        {
            var car = CarList.SingleOrDefault(x => x.Id == id);

            if (car is null)
            {
                return BadRequest();
            }

            car.NumberPlate = updatedCar.NumberPlate != default ? updatedCar.NumberPlate : car.NumberPlate;
            car.ModelCode = updatedCar.ModelCode != default ? updatedCar.ModelCode : car.ModelCode;
            car.ModelYear = updatedCar.ModelYear != default ? updatedCar.ModelYear : car.ModelYear;
            car.UserId = updatedCar.UserId != default ? updatedCar.UserId : car.UserId;

            //_context.SaveChanges();
            return Ok();
        }
```
![update_car](https://user-images.githubusercontent.com/54467555/147885392-3a0d9fa7-04a7-4237-8472-59c32655d866.png)
![output_update](https://user-images.githubusercontent.com/54467555/147885394-c008e5df-1d0a-4aa6-b822-df48619ed62a.png)


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


Delete request for deleting just one car object according to given id.
```ruby
[HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = CarList.SingleOrDefault(x => x.Id == id);

            if (car is null)
                return BadRequest();

            CarList.Remove(car);
            //  _context.SaveChanges();
            return Ok();

        }
```
![delete_by_id](https://user-images.githubusercontent.com/54467555/147885406-4d865225-f2b1-47ff-8d08-fc3843278488.png)

![output_delete](https://user-images.githubusercontent.com/54467555/147885417-507f8a75-456b-4d6b-b550-a6a310725924.png)

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


Delete request for deleting all car objects in the list.
```ruby
[HttpDelete]
        public IActionResult DeleteAllCars()
        {
            var carList = CarList.OrderBy(x => x.Id).ToList<Car>(); ;

            if (carList is null)
                return BadRequest();

            CarList.Clear();
            //  _context.SaveChanges();
            return Ok();

        }
```
![delete_all_cars](https://user-images.githubusercontent.com/54467555/147885420-466a3783-cd35-40da-bd58-e23c80caeea2.png)


![output_delete_all](https://user-images.githubusercontent.com/54467555/147885427-9d88a8a9-6e7c-4bba-859e-3d1ff561b8f7.png)
