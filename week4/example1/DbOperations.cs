using DAL;
using Entities;
using example1.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace example1
{
    public class DBOperations : ControllerBase
    {
        private CarContext _context = new CarContext();
        LoggerController logger = new LoggerController();

       // #region USER FONKS..

        public List<Car> GetModel()
        {
            var carList = _context.Cars.OrderBy(x => x.Id).ToList<Car>();
            return carList;


        }

        public Car GeModelsById(int id)//route'tan

        {
            var car = _context.Cars.Where(car => car.Id == id).SingleOrDefault();
            return car;
        }

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


        public IActionResult UpdateModel(int id, [FromBody] Car updatedCar)
        {

            try
            {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!!", ex);
                return BadRequest();
            }
            
        }

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


        //public IActionResult DeleteAllModels()
        //{
        //    var carList = _context.Cars.OrderBy(x => x.Id).ToList<Car>(); ;
        //    logger = new LoggerController();
        //    if (carList is null)
        //    {

        //        return BadRequest();
        //    }
        //    _context.Cars.Clear();
        //    _context.SaveChanges();
        //    logger.createLog("Tüm elemanlar silindi.");

        //    return Ok();

        //}
        
        //public bool AddModel(Car _car)
        //{
        //    try
        //    {
        //        _context.Cars.Add(_car);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception exc)
        //    {
        //        logger.createLog("HATA " + exc.Message);
        //        return false;
        //    }
        //}
        //public bool DeleteModel(int Id)
        //{
        //    try
        //    {
        //        _context.Cars.Remove(FindUser("", "", Id));
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception exc)
        //    {
        //        logger.createLog("HATA " + exc.Message);
        //        return false;
        //    }
        //}
        //public List<User> GetUsers()
        //{
        //    List<User> users = new List<User>();
        //    users = _context.User.ToList();

        //    InnerJoinExample();

        //    return users;
        //}

        //public User FindUser(string Name = "", string UserName = "", int UserId = 0)
        //{
        //    User? user = new User();
        //    if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(UserName))
        //        user = _context.User.FirstOrDefault(m => m.Name == Name && m.UserName == UserName);
        //    else if (UserId > 0)
        //    {
        //        user = _context.User.FirstOrDefault(m => m.Id == UserId);
        //    }
        //    return user;
        //}

        //public void InnerJoinExample()
        //{
        //    var user = _context.User.Join(_context.Adress, a => a.AdressId,
        //          u => u.Id,
        //         (user, adres) => new UserDetail { City = adres.City, Name = user.Name }).ToList();

        //}

        //#endregion

        //#region TOKEN FONKS..
        //public void CreateLogin(APIAuthority loginUser)
        //{
        //    _context.APIAuthority.Add(loginUser);
        //    _context.SaveChanges();
        //}

        //public APIAuthority GetLogin(APIAuthority loginUser)
        //{
        //    APIAuthority? user = new APIAuthority();
        //    if (!string.IsNullOrEmpty(loginUser.UserName) && !string.IsNullOrEmpty(loginUser.Password))
        //    {
        //        user = _context.APIAuthority.FirstOrDefault(m => m.UserName == loginUser.UserName && m.Password == loginUser.Password);
        //    }

        //    return user;

        //}
        //#endregion

    }
}
