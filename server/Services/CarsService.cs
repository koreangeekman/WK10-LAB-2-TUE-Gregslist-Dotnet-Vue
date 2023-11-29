using Microsoft.AspNetCore.Http.HttpResults;

namespace Gregslist.Services;

public class CarsService(CarsRepository carsRepository)
{
  internal List<Car> GetCars()
  { return carsRepository.GetCars(); }

  internal Car GetCarById(int carId)
  {
    Car car = carsRepository.GetCarById(carId);
    if (car == null) { throw new Exception($"Invalid Car Id: {carId}"); }
    return car;
  }

  internal Car CreateCar(Car carData)
  { return carsRepository.CreateCar(carData); }

  internal string DeleteCar(int carId)
  {
    GetCarById(carId);
    carsRepository.DeleteCar(carId);
    return "Car has been deleted";
  }

  internal Car UpdateCar(int carId, Car carData)
  {
    Car car = GetCarById(carId);
    car.Make = carData.Make ?? car.Make;
    car.Model = carData.Model ?? car.Model;
    car.Year = carData.Year ?? car.Year;
    car.Price = carData.Price ?? car.Price;
    car.Mileage = carData.Mileage ?? car.Mileage;
    car.Color = carData.Color ?? car.Color;
    car.ImgUrl = carData.ImgUrl ?? car.ImgUrl;

    carsRepository.UpdateCar(car);
    return car;
  }
}