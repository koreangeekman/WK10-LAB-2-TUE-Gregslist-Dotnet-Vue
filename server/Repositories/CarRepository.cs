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
    string sql = "SELECT * FROM cars WHERE id = @carId";
    Car car = db.QueryFirstOrDefault<Car>(sql, new { carId });
    return car;
  }

  internal Car CreateCar(Car carData)
  {
    string sql = @"
    INSERT INTO cars(make, model, year, color, price, description, mileage, imgUrl)
    VALUE(@Make, @Model, @Year, @Color, @Price, @Description, @Mileage, @ImgUrl);
    
    SELECT * FROM cars WHERE id = LAST_INSERT_ID();";

    Car car = db.Query<Car>(sql, carData).FirstOrDefault();
    return car;
  }

  internal void DeleteCar(int carId)
  {
    string sql = "DELETE FROM cars WHERE id = @carId LIMIT = 1";
    db.Query<Car>(sql, new { carId });
  }

  internal Car UpdateCar(Car carData)
  {
    string sql = @"UPDATE cars
    SET
    make = @Make,
    model = @Model,
    year = @Year,
    color = @Color,
    price = @Price,
    description = @Description,
    mileage = @Mileage,
    imgUrl = @ImgUrl
    WHERE id = @Id
    ;";

    Car car = db.Query<Car>(sql, carData).FirstOrDefault();
    return car;
  }

}