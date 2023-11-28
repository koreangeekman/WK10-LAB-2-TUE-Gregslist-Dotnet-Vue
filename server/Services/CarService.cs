namespace Gregslist.Services;

public class CarService(CarRepository carRepository)
{
  internal List<Car> GetCars()
  { return carRepository.GetCars(); }

  internal Car GetCarById(int carId)
  {
    Car car = carRepository.GetCarById(carId);
    if (car == null) { throw new Exception($"Invalid Car Id: {carId}"); }
    return car;
  }

  internal Car CreateCar(Car carData)
  { return carRepository.CreateCar(carData); }

  internal string DeleteCar(int carId)
  {
    carRepository.DeleteCar(carId);
    return "Car has been deleted";
  }

  internal Car UpdateCar(int carId, Car carData)
  {
    Car car = GetCarById(carId);
    car.Make = carData.Make;
    car.Model = carData.Model;
    car.Year = carData.Year;
    car.Price = carData.Price;
    car.Mileage = carData.Mileage;
    car.Color = carData.Color;
    car.ImgUrl = carData.ImgUrl;

    carRepository.UpdateCar(car);
    return car;
  }
}