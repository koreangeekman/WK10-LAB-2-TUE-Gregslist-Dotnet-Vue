namespace Gregslist.Repositories;

public class CarRepository(IDbConnection db)
{
  internal List<Car> GetCars()
  {
    string sql = "SELECT * FROM cars";
    List<Car> cars = db.Query<Car>(sql).ToList();
    return cars;
  }

  internal Car GetCarById(int carId)
  {
    string sql = "SELECT * FROM cars WHERE id = @cardId";
    Car car = db.Query<Car>(sql, new { carId }).FirstOrDefault();
    return car;
  }

  internal Car CreateCar(Car carData)
  {
    string sql = @"
    INSERT INTO cars(make, model, year, color, price, description, milage, imgUrl)
    VALUE(@Make, @Model, @Year, @Color, @Price, @Description, @Mileage, @ImgUrl);
    
    SELECT * FROM cars WHERE id = LAST_INSERT_ID();";

    Car car = db.Query<Car>(sql, carData).FirstOrDefault();
    return car;
  }

}