On this session created connection between database and code. So that CRUD operations can be done dinamically.



First the connection string get configured in CarContext class.


```ruby
 protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(Configuration.GetConnectionString("UserDBEntities"));
            options.UseSqlServer("Data Source = localhost; Database = RentCarDB; integrated security = True;");
        }
```
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

And then table models defined in same class.

```ruby
 protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Car>().ToTable("Car");
            //  modelBuilder.Entity<APIAuthority>().ToTable("APIAuthority");
        }
```
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

First situation of Car table in the RentCar database:
![1_2](https://user-images.githubusercontent.com/54467555/150929398-b1500eca-73d6-4ca0-8745-5e18583cf4af.png)
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

A class calld DbOperations.cs created and basics of the CRUD operations moved there.

GetModel- GET 

```ruby
 public class DBOperations : ControllerBase
    {
        private CarContext _context = new CarContext();
        LoggerController logger = new LoggerController();


        public List<Car> GetModel()
        {
            var carList = _context.Cars.OrderBy(x => x.Id).ToList<Car>();
            return carList;


        }
  
  ```
  ![1](https://user-images.githubusercontent.com/54467555/150929699-a63a85de-7ed9-4eb8-8add-07993dd72d2f.png)

  
  -------------------------------------------------------------------------------------------------------------------------------------------------------------------

  Get ModelById -GET
  ```ruby
          public Car GeModelsById(int id)//route'tan

        {
            var car = _context.Cars.Where(car => car.Id == id).SingleOrDefault();
            return car;
        }
 ```
   
   ![2_1](https://user-images.githubusercontent.com/54467555/150929768-286407da-2505-42de-a86d-131192e7d49a.png)

   -------------------------------------------------------------------------------------------------------------------------------------------------------------------

 AddModel -POST
 ```ruby
        public  IActionResult AddModel([FromBody] Car newCar)
        {
            try
            {
                var car = _context.Cars.SingleOrDefault(x => x.Id == newCar.Id);

                if (car is not null)
                {

                    return BadRequest();
                }

                _context.Cars.Add(newCar);
                _context.SaveChanges();

                logger = new LoggerController();
                logger.createLog(newCar.Id.ToString() + " id'li bir eleman oluşturuldu.");
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!!" , ex);
                return BadRequest();
            }
           
        }
  ```
  
  ![3](https://user-images.githubusercontent.com/54467555/150929799-49c1aa18-621c-4a50-8a28-30d9f23829b6.png)

  
  -------------------------------------------------------------------------------------------------------------------------------------------------------------------

  UpdateModel -PUT
  ```ruby
        public IActionResult UpdateModel(int id, [FromBody] Car updatedCar)
        {

            //try
            //{
                var car = _context.Cars.SingleOrDefault(x => x.Id == id);

                if (car is null)
                {
                    return BadRequest();
                }



                car.ModelYear = updatedCar.ModelYear != default ? updatedCar.ModelYear : car.ModelYear;
                car.NumberPlate = updatedCar.NumberPlate != default ? updatedCar.NumberPlate : car.NumberPlate;
                car.UserId = updatedCar.UserId != default ? updatedCar.UserId : car.UserId;
                car.ModelCode = updatedCar.ModelCode != default ? updatedCar.ModelCode : car.ModelCode;

                _context.SaveChanges();

                logger = new LoggerController();
                logger.createLog(id.ToString() + " id'li eleman güncellendi.");

                return Ok();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("ERROR!!", ex);
            //    return BadRequest();
            //}
            
        }
  ```
  
  ![4](https://user-images.githubusercontent.com/54467555/150929820-327f4e53-29dc-4a27-bf8a-2b9692026264.png)

  
  -------------------------------------------------------------------------------------------------------------------------------------------------------------------

  DeleteModel -DELETE
  ```ruby
        public IActionResult DeleteModel(int id)
        {
            var car = _context.Cars.SingleOrDefault(x => x.Id == id);


            if (car is null)
                return BadRequest();

            _context.Cars.Remove(car);
            _context.SaveChanges();

            logger = new LoggerController();
            logger.createLog(id.ToString() + " id'li eleman silindi.");

            return Ok();

        }

```

![6](https://user-images.githubusercontent.com/54467555/150930012-86590b1e-da3e-4f91-bc13-9c25958c3a4f.png)
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

After all this modifications final situation of the tables in the RentCar database:

![7](https://user-images.githubusercontent.com/54467555/150930148-2f0b7dbb-a850-44da-9d7d-bd0f1cf521a3.png)
