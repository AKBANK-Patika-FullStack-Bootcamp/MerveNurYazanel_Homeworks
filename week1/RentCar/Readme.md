Week2 is part of Week1. Here, Easily could seen images for every CRUD operations.


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
Get request for listing all car objects.
```ruby
 [HttpGet]
        public List<Car> GetCars()
        {
            var carList = CarList.OrderBy(x => x.Id).ToList<Car>();

            return carList;
        }
```

Get request for listing a car object according to given id.
```ruby
[HttpGet("{id}")]
        public Car GetById(int id)//route'tan

        {
            var car = CarList.Where(car => car.Id == id).SingleOrDefault();
            return car;
        }
```

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
